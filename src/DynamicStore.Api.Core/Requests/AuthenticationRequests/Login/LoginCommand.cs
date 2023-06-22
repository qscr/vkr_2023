using DynamicStore.Api.Contracts.Requests.AuthenticationRequests;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Login;
using MediatR;

namespace DynamicStore.Api.Core.Requests.AuthenticationRequests.Login
{
	/// <summary>
	/// Команда входа в систему.
	/// </summary>
	public class LoginCommand : LoginRequest, IRequest<TokenResponse>
	{
	}
}
