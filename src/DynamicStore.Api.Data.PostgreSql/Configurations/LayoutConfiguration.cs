using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Data.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicStore.Api.Data.PostgreSql.Configurations
{
	/// <summary>
	/// Конфигурация <see cref="Layout"/>
	/// </summary>
	internal class LayoutConfiguration : EntityBaseConfiguration<Layout>
	{
		/// <inheritdoc/>
		public override void ConfigureChild(EntityTypeBuilder<Layout> builder)
		{
			builder.ToTable("layouts")
				.HasComment("Дизайны страничек магазинов");

			builder.Property(x => x.ActiveFrom)
				.HasComment("Дата активации дизайна")
				.IsRequired();

			builder.Property(x => x.LayoutDesign)
				.HasComment("Дизайн страницы")
				.IsRequired()
				.HasColumnType("jsonb")
				.UsePropertyAccessMode(PropertyAccessMode.Field);

			builder.Property(x => x.ShopId)
				.HasComment("Ид магазина");

			builder.Property(x => x.IsDeleted)
				.HasComment("Признак удаленности")
				.IsRequired();

			builder.HasOne(x => x.Shop)
				.WithMany(x => x.Layouts)
				.HasForeignKey(x => x.ShopId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.ClientCascade);

			builder.SetPropertyAccessModeField(x => x.Shop, Layout.ShopFieldName);
		}
	}
}
