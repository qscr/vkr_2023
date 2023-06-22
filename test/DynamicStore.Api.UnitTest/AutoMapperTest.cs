using Xunit;
using Xunit.Abstractions;

namespace DynamicStore.Api.UnitTest
{
	/// <summary>
	/// Тест конфигураций автомаппера
	/// </summary>
	public class AutoMapperTest : UnitTestBase
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="testOutputHelper">Логгер</param>
		public AutoMapperTest(ITestOutputHelper testOutputHelper)
			: base(testOutputHelper)
		{ }

		/// <summary>
		/// Метод получения списка машинок должен возвращать машинки
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public void Mapper_AllConfigurations_AssertConfigurationIsValid()
			=> Mapper.ConfigurationProvider.AssertConfigurationIsValid();
	}
}
