using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Data.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicStore.Api.Data.PostgreSql.Configurations
{
	/// <summary>
	/// Конфигурация <see cref="Product"/>
	/// </summary>
	internal class ProductConfiguration : EntityBaseConfiguration<Product>
	{
		/// <inheritdoc/>
		public override void ConfigureChild(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("products")
				.HasComment("Товары");

			builder.Property(x => x.Name)
				.HasComment("Наименование товара")
				.IsRequired();

			builder.Property(x => x.Description)
				.HasComment("Описание товара");

			builder.Property(x => x.Price)
				.HasComment("Цена товара")
				.IsRequired();

			builder.Property(x => x.ShopId)
				.HasComment("Ид магазина")
				.IsRequired();

			builder.HasOne(x => x.Shop)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.ShopId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.ClientCascade);

			builder.HasMany(x => x.Categories)
				.WithMany(x => x.Products);

			builder.HasMany(x => x.OrderProducts)
				.WithOne(x => x.Product)
				.HasForeignKey(x => x.ProductId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(x => x.Files)
				.WithOne(x => x.Product)
				.HasForeignKey(x => x.ProductId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.SetNull);

			builder.SetPropertyAccessModeField(x => x.Shop, Product.ShopFieldName);
		}
	}
}
