using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Data.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicStore.Api.Data.PostgreSql.Configurations
{
	/// <summary>
	/// Конфигурация <see cref="Shop"/>
	/// </summary>
	internal class ShopConfiguration : EntityBaseConfiguration<Shop>
	{
		/// <inheritdoc/>
		public override void ConfigureChild(EntityTypeBuilder<Shop> builder)
		{
			builder.ToTable("shops")
				.HasComment("Магазины");

			builder.Property(x => x.Name)
				.HasComment("Наименование магазина")
				.IsRequired();

			builder.Property(x => x.OwnerId)
				.HasComment("Ид владельца")
				.IsRequired();

			builder.Property(x => x.FileId)
				.HasComment("Ид картинки");

			builder.HasOne(x => x.Owner)
				.WithOne()
				.HasForeignKey<Shop>(x => x.OwnerId)
				.OnDelete(DeleteBehavior.ClientCascade);

			builder.HasMany(x => x.Layouts)
				.WithOne(x => x.Shop)
				.HasForeignKey(x => x.ShopId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(x => x.Products)
				.WithOne(x => x.Shop)
				.HasForeignKey(x => x.ShopId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.File)
				.WithOne(x => x.Shop)
				.HasForeignKey<Shop>(x => x.FileId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(x => x.Advertisings)
				.WithOne(x => x.Shop)
				.HasForeignKey(x => x.ShopId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Cascade);

			builder.SetPropertyAccessModeField(x => x.Owner, Shop.OwnerFieldName);
		}
	}
}
