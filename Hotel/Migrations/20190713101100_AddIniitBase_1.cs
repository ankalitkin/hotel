using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class AddIniitBase_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomCosts_Categories_CategoryId",
                table: "RoomCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Categories_RoomTypeCategoryId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Rooms_RoomId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeCategoryId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomTypeCategoryId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "RoomCostID",
                table: "RoomCosts",
                newName: "RoomCostId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "RoomCosts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 1, "Economy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 2, "Ordinary" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 3, "Lux" });

            migrationBuilder.InsertData(
                table: "RoomCosts",
                columns: new[] { "RoomCostId", "CategoryId", "Cost", "HasMiniBar", "NumberOfSeats" },
                values: new object[,]
                {
                    { 1, 1, 3500, false, 2 },
                    { 2, 2, 5200, false, 3 },
                    { 3, 3, 11700, true, 2 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Floor", "HasMiniBar", "IsDeleted", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, "Подвал", false, false, "101", 2, 1 },
                    { 2, "3", false, false, "121", 3, 2 },
                    { 3, "12", true, false, "14a", 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { 1, new DateTime(2019, 7, 13, 13, 10, 57, 830, DateTimeKind.Local).AddTicks(8338), new DateTime(2019, 7, 14, 13, 10, 57, 840, DateTimeKind.Local).AddTicks(6386), 3500, true, 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCosts_Categories_CategoryId",
                table: "RoomCosts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Categories_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Rooms_RoomId",
                table: "Transactions",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomCosts_Categories_CategoryId",
                table: "RoomCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Categories_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Rooms_RoomId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "RoomCosts",
                keyColumn: "RoomCostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomCosts",
                keyColumn: "RoomCostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomCosts",
                keyColumn: "RoomCostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "RoomCostId",
                table: "RoomCosts",
                newName: "RoomCostID");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeCategoryId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "RoomCosts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeCategoryId",
                table: "Rooms",
                column: "RoomTypeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCosts_Categories_CategoryId",
                table: "RoomCosts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Categories_RoomTypeCategoryId",
                table: "Rooms",
                column: "RoomTypeCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Rooms_RoomId",
                table: "Transactions",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
