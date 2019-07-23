using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class AddIniitBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "Rights" },
                values: new object[] { 1, "Owner", 2047 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "Rights" },
                values: new object[] { 2, "Admin", 488 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "Rights" },
                values: new object[] { 3, "Visitor", 576 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "ClientID", "Email", "FirstName", "IsDeleted", "LastName", "Phone", "RoleId" },
                values: new object[] { 1, new DateTime(1996, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789012", "Tom@mail.ru", "Tom", false, "Timmi", "8-800-555-35-35", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "ClientID", "Email", "FirstName", "IsDeleted", "LastName", "Phone", "RoleId" },
                values: new object[] { 2, new DateTime(1999, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789013", "Dik@mail.ru", "Dik", false, "Dom", "8-800-555-35-36", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "ClientID", "Email", "FirstName", "IsDeleted", "LastName", "Phone", "RoleId" },
                values: new object[] { 3, new DateTime(1986, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789014", "Jorge@mail.ru", "Jorge", false, "Vim", "8-800-555-35-37", 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
