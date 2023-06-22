using System;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.LayoutRequests.PutMainLayoutDesign
{
	/// <summary>
	/// Обработчик команды <see cref="PutMainLayoutDesignCommand"/>
	/// </summary>
	public class PutMainLayoutDesignCommandHandler : IRequestHandler<PutMainLayoutDesignCommand>
	{
		private readonly IAuthorizationService _authorizationService;
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="authorizationService">Сервис авторизации</param>
		/// <param name="dbContext">Контекст БД</param>
		public PutMainLayoutDesignCommandHandler(
			IAuthorizationService authorizationService,
			IDbContext dbContext)
		{
			_authorizationService = authorizationService;
			_dbContext = dbContext;
		}

		/// <inheritdoc/>
		public async Task<Unit> Handle(
			PutMainLayoutDesignCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var layout = await _authorizationService.FilterUpdateMainLayout(_dbContext.Layouts)
				.FirstOrDefaultAsync(x => x.ShopId == null, cancellationToken)
				?? throw new NotFoundException("Не найден дизайн к главной странице");

			layout.LayoutDesign = request.LayoutDesign;

			await _dbContext.SaveChangesAsync(cancellationToken);

			return default;
		}
	}
}
