namespace DynamicStore.Api.Core.Models
{
	/// <summary>
	/// Модель для хранения данных в БД в JSON формате
	/// </summary>
	public class CarInfoModel
	{
		/// <summary>
		/// Высота
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		/// Информация
		/// </summary>
		public string Information { get; set; } = default!;
	}
}
