using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.FileRequests.UploadFile;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using MediatR;

namespace DynamicStore.Api.Core.Requests.FileRequests.UploadFile
{
	/// <inheritdoc/>
	public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, UploadFileResponse>
	{
		private readonly IS3Service _s3Service;
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="s3Service">Хранилище файлов</param>
		/// <param name="dbContext">БД</param>
		public UploadFileCommandHandler(IS3Service s3Service, IDbContext dbContext)
		{
			_s3Service = s3Service;
			_dbContext = dbContext;
		}

		/// <inheritdoc/>
		public async Task<UploadFileResponse> Handle(UploadFileCommand request, CancellationToken cancellationToken)
		{
			if (request?.Files is null)
				throw new ArgumentNullException(nameof(request));

			var filesToSave = new List<File>();
			foreach (var file in request.Files)
			{
				var address = await _s3Service.UploadAsync(
					new Models.FileContent
					{
						Content = file.FileStream,
						ContentType = file.ContentType,
						FileName = file.FileName,
					},
					cancellationToken);

				filesToSave.Add(new File(address, file.FileName, file.FileStream.Length, file.ContentType));
			}

			await _dbContext.Files.AddRangeAsync(filesToSave, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return new UploadFileResponse(filesToSave.ToDictionary(x => x.FileName, x => x.Id));
		}
	}
}
