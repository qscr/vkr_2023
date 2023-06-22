using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicStore.Api.Data.PostgreSql.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_categories_category_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_products_category_id",
                schema: "public",
                table: "products");

            migrationBuilder.DropColumn(
                name: "category_id",
                schema: "public",
                table: "products");

            migrationBuilder.CreateTable(
                name: "category_product",
                schema: "public",
                columns: table => new
                {
                    categories_id = table.Column<Guid>(type: "uuid", nullable: false),
                    products_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_product", x => new { x.categories_id, x.products_id });
                    table.ForeignKey(
                        name: "fk_category_product_categories_categories_id",
                        column: x => x.categories_id,
                        principalSchema: "public",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_product_products_products_id",
                        column: x => x.products_id,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_category_product_products_id",
                schema: "public",
                table: "category_product",
                column: "products_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category_product",
                schema: "public");

            migrationBuilder.AddColumn<Guid>(
                name: "category_id",
                schema: "public",
                table: "products",
                type: "uuid",
                nullable: true,
                comment: "Ид категории");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                schema: "public",
                table: "products",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "fk_products_categories_category_id",
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
