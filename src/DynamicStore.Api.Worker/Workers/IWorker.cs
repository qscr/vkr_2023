using System.Threading.Tasks;

namespace DynamicStore.Api.Worker.Workers
{
	/// <summary>
	/// Background-служба
	/// </summary>
	public interface IWorker
	{
		/// <summary>
		/// Запустить службу
		/// </summary>
		/// <returns>-</returns>
		Task RunAsync();
	}
}
