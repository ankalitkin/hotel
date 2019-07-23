using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class SomeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "Transactions",
                newName: "TransactionId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Transactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                columns: new[] { "CheckInTime", "CheckOutTime" },
                values: new object[] { new DateTime(2019, 7, 20, 2, 49, 42, 898, DateTimeKind.Local).AddTicks(5644), new DateTime(2019, 7, 21, 2, 49, 42, 899, DateTimeKind.Local).AddTicks(9265) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "TransactionID");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 1,
                columns: new[] { "CheckInTime", "CheckOutTime" },
                values: new object[] { new DateTime(2019, 7, 13, 13, 10, 57, 830, DateTimeKind.Local).AddTicks(8338), new DateTime(2019, 7, 14, 13, 10, 57, 840, DateTimeKind.Local).AddTicks(6386) });
        }
    }
}
