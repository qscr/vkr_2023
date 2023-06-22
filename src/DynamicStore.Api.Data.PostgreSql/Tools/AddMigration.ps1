# замените ${Name} на название вашей миграции

Add-Migration ${Name} -Project DynamicStore.Api.Data.PostgreSql -StartupProject DynamicStore.Api.Data.Migrator -verbose
