using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Data.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicStore.Api.Data.PostgreSql.Configurations
{
	/// <summary>
	/// Конфигурация <see cref="OrderProduct"/>
	/// </summary>
	internal class OrderProductConfiguration : EntityBaseConfiguration<OrderProduct>
	{
		/// <inheritdoc/>
		public override void ConfigureChild(EntityTypeBuilder<OrderProduct> builder)
		{
			builder.ToTable("order_products")
				.HasComment("Товары из заказов");

			builder.Property(x => x.OrderId)
				.HasComment("Ид заказа")
				.IsRequired();

			builder.Property(x => x.ProductId)
				.HasComment("Ид товара")
				.IsRequired();

			builder.HasOne(x => x.Order)
				.WithMany(x => x.OrderProducts)
				.HasForeignKey(x => x.OrderId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.Product)
				.WithMany(x => x.OrderProducts)
				.HasForeignKey(x => x.ProductId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Restrict);

			builder.SetPropertyAccessModeField(x => x.Order, OrderProduct.OrderFieldName);
			builder.SetPropertyAccessModeField(x => x.Product, OrderProduct.ProductFieldName);
		}
	}
}
