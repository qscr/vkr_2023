namespace DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Register
{
	/// <summary>
	/// Магазин для регистрации
	/// </summary>
	public class RegisterRequestShop
	{
		/// <summary>
		/// Наименование магазина
		/// </summary>
		public string Name { get; set; } = default!;
	}
}
