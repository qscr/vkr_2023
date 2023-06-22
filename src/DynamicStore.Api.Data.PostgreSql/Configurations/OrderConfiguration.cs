using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Data.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicStore.Api.Data.PostgreSql.Configurations
{
	/// <summary>
	/// Конфигурация <see cref="Order"/>
	/// </summary>
	internal class OrderConfiguration : EntityBaseConfiguration<Order>
	{
		/// <inheritdoc/>
		public override void ConfigureChild(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("orders")
				.HasComment("Заказы");

			builder.Property(x => x.Quantity)
				.HasComment("Количество товаров")
				.IsRequired();

			builder.Property(x => x.TotalPrice)
				.HasComment("Общая стоимость")
				.IsRequired();

			builder.Property(x => x.IsPayed)
				.HasComment("Оплачен ли заказ")
				.IsRequired();

			builder.Property(x => x.UserId)
				.HasComment("Пользователь")
				.IsRequired();

			builder.HasOne(x => x.User)
				.WithMany(x => x.Orders)
				.HasForeignKey(x => x.UserId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(x => x.OrderProducts)
				.WithOne(x => x.Order)
				.HasForeignKey(x => x.OrderId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Restrict);

			builder.SetPropertyAccessModeField(x => x.User, Order.UserFieldName);
		}
	}
}
