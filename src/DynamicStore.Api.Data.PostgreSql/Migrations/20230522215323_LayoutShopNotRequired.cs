using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicStore.Api.Data.PostgreSql.Migrations
{
    public partial class LayoutShopNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "shop_id",
                schema: "public",
                table: "layouts",
                type: "uuid",
                nullable: true,
                comment: "Ид магазина",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Ид магазина");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "shop_id",
                schema: "public",
                table: "layouts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Ид магазина",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldComment: "Ид магазина");
        }
    }
}
