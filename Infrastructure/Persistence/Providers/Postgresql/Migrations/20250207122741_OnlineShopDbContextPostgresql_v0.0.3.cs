using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Persistence.Providers.Postgresql.Migrations
{
    /// <inheritdoc />
    public partial class OnlineShopDbContextPostgresql_v003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TypesId",
                schema: "ONLINE_SHOP",
                table: "Item",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Item_TypesId",
                schema: "ONLINE_SHOP",
                table: "Item",
                column: "TypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Type_TypesId",
                schema: "ONLINE_SHOP",
                table: "Item",
                column: "TypesId",
                principalSchema: "ONLINE_SHOP",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Type_TypesId",
                schema: "ONLINE_SHOP",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_TypesId",
                schema: "ONLINE_SHOP",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "TypesId",
                schema: "ONLINE_SHOP",
                table: "Item");
        }
    }
}
