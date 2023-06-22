using DynamicStore.Api.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DynamicStore.Api.Web.Controllers
{
	/// <summary>
	/// Базовый API-контроллер
	/// </summary>
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[SwaggerResponse(StatusCodes.Status500InternalServerError, type: typeof(ProblemDetailsResponse))]
	public class ApiControllerBase : ControllerBase
	{
	}
}
