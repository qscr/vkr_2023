using DynamicStore.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicStore.Api.Data.PostgreSql.Configurations
{
	/// <summary>
	/// Конфигурация <see cref="Category"/>
	/// </summary>
	internal class CategoryConfiguration : EntityBaseConfiguration<Category>
	{
		/// <inheritdoc/>
		public override void ConfigureChild(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("categories")
				.HasComment("Категории товаров");

			builder.Property(x => x.Code)
				.HasComment("Код категории")
				.IsRequired();

			builder.Property(x => x.Name)
				.HasComment("Наименование категории")
				.IsRequired();

			builder.Property(x => x.Description)
				.HasComment("Описание категории");

			builder.Property(x => x.Key)
				.HasComment("Ключ");

			builder.Property(x => x.FileId)
				.HasComment("Ид картинки");

			builder.HasMany(x => x.Products)
				.WithMany(x => x.Categories);

			builder.HasOne(x => x.File)
				.WithOne(x => x.Category)
				.HasForeignKey<Category>(x => x.FileId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
