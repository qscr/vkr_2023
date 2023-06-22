using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicStore.Api.Data.PostgreSql.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    code = table.Column<string>(type: "text", nullable: false, comment: "Код категории"),
                    name = table.Column<string>(type: "text", nullable: false, comment: "Наименование категории"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "Описание категории"),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                },
                comment: "Категории товаров");

            migrationBuilder.CreateTable(
                name: "files",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    address = table.Column<string>(type: "text", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false),
                    content_type = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_files", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    cylinders_count = table.Column<int>(type: "integer", nullable: false),
                    brand = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    car_info = table.Column<string>(type: "jsonb", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "layouts",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    active_from = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата активации дизайна"),
                    layout_design = table.Column<string>(type: "jsonb", nullable: false, comment: "Дизайн страницы"),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Ид магазина"),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_layouts", x => x.id);
                },
                comment: "Дизайны страничек магазинов");

            migrationBuilder.CreateTable(
                name: "order_products",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Ид заказа"),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Ид товара"),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_products", x => x.id);
                },
                comment: "Товары из заказов");

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    quantity = table.Column<int>(type: "integer", nullable: false, comment: "Количество товаров"),
                    total_price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Общая стоимость"),
                    is_payed = table.Column<bool>(type: "boolean", nullable: false, comment: "Оплачен ли заказ"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Пользователь"),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                },
                comment: "Заказы");

            migrationBuilder.CreateTable(
                name: "products",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    name = table.Column<string>(type: "text", nullable: false, comment: "Наименование товара"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "Описание товара"),
                    price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Цена товара"),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Ид магазина"),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Ид категории"),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "public",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Товары");

            migrationBuilder.CreateTable(
                name: "shops",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    name = table.Column<string>(type: "text", nullable: false, comment: "Наименование магазина"),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Ид владельца"),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shops", x => x.id);
                },
                comment: "Магазины");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_in(md5(random()::text || clock_timestamp()::text)::cstring)"),
                    name = table.Column<string>(type: "text", nullable: false, comment: "Имя пользователя"),
                    email = table.Column<string>(type: "text", nullable: false, comment: "Email"),
                    password_hash = table.Column<string>(type: "text", nullable: false, comment: "Хэш пароля"),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "Ид магазина"),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_shops_shop_id",
                        column: x => x.shop_id,
                        principalSchema: "public",
                        principalTable: "shops",
                        principalColumn: "id");
                },
                comment: "Пользователи");

            migrationBuilder.CreateIndex(
                name: "ix_cars_user_id",
                schema: "public",
                table: "cars",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_layouts_shop_id",
                schema: "public",
                table: "layouts",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_products_order_id",
                schema: "public",
                table: "order_products",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_products_product_id",
                schema: "public",
                table: "order_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_user_id",
                schema: "public",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                schema: "public",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_shop_id",
                schema: "public",
                table: "products",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "ix_shops_owner_id",
                schema: "public",
                table: "shops",
                column: "owner_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_shop_id",
                schema: "public",
                table: "users",
                column: "shop_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_cars_users_user_id",
                schema: "public",
                table: "cars",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_layouts_shops_shop_id",
                schema: "public",
                table: "layouts",
                column: "shop_id",
                principalSchema: "public",
                principalTable: "shops",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_order_products_orders_order_id",
                schema: "public",
                table: "order_products",
                column: "order_id",
                principalSchema: "public",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_order_products_products_product_id",
                schema: "public",
                table: "order_products",
                column: "product_id",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_users_user_id",
                schema: "public",
                table: "orders",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_products_shops_shop_id",
                schema: "public",
                table: "products",
                column: "shop_id",
                principalSchema: "public",
                principalTable: "shops",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_shops_users_owner_id1",
                schema: "public",
                table: "shops",
                column: "owner_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_shops_users_owner_id1",
                schema: "public",
                table: "shops");

            migrationBuilder.DropTable(
                name: "cars",
                schema: "public");

            migrationBuilder.DropTable(
                name: "files",
                schema: "public");

            migrationBuilder.DropTable(
                name: "layouts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "order_products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "shops",
                schema: "public");
        }
    }
}
