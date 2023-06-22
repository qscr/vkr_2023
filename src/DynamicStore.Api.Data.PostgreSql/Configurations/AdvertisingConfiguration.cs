using DynamicStore.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicStore.Api.Data.PostgreSql.Configurations
{
	/// <summary>
	/// Конфигурация <see cref="Advertising"/>
	/// </summary>
	internal class AdvertisingConfiguration : EntityBaseConfiguration<Advertising>
	{
		/// <inheritdoc/>
		public override void ConfigureChild(EntityTypeBuilder<Advertising> builder)
		{
			builder.ToTable("advertisements")
				.HasComment("Рекламы");

			builder.Property(x => x.Name)
				.HasComment("Наименование рекламы")
				.IsRequired();

			builder.Property(x => x.Route)
				.HasComment("Путь")
				.IsRequired();

			builder.Property(x => x.Key)
				.HasComment("Ключ");

			builder.Property(x => x.FileId)
				.HasComment("Ид картинки")
				.IsRequired();

			builder.Property(x => x.ShopId)
				.HasComment("Ид магазина");

			builder.HasOne(x => x.File)
				.WithOne(x => x.Advertising)
				.HasForeignKey<Advertising>(x => x.FileId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.Shop)
				.WithMany(x => x.Advertisings)
				.HasForeignKey(x => x.ShopId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
