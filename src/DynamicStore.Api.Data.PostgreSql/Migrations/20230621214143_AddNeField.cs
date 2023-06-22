using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicStore.Api.Data.PostgreSql.Migrations
{
    public partial class AddNeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "key",
                schema: "public",
                table: "categories",
                type: "uuid",
                nullable: true,
                comment: "Ключ");

            migrationBuilder.AddColumn<Guid>(
                name: "key",
                schema: "public",
                table: "advertisements",
                type: "uuid",
                nullable: true,
                comment: "Ключ");

            migrationBuilder.AddColumn<Guid>(
                name: "shop_id",
                schema: "public",
                table: "advertisements",
                type: "uuid",
                nullable: true,
                comment: "Ид магазина");

            migrationBuilder.CreateIndex(
                name: "ix_advertisements_shop_id",
                schema: "public",
                table: "advertisements",
                column: "shop_id");

            migrationBuilder.AddForeignKey(
                name: "fk_advertisements_shops_shop_id",
                schema: "public",
                table: "advertisements",
                column: "shop_id",
                principalSchema: "public",
                principalTable: "shops",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_advertisements_shops_shop_id",
                schema: "public",
                table: "advertisements");

            migrationBuilder.DropIndex(
                name: "ix_advertisements_shop_id",
                schema: "public",
                table: "advertisements");

            migrationBuilder.DropColumn(
                name: "key",
                schema: "public",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "key",
                schema: "public",
                table: "advertisements");

            migrationBuilder.DropColumn(
                name: "shop_id",
                schema: "public",
                table: "advertisements");
        }
    }
}
