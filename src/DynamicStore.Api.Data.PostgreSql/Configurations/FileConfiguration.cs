using DynamicStore.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicStore.Api.Data.PostgreSql.Configurations
{
	/// <summary>
	/// Конфигурация <see cref="File"/>
	/// </summary>
	internal class FileConfiguration : EntityBaseConfiguration<File>
	{
		/// <inheritdoc/>
		public override void ConfigureChild(EntityTypeBuilder<File> builder)
		{
			builder.Property(x => x.Address).IsRequired();
			builder.Property(x => x.FileName).IsRequired();
			builder.Property(x => x.Size).IsRequired();
			builder.Property(x => x.ContentType);
			builder.Ignore(x => x.Extension);

			builder.HasOne(x => x.Category)
				.WithOne(x => x.File)
				.HasForeignKey<Category>(x => x.FileId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.Shop)
				.WithOne(x => x.File)
				.HasForeignKey<Shop>(x => x.FileId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.User)
				.WithOne(x => x.File)
				.HasForeignKey<User>(x => x.FileId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.Advertising)
				.WithOne(x => x.File)
				.HasForeignKey<Advertising>(x => x.FileId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.Product)
				.WithMany(x => x.Files)
				.HasForeignKey(x => x.ProductId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.SetNull);
		}
	}
}
