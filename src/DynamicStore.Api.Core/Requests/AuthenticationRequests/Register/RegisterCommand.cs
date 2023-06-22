using DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Register;
using MediatR;

namespace DynamicStore.Api.Core.Requests.AuthenticationRequests.Register
{
	/// <summary>
	/// Команда регистрации пользователя
	/// </summary>
	public class RegisterCommand : RegisterRequest, IRequest<RegisterResponse>
	{
	}
}
