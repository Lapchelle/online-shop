using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Persistence.Providers.Postgresql.Migrations
{
    /// <inheritdoc />
    public partial class OnlineShopDbContextPostgresql_v004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Value",
                schema: "ONLINE_SHOP");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                schema: "ONLINE_SHOP",
                table: "Item",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Item_BasketId",
                schema: "ONLINE_SHOP",
                table: "Item",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketEntity_ItemEntity",
                schema: "ONLINE_SHOP",
                table: "Item",
                column: "BasketId",
                principalSchema: "ONLINE_SHOP",
                principalTable: "Basket",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketEntity_ItemEntity",
                schema: "ONLINE_SHOP",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_BasketId",
                schema: "ONLINE_SHOP",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "BasketId",
                schema: "ONLINE_SHOP",
                table: "Item");

            migrationBuilder.CreateTable(
                name: "Value",
                schema: "ONLINE_SHOP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BasketId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
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
    }
}
