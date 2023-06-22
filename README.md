# DynamicStore.Api

Описание проекта

## Интегрированные технологии

- [ASP.NET Core](https://docs.microsoft.com/ru-ru/aspnet/core/?view=aspnetcore-5.0)
- .NET 5
- [EF Core](https://docs.microsoft.com/ru-ru/ef/core/) + Migrations - ORM
- [Serilog](https://github.com/serilog/serilog-aspnetcore) - structural logging
- [Mediatr](https://github.com/jbogard/MediatR) - SQRS mediator library
- [xUnit](https://xunit.net/) unit & functional testing
- [AWSSDK.S3](https://aws.amazon.com/ru/sdk-for-net/) file storage
- [MassTransit](https://masstransit-project.com/) queue
- [AutoMapper](https://automapper.org/) object fields mapper


## Структура проекта

Решение разбито на две группы проектов: src (исполняемый код) и test (модульные и интеграционные тесты). Решение побито на проекты в соответствии с [onion architecture pattern](https://www.codeguru.com/csharp/csharp/cs_misc/designtechniques/understanding-onion-architecture.html). Большинство проектов имеют "точку входа" - класс Entry. В нем конфигурируются реализованные зависимости проекта.

### DynamicStore.Api.Contracts

Проект с бизнес-контрактами приложения. Не зависит от других проектов. Представляет собой набор контрактов приложения (классов, определяющих запросы и ответы, обрабатываемые приложением и составляющие его внешний интерфейс API).

### DynamicStore.Api.Client

Проект с .NET-HTTP-библиотекой-клиентом для веб-сервиса. Используется в других сервисах для обращения к текущему микросервису. Использует контракты в качестве DTO при вызове методов API. 

### DynamicStore.Api.Core

Проект с бизнес-логикой приложения. Не зависит от других проектов, кроме контрактов. Для использования баз данных и других внешних сервисов задает абстракции в каталоге /Abstractions. Доменная модель приложения - сущности и объекты-значения содержатся в /Entities. Обработчики запросов Mediatr в /Requests, разбиты по каталогам на каждую сущность для удобства навигации. Сервисы приложения в каталоге /Services.

### DynamicStore.Api.Migrator

Проект-мигратор БД. Просто запускаемый проект для миграции БД.

### DynamicStore.Api.Data.PostgreSql

Проект с реализацией доступа к данным в терминах БД PostgreSql. Использует EF Core для обращения к БД. Для генерации миграций есть скрипты в /Tools.

### DynamicStore.Api.Data.RabbitMq

Проект с реализацией доступа к данным в терминах очереди RabbitMq. Для подключения к очереди используется [MassTransit](https://masstransit-project.com/). 
Для подключения потребителей используется метод `.AddConsumer<TMessage, TConsumer>()`, для конфигурации продьюсера - `.AddProducer<TMessage>()` в модуле /Entry.cs. 

По умолчанию метод `.AddConsumer<TMessage, TConsumer>()` создает:
- exchange {TMessage.FullName}Exchange - входная точка топологии. Должна совпадать с названием exchange, в который клиент кладет сообщения. Название и конфигурация exchange переопределяются в параметрах метода.
- exchange {TConsumer.FullName}Exchange - тестовая входная точка топологии. Используется для изолированного мануального тестирования exchange и потребителя без воздействия на exchange {TMessage.FullName}Exchange, т.к. на него могут быть подписаны другие потребители. Подписана на сообщения из {TMessage.FullName}Exchange.
- очередь {TConsumer.FullName}Queue - очередь, обрабатывающая сообщения. Подписана на {TConsumer.FullName}Exchange.
- очередь {TConsumer.FullName}Queue_error - очередь для обработки ошибок потребителя

По умолчанию метод `.AddProducer<TMessage>()` создает:
- exchange {TMessage.FullName}Exchange - входная точка топологии. Должна совпадать с названием exchange, из которого потребитель будет забирать сообщения.

### DynamicStore.Api.Data.S3

Проект с реализацией доступа к данным в терминах интерфейса файлового хранилища S3. Использует протокол [AWS S3](https://docs.aws.amazon.com/AmazonS3/latest/userguide/Welcome.html) для обработки файлов. В качестве тестового хранилища можно использовать [minio](https://docs.min.io/docs/minio-docker-quickstart-guide.html). 

Работа с файлами реализована в реализации интерфейса `IS3Service`. Файлы при этом сохраняются по пути `$"{DateTime.UtcNow:yyyy-MM-dd}/{Guid.NewGuid()}{Path.GetExtension(fileName)}"`, т.е. раскиданы по папкам-дням и содержут в себе расширение.
Для связи файлов с сущностями реляционной БД реализована сущность `File` и контроллер FileController, позволяющий загружать и скачивать файлы.

### DynamicStore.Api.Web

Проект-веб хост приложения. Конфигурация разных аспектов работы web-приложения реализована в отдельных каталогах. Переменные приложения заведены в appsettigs.json, переопределяются в UserSecrets для отладки. 

### DynamicStore.Api.Worker

Проект - хост задач по расписанию. Использует Hangfire для выполнения задач. Имеет встроенный дашборд (по пути /worker), в котором можно посмотреть на выполненные и выполняющиеся задачи, а также отладить их

### DynamicStore.Api.Cache

Проект с реализацией распределенного кэша _IDistributedCache_ с помощью Redis. 

### DynamicStore.Api.IntegrationTest

Проект с интеграционными тестами. Подключение к БД мокировано и обрабатывается в памяти. Для тестирования используется проект .Client. Для тестов используется xUnit. Для интеграционных тестов отменен запуск задач по расписанию и прослушивание очереди сообщений, а публикация сообщений в очередь замокирована.

### DynamicStore.Api.UnitTest

Проект с модкльными тестами. Для тестов используется xUnit.
