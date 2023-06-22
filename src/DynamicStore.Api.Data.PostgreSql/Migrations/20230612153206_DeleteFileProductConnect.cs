using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicStore.Api.Data.PostgreSql.Migrations
{
    public partial class DeleteFileProductConnect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_files_products_product_id",
                schema: "public",
                table: "files");

            migrationBuilder.AddForeignKey(
                name: "fk_files_products_product_id",
                schema: "public",
                table: "files",
                column: "product_id",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_files_products_product_id",
                schema: "public",
                table: "files");

            migrationBuilder.AddForeignKey(
                name: "fk_files_products_product_id",
                schema: "public",
                table: "files",
                column: "product_id",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
