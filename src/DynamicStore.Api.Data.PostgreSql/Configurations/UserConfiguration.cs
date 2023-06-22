using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Data.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicStore.Api.Data.PostgreSql.Configurations
{
	/// <summary>
	/// Конфигурация <see cref="User"/>
	/// </summary>
	internal class UserConfiguration : EntityBaseConfiguration<User>
	{
		/// <inheritdoc/>
		public override void ConfigureChild(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("users")
				.HasComment("Пользователи");

			builder.Property(x => x.Name)
				.HasComment("Имя пользователя")
				.IsRequired()
				.UsePropertyAccessMode(PropertyAccessMode.Field);

			builder.Property(x => x.Email)
				.HasComment("Email")
				.IsRequired()
				.UsePropertyAccessMode(PropertyAccessMode.Field);

			builder.Property(x => x.PasswordHash)
				.HasComment("Хэш пароля")
				.IsRequired()
				.UsePropertyAccessMode(PropertyAccessMode.Field);

			builder.Property(x => x.ShopId)
				.HasComment("Ид магазина");

			builder.Property(x => x.FileId)
				.HasComment("Ид картинки");

			builder.HasOne(x => x.Shop)
				.WithOne()
				.HasForeignKey<User>(x => x.ShopId)
				.OnDelete(DeleteBehavior.ClientCascade);

			builder.HasMany(x => x.Orders)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.HasPrincipalKey(x => x.Id)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.File)
				.WithOne(x => x.User)
				.HasForeignKey<User>(x => x.FileId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.SetPropertyAccessModeField(x => x.Shop, User.ShopFieldName);
		}
	}
}
