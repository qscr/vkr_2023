using DynamicStore.Api.Contracts.Requests.AuthenticationRequests;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests.RefreshToken;
using MediatR;

namespace DynamicStore.Api.Core.Requests.AuthenticationRequests.RefreshToken
{
	/// <summary>
	/// Команда создания записи
	/// </summary>
	public class RefreshTokenCommand : RefreshTokenRequest, IRequest<TokenResponse>
	{
	}
}
