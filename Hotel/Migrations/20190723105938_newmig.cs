using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class newmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "CheckInTime", "CheckOutTime", "Cost", "IsCanceled", "IsPaid", "RoomId", "UserId" },
                values: new object[] { 1, new DateTime(2019, 7, 20, 2, 49, 42, 898, DateTimeKind.Local).AddTicks(5644), new DateTime(2019, 7, 21, 2, 49, 42, 899, DateTimeKind.Local).AddTicks(9265), 3500, false, true, 1, 3 });
        }
    }
}
