using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicStore.Api.Data.PostgreSql.Migrations
{
    public partial class AddAdvertisingWithoutFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_category_category_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropTable(
                name: "cars",
                schema: "public");

            migrationBuilder.AddColumn<Guid>(
                name: "file_id",
                schema: "public",
                table: "users",
                type: "uuid",
                nullable: true,
                comment: "Ид картинки");

            migrationBuilder.AddColumn<Guid>(
                name: "file_id",
                schema: "public",
                table: "shops",
                type: "uuid",
                nullable: true,
                comment: "Ид картинки");

            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                schema: "public",
                table: "files",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "file_id",
                schema: "public",
                table: "categories",
                type: "uuid",
                nullable: true,
                comment: "Ид картинки");

            migrationBuilder.CreateTable(
                name: "advertisements",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    name = table.Column<string>(type: "text", nullable: false, comment: "Наименование рекламы"),
                    route = table.Column<string>(type: "text", nullable: false, comment: "Путь"),
                    file_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Ид картинки"),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_advertisements", x => x.id);
                    table.ForeignKey(
                        name: "fk_advertisements_files_file_id",
                        column: x => x.file_id,
                        principalSchema: "public",
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Рекламы");

            migrationBuilder.CreateIndex(
                name: "ix_users_file_id",
                schema: "public",
                table: "users",
                column: "file_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_shops_file_id",
                schema: "public",
                table: "shops",
                column: "file_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_files_product_id",
                schema: "public",
                table: "files",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_categories_file_id",
                schema: "public",
                table: "categories",
                column: "file_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_advertisements_file_id",
                schema: "public",
                table: "advertisements",
                column: "file_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_categories_files_file_id",
                schema: "public",
                table: "categories",
                column: "file_id",
                principalSchema: "public",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_files_products_product_id",
                schema: "public",
                table: "files",
                column: "product_id",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_products_categories_category_id",
                schema: "public",
                table: "products",
                column: "category_id",
                principalSchema: "public",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_shops_files_file_id",
                schema: "public",
                table: "shops",
                column: "file_id",
                principalSchema: "public",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_users_files_file_id",
                schema: "public",
                table: "users",
                column: "file_id",
                principalSchema: "public",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categories_files_file_id",
                schema: "public",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "fk_files_products_product_id",
                schema: "public",
                table: "files");

            migrationBuilder.DropForeignKey(
                name: "fk_products_categories_category_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "fk_shops_files_file_id",
                schema: "public",
                table: "shops");

            migrationBuilder.DropForeignKey(
                name: "fk_users_files_file_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropTable(
                name: "advertisements",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "ix_users_file_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_shops_file_id",
                schema: "public",
                table: "shops");

            migrationBuilder.DropIndex(
                name: "ix_files_product_id",
                schema: "public",
                table: "files");

            migrationBuilder.DropIndex(
                name: "ix_categories_file_id",
                schema: "public",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "file_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropColumn(
                name: "file_id",
                schema: "public",
                table: "shops");

            migrationBuilder.DropColumn(
                name: "product_id",
                schema: "public",
                table: "files");

            migrationBuilder.DropColumn(
                name: "file_id",
                schema: "public",
                table: "categories");

            migrationBuilder.CreateTable(
                name: "cars",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    brand = table.Column<string>(type: "text", nullable: false),
                    car_info = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    cylinders_count = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cars", x => x.id);
                    table.ForeignKey(
                        name: "fk_cars_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_cars_user_id",
                schema: "public",
                table: "cars",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_products_category_category_id",
                schema: "public",
                table: "products",
                column: "category_id",
                principalSchema: "public",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
