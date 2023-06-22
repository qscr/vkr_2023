using System;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.FileRequests.DownloadFile;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.FileRequests.DownloadFile
{
	/// <inheritdoc/>
	public class DownloadFileQueryHandler : IRequestHandler<DownloadFileQuery, DownloadFileResponse>
	{
		private readonly IS3Service _s3Service;
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="s3Service">Хранилище файлов</param>
		/// <param name="dbContext">БД</param>
		public DownloadFileQueryHandler(IS3Service s3Service, IDbContext dbContext)
		{
			_s3Service = s3Service;
			_dbContext = dbContext;
		}

		/// <inheritdoc/>
		public async Task<DownloadFileResponse> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
		{
			if (request?.Id is null)
				throw new ArgumentNullException(nameof(request));

			var file = await _dbContext.Files
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
				?? throw new EntityNotFoundException<File>(request.Id);

			var fileContents = await _s3Service.GetAsync(file.Address, cancellationToken: cancellationToken)
				?? throw new EntityNotFoundException<File>(request.Id);

			return new DownloadFileResponse(fileContents.Content, fileContents.ContentType, fileContents.FileName);
		}
	}
}
