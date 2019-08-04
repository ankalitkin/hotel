using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class Update_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { "2", false, "480", 4 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { "2", false, "976", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { "6", false, "650a", 4 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                columns: new[] { "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "883", 3, 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5,
                columns: new[] { "Floor", "HasMiniBar", "Name", "RoomTypeId" },
                values: new object[] { "2", true, "837", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 6,
                columns: new[] { "Floor", "HasMiniBar", "Name", "RoomTypeId" },
                values: new object[] { "1", false, "853", 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 7,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { "5", true, "193a", 4 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 8,
                columns: new[] { "Floor", "Name", "NumberOfSeats" },
                values: new object[] { "6", "387", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 9,
                columns: new[] { "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { false, "677b", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 10,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "4", true, "990", 3, 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 11,
                columns: new[] { "Floor", "HasMiniBar", "Name" },
                values: new object[] { "1", false, "570" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 12,
                columns: new[] { "Floor", "Name" },
                values: new object[] { "6", "188b" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 13,
                columns: new[] { "Floor", "HasMiniBar", "Name" },
                values: new object[] { "Подвал", false, "751a" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 14,
                columns: new[] { "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "878", 3, 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 15,
                columns: new[] { "Floor", "HasMiniBar", "Name" },
                values: new object[] { "1", false, "665" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 16,
                columns: new[] { "Floor", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "2", "861", 4, 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 17,
                columns: new[] { "Floor", "Name", "NumberOfSeats" },
                values: new object[] { "3", "207b", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 18,
                columns: new[] { "Floor", "Name" },
                values: new object[] { "2", "799b" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 19,
                columns: new[] { "Floor", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "2", "834", 1, 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 20,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "Подвал", true, "787", 3, 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 21,
                columns: new[] { "Floor", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "7", "154", 1, 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 22,
                columns: new[] { "HasMiniBar", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { false, "749", 1, 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 23,
                columns: new[] { "Floor", "HasMiniBar", "Name" },
                values: new object[] { "2", true, "973" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 24,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { "6", false, "335b", 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 25,
                columns: new[] { "Floor", "Name", "NumberOfSeats" },
                values: new object[] { "4", "476", 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 26,
                columns: new[] { "Floor", "Name", "NumberOfSeats" },
                values: new object[] { "5", "954", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 27,
                columns: new[] { "Name", "NumberOfSeats" },
                values: new object[] { "251", 4 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 28,
                columns: new[] { "Floor", "Name", "RoomTypeId" },
                values: new object[] { "Подвал", "482", 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 5, 19, 45, 57, 463, DateTimeKind.Local).AddTicks(7250), new DateTime(2019, 8, 20, 19, 45, 57, 463, DateTimeKind.Local).AddTicks(7250), 5000, true, 25, 15 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId" },
                values: new object[] { new DateTime(2019, 8, 1, 19, 45, 57, 480, DateTimeKind.Local).AddTicks(2312), new DateTime(2019, 8, 6, 19, 45, 57, 480, DateTimeKind.Local).AddTicks(2312), 7200, false, 5 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 14, 19, 45, 57, 480, DateTimeKind.Local).AddTicks(9690), new DateTime(2019, 8, 21, 19, 45, 57, 480, DateTimeKind.Local).AddTicks(9690), 4000, true, 18, 2 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 11, 19, 45, 57, 480, DateTimeKind.Local).AddTicks(9941), new DateTime(2019, 8, 25, 19, 45, 57, 480, DateTimeKind.Local).AddTicks(9941), 6200, 23, 12 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 29, 19, 45, 57, 480, DateTimeKind.Local).AddTicks(9992), new DateTime(2019, 8, 1, 19, 45, 57, 480, DateTimeKind.Local).AddTicks(9992), 5000, 11, 16 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 6,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 4, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(38), new DateTime(2019, 8, 16, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(38), 5000, true, 24, 17 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 7,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 28, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(271), new DateTime(2019, 7, 30, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(271), 3700, false, 13, 7 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 8,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 26, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(306), new DateTime(2019, 8, 5, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(306), 3000, false, 22, 15 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 9,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 27, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(340), new DateTime(2019, 8, 8, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(340), 8200, 3, 1 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 10,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 31, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(386), new DateTime(2019, 8, 10, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(386), 3000, false, 8, 12 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 11,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 31, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(420), new DateTime(2019, 8, 5, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(420), 6000, 28, 11 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 12,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 26, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(465), new DateTime(2019, 7, 28, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(465), 4200, false, 1, 14 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 13,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 27, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(500), new DateTime(2019, 8, 10, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(500), 4000, 15, 4 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 14,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 30, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(676), new DateTime(2019, 8, 14, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(676), 3000, false, 21, 11 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 15,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 27, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(722), new DateTime(2019, 8, 11, 19, 45, 57, 481, DateTimeKind.Local).AddTicks(722), 6800, 7, 14 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2003, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "202912990595", "Егор@mail.ru", "Егор", "Горбенко", "1234567890", "2-5230-9099-5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(1998, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "535522516768", "Егор@mail.ru", "Егор", "Смирнов", "1234567890", "9-1458-8310-4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2016, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "863179925593", "Никита@mail.ru", "Никита", "Горбенко", "1234567890", "0-4234-6362-0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2004, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "308672635362", "Алексей@mail.ru", "Алексей", "Ускова", "1234567890", "3-4684-1946-8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2015, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "268798163381", "Илья@mail.ru", "Илья", "Горбенко", "1234567890", "7-6639-6039-0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2003, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "420712686558", "Роман@mail.ru", "Роман", "Астахов", "1234567890", "2-0847-1469-7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2007, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "629288080461", "Роман@mail.ru", "Роман", "Комаров", "1234567890", "4-5650-6090-7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(1995, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "671914290507", "Ксения@mail.ru", "Ксения", "Ситников", "1234567890", "1-2918-4429-3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2012, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "307221998108", "Юлия@mail.ru", "Юлия", "Ускова", "1234567890", "5-9518-3655-8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2018, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "580109150835", "Ксения@mail.ru", "Ксения", "Горбенко", "1234567890", "3-1859-3614-2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2004, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "179546929729", "Екатерина@mail.ru", "Екатерина", "Астахов", "1234567890", "0-7766-6962-4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2000, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "684865286822", "Анастасия@mail.ru", "Анастасия", "Ускова", "1234567890", "8-3815-8311-8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(1998, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "315658677874", "Ксения@mail.ru", "Ксения", "Смирнов", "1234567890", "3-2801-1884-7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14,
                columns: new[] { "BirthDate", "ClientId", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(1999, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "650067000347", "Поляков", "1234567890", "0-0109-6329-2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                columns: new[] { "BirthDate", "ClientId", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "077419854825", "Ситников", "1234567890", "5-4273-9758-1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(1998, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "215639029502", "Екатерина@mail.ru", "Екатерина", "Воробьев", "1234567890", "7-4497-2800-4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2005, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "425182779873", "Юлия@mail.ru", "Юлия", "Горбенко", "1234567890", "5-2727-9715-6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "017244999864", "Ксения@mail.ru", "Ксения", "Ситников", "1234567890", "1-3741-4755-2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2004, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "606416709709", "Илья@mail.ru", "Илья", "Ситников", "1234567890", "3-5606-2263-5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { "3", true, "490", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { "1", true, "852", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { "5", true, "518b", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                columns: new[] { "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "633", 2, 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5,
                columns: new[] { "Floor", "HasMiniBar", "Name", "RoomTypeId" },
                values: new object[] { "4", false, "320", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 6,
                columns: new[] { "Floor", "HasMiniBar", "Name", "RoomTypeId" },
                values: new object[] { "4", true, "553b", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 7,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { "Подвал", false, "760", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 8,
                columns: new[] { "Floor", "Name", "NumberOfSeats" },
                values: new object[] { "4", "742", 4 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 9,
                columns: new[] { "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { true, "578", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 10,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "5", false, "594", 4, 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 11,
                columns: new[] { "Floor", "HasMiniBar", "Name" },
                values: new object[] { "4", true, "144b" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 12,
                columns: new[] { "Floor", "Name" },
                values: new object[] { "4", "388b" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 13,
                columns: new[] { "Floor", "HasMiniBar", "Name" },
                values: new object[] { "4", true, "658a" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 14,
                columns: new[] { "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "111", 1, 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 15,
                columns: new[] { "Floor", "HasMiniBar", "Name" },
                values: new object[] { "3", true, "215" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 16,
                columns: new[] { "Floor", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "3", "682", 1, 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 17,
                columns: new[] { "Floor", "Name", "NumberOfSeats" },
                values: new object[] { "5", "705", 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 18,
                columns: new[] { "Floor", "Name" },
                values: new object[] { "1", "910b" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 19,
                columns: new[] { "Floor", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "4", "761a", 3, 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 20,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "2", false, "947", 1, 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 21,
                columns: new[] { "Floor", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { "3", "787a", 2, 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 22,
                columns: new[] { "HasMiniBar", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[] { true, "793", 4, 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 23,
                columns: new[] { "Floor", "HasMiniBar", "Name" },
                values: new object[] { "7", false, "406" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 24,
                columns: new[] { "Floor", "HasMiniBar", "Name", "NumberOfSeats" },
                values: new object[] { "7", true, "297", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 25,
                columns: new[] { "Floor", "Name", "NumberOfSeats" },
                values: new object[] { "7", "751", 3 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 26,
                columns: new[] { "Floor", "Name", "NumberOfSeats" },
                values: new object[] { "3", "459", 4 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 27,
                columns: new[] { "Name", "NumberOfSeats" },
                values: new object[] { "807", 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 28,
                columns: new[] { "Floor", "Name", "RoomTypeId" },
                values: new object[] { "1", "933", 2 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 30, 19, 41, 54, 214, DateTimeKind.Local).AddTicks(8233), new DateTime(2019, 8, 11, 19, 41, 54, 214, DateTimeKind.Local).AddTicks(8233), 8300, false, 24, 4 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId" },
                values: new object[] { new DateTime(2019, 8, 6, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(1667), new DateTime(2019, 8, 7, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(1667), 5000, true, 20 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 25, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8417), new DateTime(2019, 8, 1, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8417), 6000, false, 17, 15 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 9, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8634), new DateTime(2019, 8, 24, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8634), 6800, 11, 2 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 31, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8691), new DateTime(2019, 8, 6, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8691), 10000, 22, 8 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 6,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 1, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8748), new DateTime(2019, 8, 2, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8748), 4000, false, 28, 10 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 7,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 6, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8788), new DateTime(2019, 8, 10, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8788), 5500, true, 2, 19 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 8,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 6, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8970), new DateTime(2019, 8, 19, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8970), 5500, true, 15, 12 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 9,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 2, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9016), new DateTime(2019, 8, 12, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9016), 4500, 27, 14 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 10,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 14, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9062), new DateTime(2019, 8, 23, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9062), 5700, true, 13, 16 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 11,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 27, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9096), new DateTime(2019, 8, 1, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9096), 5500, 2, 12 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 12,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 14, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9136), new DateTime(2019, 8, 26, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9136), 2000, true, 16, 6 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 13,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 26, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9170), new DateTime(2019, 8, 5, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9170), 2000, 16, 12 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 14,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "IsPaid", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 14, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9210), new DateTime(2019, 8, 18, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9210), 7200, true, 6, 5 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 15,
                columns: new[] { "CheckInTime", "CheckOutTime", "Cost", "RoomId", "UserId" },
                values: new object[] { new DateTime(2019, 7, 30, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9364), new DateTime(2019, 8, 5, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9364), 4200, 8, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(1997, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "947422130074", "Екатерина@mail.ru", "Екатерина", "Поляков", null, "8-6127-3235-4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2010, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "643216450346", "Юлия@mail.ru", "Юлия", "Поляков", null, "1-8474-6412-5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(1998, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "585085248587", "Ксения@mail.ru", "Ксения", "Ситников", null, "6-7623-3996-6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2004, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "879926475578", "Илья@mail.ru", "Илья", "Горбенко", null, "2-9691-5825-7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2013, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "430406693983", "Михаил@mail.ru", "Михаил", "Ситников", null, "1-1053-9678-0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2016, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "376272908834", "Михаил@mail.ru", "Михаил", "Комаров", null, "3-9535-3541-9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2016, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "913268994689", "Алексей@mail.ru", "Алексей", "Смирнов", null, "1-8029-8747-9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2011, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "541116392716", "Екатерина@mail.ru", "Екатерина", "Смирнов", null, "8-2685-9694-4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2018, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "505103188138", "Анастасия@mail.ru", "Анастасия", "Ситников", null, "3-5880-1145-1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(1996, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "481423950557", "Екатерина@mail.ru", "Екатерина", "Иванов", null, "5-0475-2448-2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2005, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "167091679659", "Анастасия@mail.ru", "Анастасия", "Ситников", null, "9-7095-5747-4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2015, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "444376330172", "Михаил@mail.ru", "Михаил", "Смирнов", null, "4-2785-7233-5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2005, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "206278334461", "Роман@mail.ru", "Роман", "Воробьев", null, "9-0948-9341-1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14,
                columns: new[] { "BirthDate", "ClientId", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(1995, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "738461021557", "Ситников", null, "2-6341-1764-5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                columns: new[] { "BirthDate", "ClientId", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2001, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "390095416955", "Поляков", null, "3-8167-7674-6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2002, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "259681638220", "Ксения@mail.ru", "Ксения", "Ускова", null, "6-8264-4511-7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2019, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "830028883794", "Егор@mail.ru", "Егор", "Ситников", null, "1-5437-8933-0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2016, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "807493266975", "Михаил@mail.ru", "Михаил", "Ускова", null, "8-1050-6616-2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "BirthDate", "ClientId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new DateTime(2004, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "687232237370", "Алексей@mail.ru", "Алексей", "Комаров", null, "4-1940-7054-8" });
        }
    }
}
