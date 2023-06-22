using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using File = DynamicStore.Api.Core.Entities.File;

namespace DynamicStore.Api.Core.Requests.LayoutRequests.PutLayoutDesign
{
	/// <summary>
	/// Обработчик команды <see cref="PutLayoutDesignCommand"/>
	/// </summary>
	public class PutLayoutDesignCommandHandler : IRequestHandler<PutLayoutDesignCommand>
	{
		private readonly IAuthorizationService _authorizationService;
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly IUserContext _userContext;
		private readonly IDbContext _dbContext;
		private readonly IS3Service _s3Service;

		private readonly string _routes = "routes";
		private readonly string _type = "type";
		private readonly string _carousel = "carousel";
		private readonly string _items = "items";
		private readonly string _child = "child";
		private readonly string _children = "children";
		private readonly string _content = "content";
		private readonly string _url = "url";
		private readonly string _key = "key";
		private readonly string _name = "name";

		private string _layout = "string";

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="authorizationService">Сервис авторизации</param>
		/// <param name="dateTimeProvider">Провайдер времени</param>
		/// <param name="userContext">Контекст пользователя</param>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="s3Service">Хранилище файлов</param>
		public PutLayoutDesignCommandHandler(
			IAuthorizationService authorizationService,
			IDateTimeProvider dateTimeProvider,
			IUserContext userContext,
			IDbContext dbContext,
			IS3Service s3Service)
		{
			_authorizationService = authorizationService;
			_dateTimeProvider = dateTimeProvider;
			_userContext = userContext;
			_dbContext = dbContext;
			_s3Service = s3Service;
		}

		/// <inheritdoc/>
		public async Task<Unit> Handle(
			PutLayoutDesignCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var dataDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(request.Data);

			foreach (JObject route in dataDictionary[_routes] as JArray)
			{
				FindRoutes(route.GetValue(_content) as JObject, cancellationToken);
			}

			Thread.Sleep(100000);
			var layout = await _authorizationService.FilterUpdateLayout(_dbContext.Layouts)
				.FirstOrDefaultAsync(x => x.ShopId == _userContext.ShopId, cancellationToken)
				?? throw new NotFoundException("Не найден дизайн магазина");

			layout.IsDeleted = true;

			var shop = await _dbContext.Shops
				.FirstOrDefaultAsync(x => x.Id == _userContext.ShopId, cancellationToken)
				?? throw new NotFoundException("Не найден магазин");

			layout = new Layout(
				activeFrom: _dateTimeProvider.UtcNow,
				layoutDesign: _layout,
				shop: shop);

			await _dbContext.Layouts.AddAsync(layout, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return default;
		}

		private async void FindRoutes(JObject content, CancellationToken cancellationToken)
		{
			var type = content.GetValue(_type).ToString();
			if (type.ToLower(CultureInfo.InvariantCulture) == _carousel)
			{
				var files = await SaveCarouselData(content[_items] as JArray, cancellationToken);
				ChangeLayout(files, content, cancellationToken);
			}

			if (content.ContainsKey(_children))
				foreach (JObject child in content[_children] as JArray)
					FindRoutes(child, cancellationToken);

			if (content.ContainsKey(_child))
				FindRoutes(content[_child] as JObject, cancellationToken);
		}

		private async Task<List<File>> SaveCarouselData(JArray items, CancellationToken cancellationToken)
		{
			var urls = new List<string>();
			var files = new List<File>();
			foreach (var item in items)
			{
				string stringUrl = item.Value<JObject>().GetValue(_url).ToString();
				urls.Add(stringUrl);

				foreach (var url in urls)
				{
					var file = await SaveFile(url, cancellationToken);

					files.Add(file);
				}
			}

			return files;
		}

		private async Task<File> SaveFile(string url, CancellationToken cancellationToken)
		{
			var uri = new Uri(url);
			File newFile;

			using (var client = new HttpClient())
			{
				using (var response = await client.GetAsync(url, cancellationToken))
				using (var streamToReadFrom = await response.Content.ReadAsStreamAsync(cancellationToken))
				{
					var fileName = Guid.NewGuid().ToString();
					var contentType = response.Content.Headers.ContentType?.MediaType;
					var address = await _s3Service.UploadAsync(
						new Models.FileContent
						{
							Content = streamToReadFrom,
							ContentType = contentType,
							FileName = fileName,
						},
						cancellationToken);

					newFile = new File(address, fileName, address.Length, contentType);
				}
			}
			await _dbContext.Files.AddAsync(newFile, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return newFile;
		}

		private async Task ChangeLayout(List<File> files, JObject content, CancellationToken cancellationToken)
		{
			var ads = new List<Advertising>();
			var key = Guid.NewGuid();

			content.Remove(_items);
			content[_key] = key;
			content[_url] = "{fileId}";

			var shop = await _dbContext.Shops
				.FirstOrDefaultAsync(x => x.Id == _userContext.ShopId, cancellationToken)
				?? throw new NotFoundException("Не найден магазин");

			foreach (var file in files)
			{
				string name = content.GetValue(_name).ToString();
				ads.Add(new Advertising(
					name: name,
					route: "",
					key: key,
					file: file,
					shop: shop));
			}

			await _dbContext.Advertisements.AddRangeAsync(ads, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			_layout = JsonConvert.SerializeObject(content);
		}
	}
}
