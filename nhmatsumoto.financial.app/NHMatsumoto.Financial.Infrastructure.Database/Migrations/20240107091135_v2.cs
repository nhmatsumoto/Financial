using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NHMatsumoto.Financial.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountTableId",
                table: "Costs",
                newName: "WalletId");

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 7, 9, 11, 33, 302, DateTimeKind.Utc).AddTicks(3564));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WalletId",
                table: "Costs",
                newName: "AccountTableId");

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 7, 3, 55, 18, 230, DateTimeKind.Utc).AddTicks(6891));
        }
    }
}
