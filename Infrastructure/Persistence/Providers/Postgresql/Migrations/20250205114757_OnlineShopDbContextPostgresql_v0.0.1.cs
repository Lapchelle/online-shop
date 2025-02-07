using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Persistence.Providers.Postgresql.Migrations
{
    /// <inheritdoc />
    public partial class OnlineShopDbContextPostgresql_v001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ONLINE_SHOP");

            migrationBuilder.CreateTable(
                name: "Basket",
                schema: "ONLINE_SHOP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "ONLINE_SHOP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "ONLINE_SHOP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    BasketId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Basket_BasketId",
                        column: x => x.BasketId,
                        principalSchema: "ONLINE_SHOP",
                        principalTable: "Basket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Value",
                schema: "ONLINE_SHOP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    BasketId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Value", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketEntity_ValueEntity",
                        column: x => x.BasketId,
                        principalSchema: "ONLINE_SHOP",
                        principalTable: "Basket",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Value_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "ONLINE_SHOP",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "BasketId_Index",
                schema: "ONLINE_SHOP",
                table: "User",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "ItemId_Index",
                schema: "ONLINE_SHOP",
                table: "Value",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Value_BasketId",
                schema: "ONLINE_SHOP",
                table: "Value",
                column: "BasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "ONLINE_SHOP");

            migrationBuilder.DropTable(
                name: "Value",
                schema: "ONLINE_SHOP");

            migrationBuilder.DropTable(
                name: "Basket",
                schema: "ONLINE_SHOP");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "ONLINE_SHOP");
        }
    }
}
