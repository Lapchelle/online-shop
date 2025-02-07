using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Persistence.Providers.Postgresql.Migrations
{
    /// <inheritdoc />
    public partial class OnlineShopDbContextPostgresql_v002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RolesId",
                schema: "ONLINE_SHOP",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "ONLINE_SHOP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                schema: "ONLINE_SHOP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RolesId",
                schema: "ONLINE_SHOP",
                table: "User",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "RoleId_Index",
                schema: "ONLINE_SHOP",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "TypeId_Index",
                schema: "ONLINE_SHOP",
                table: "Item",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Roles_RolesId",
                schema: "ONLINE_SHOP",
                table: "User",
                column: "RolesId",
                principalSchema: "ONLINE_SHOP",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Roles_RolesId",
                schema: "ONLINE_SHOP",
                table: "User");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "ONLINE_SHOP");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "ONLINE_SHOP");

            migrationBuilder.DropIndex(
                name: "IX_User_RolesId",
                schema: "ONLINE_SHOP",
                table: "User");

            migrationBuilder.DropIndex(
                name: "RoleId_Index",
                schema: "ONLINE_SHOP",
                table: "User");

            migrationBuilder.DropIndex(
                name: "TypeId_Index",
                schema: "ONLINE_SHOP",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RolesId",
                schema: "ONLINE_SHOP",
                table: "User");
        }
    }
}
