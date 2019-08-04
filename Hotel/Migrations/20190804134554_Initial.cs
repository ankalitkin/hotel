using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rights = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RoomCosts",
                columns: table => new
                {
                    RoomCostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    HasMiniBar = table.Column<bool>(nullable: false),
                    Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCosts", x => x.RoomCostId);
                    table.ForeignKey(
                        name: "FK_RoomCosts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    RoomTypeId = table.Column<int>(nullable: false),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    HasMiniBar = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Categories_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(maxLength: 12, nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckInTime = table.Column<DateTime>(nullable: false),
                    CheckOutTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    IsCanceled = table.Column<bool>(nullable: false),
                    isEvicted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Economy" },
                    { 2, "Ordinary" },
                    { 3, "Lux" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "Rights" },
                values: new object[,]
                {
                    { 1, "Владелец", 2047 },
                    { 2, "Администратор", 488 },
                    { 3, "Посетитель", 2624 }
                });

            migrationBuilder.InsertData(
                table: "RoomCosts",
                columns: new[] { "RoomCostId", "CategoryId", "Cost", "HasMiniBar", "NumberOfSeats" },
                values: new object[,]
                {
                    { 16, 2, 6800, true, 4 },
                    { 10, 2, 4000, false, 2 },
                    { 9, 2, 3000, false, 1 },
                    { 13, 2, 4500, true, 1 },
                    { 14, 2, 5500, true, 2 },
                    { 15, 2, 6300, true, 3 },
                    { 8, 1, 6200, true, 4 },
                    { 11, 2, 5700, false, 3 },
                    { 6, 1, 4000, true, 2 },
                    { 5, 1, 3000, true, 1 },
                    { 4, 1, 4200, false, 4 },
                    { 7, 1, 5700, true, 3 },
                    { 2, 1, 3000, false, 2 },
                    { 24, 3, 10000, true, 4 },
                    { 23, 3, 8300, true, 3 },
                    { 22, 3, 7200, true, 2 },
                    { 21, 3, 6800, true, 1 },
                    { 20, 3, 8200, false, 4 },
                    { 3, 1, 3700, false, 3 },
                    { 12, 2, 6200, false, 4 },
                    { 19, 3, 7700, false, 3 },
                    { 18, 3, 6000, false, 2 },
                    { 17, 3, 5000, false, 1 },
                    { 1, 1, 2000, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Floor", "HasMiniBar", "IsDeleted", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[,]
                {
                    { 18, "6", true, false, "982", 2, 3 },
                    { 26, "7", false, false, "472a", 2, 3 },
                    { 6, "2", false, false, "226", 2, 3 },
                    { 5, "3", true, false, "281", 2, 3 },
                    { 3, "1", true, false, "346a", 2, 3 },
                    { 28, "5", true, false, "827", 2, 3 },
                    { 20, "1", true, false, "339", 2, 3 },
                    { 12, "5", true, false, "702b", 2, 3 },
                    { 1, "5", true, false, "607", 2, 1 },
                    { 24, "5", true, false, "537", 2, 2 },
                    { 25, "3", true, false, "657", 2, 2 },
                    { 10, "1", false, false, "598", 2, 1 },
                    { 11, "6", true, false, "773a", 2, 1 },
                    { 17, "1", true, false, "849a", 2, 1 },
                    { 21, "6", true, false, "316a", 2, 1 },
                    { 22, "7", false, false, "730", 2, 1 },
                    { 23, "Подвал", false, false, "373a", 2, 1 },
                    { 27, "4", true, false, "164b", 2, 1 },
                    { 2, "7", true, false, "199", 2, 2 },
                    { 8, "3", false, false, "173", 2, 1 },
                    { 7, "5", true, false, "987b", 2, 2 },
                    { 9, "4", false, false, "202", 2, 2 },
                    { 13, "5", false, false, "636", 2, 2 },
                    { 14, "2", false, false, "132", 2, 2 },
                    { 15, "5", true, false, "157a", 2, 2 },
                    { 16, "1", true, false, "821", 2, 2 },
                    { 19, "7", true, false, "823", 2, 2 },
                    { 4, "7", false, false, "498", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "ClientId", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 17, new DateTime(2005, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "675572176210", "Михаил@mail.ru", "Михаил", false, "Ситников", null, "2-3239-9721-1", 3 },
                    { 16, new DateTime(2005, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "340236898097", "Никита@mail.ru", "Никита", false, "Сидоров", null, "1-7991-9761-2", 3 },
                    { 15, new DateTime(2001, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "979965020133", "Егор@mail.ru", "Егор", false, "Смирнов", null, "2-8652-4647-6", 3 },
                    { 14, new DateTime(2007, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "227507737035", "Юлия@mail.ru", "Юлия", false, "Горбенко", null, "4-0245-2164-7", 3 },
                    { 13, new DateTime(1997, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "666846064181", "Никита@mail.ru", "Никита", false, "Астахов", null, "5-3421-0044-9", 3 },
                    { 12, new DateTime(2015, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "718770209925", "Никита@mail.ru", "Никита", false, "Иванов", null, "7-2353-5696-0", 3 },
                    { 11, new DateTime(2016, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "302499036571", "Илья@mail.ru", "Илья", false, "Астахов", null, "1-1737-9021-0", 3 },
                    { 10, new DateTime(2019, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "052023867167", "Илья@mail.ru", "Илья", false, "Астахов", null, "3-7752-9924-6", 3 },
                    { 6, new DateTime(2007, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "911192927508", "Михаил@mail.ru", "Михаил", false, "Иванов", null, "0-2354-1178-2", 3 },
                    { 8, new DateTime(2012, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "162609533153", "Никита@mail.ru", "Никита", false, "Комаров", null, "3-3774-2533-2", 3 },
                    { 7, new DateTime(2000, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "775822177981", "Екатерина@mail.ru", "Екатерина", false, "Воробьев", null, "2-9542-2968-7", 3 },
                    { 5, new DateTime(2005, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "485980336925", "Никита@mail.ru", "Никита", false, "Иванов", null, "7-4938-0013-3", 3 },
                    { 4, new DateTime(1995, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "306198468252", "Егор@mail.ru", "Егор", false, "Ускова", null, "3-3020-4140-9", 3 },
                    { 3, new DateTime(2005, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "283522163358", "Алексей@mail.ru", "Алексей", false, "Астахов", null, "9-3937-7989-2", 2 },
                    { 2, new DateTime(2019, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "736043575691", "Юлия@mail.ru", "Юлия", false, "Горбенко", null, "5-5148-6909-7", 2 },
                    { 1, new DateTime(2014, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "226119533390", "Егор@mail.ru", "Егор", false, "Астахов", null, "7-5897-7074-8", 1 },
                    { 18, new DateTime(2007, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "553236190792", "Илья@mail.ru", "Илья", false, "Комаров", null, "5-3244-3375-9", 3 },
                    { 9, new DateTime(2003, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "928352315168", "Алексей@mail.ru", "Алексей", false, "Сидоров", null, "8-1913-0886-9", 3 },
                    { 19, new DateTime(2015, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "548672906167", "Алексей@mail.ru", "Алексей", false, "Воробьев", null, "8-9782-2358-3", 3 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "CheckInTime", "CheckOutTime", "Cost", "IsCanceled", "IsPaid", "RoomId", "UserId", "isEvicted" },
                values: new object[,]
                {
                    { 4, new DateTime(2019, 7, 25, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(4587), new DateTime(2019, 7, 31, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(4587), 4000, false, false, 14, 1, false },
                    { 7, new DateTime(2019, 7, 25, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6227), new DateTime(2019, 7, 27, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6227), 4000, false, false, 13, 2, false },
                    { 15, new DateTime(2019, 8, 2, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6557), new DateTime(2019, 8, 11, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6557), 3000, false, false, 10, 3, false },
                    { 13, new DateTime(2019, 7, 28, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6501), new DateTime(2019, 8, 2, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6501), 4000, false, false, 27, 4, false },
                    { 3, new DateTime(2019, 8, 6, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(4345), new DateTime(2019, 8, 8, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(4345), 5500, false, true, 19, 6, false },
                    { 6, new DateTime(2019, 8, 11, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6182), new DateTime(2019, 8, 20, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6182), 5500, false, true, 25, 6, false },
                    { 14, new DateTime(2019, 8, 12, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6530), new DateTime(2019, 8, 19, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6530), 4000, false, true, 17, 8, false },
                    { 1, new DateTime(2019, 7, 25, 16, 45, 54, 174, DateTimeKind.Local).AddTicks(5096), new DateTime(2019, 8, 5, 16, 45, 54, 174, DateTimeKind.Local).AddTicks(5096), 7200, false, false, 12, 9, false },
                    { 11, new DateTime(2019, 8, 14, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6441), new DateTime(2019, 8, 26, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6441), 5500, false, true, 24, 10, false },
                    { 10, new DateTime(2019, 7, 28, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6340), new DateTime(2019, 7, 30, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6340), 4000, false, false, 21, 13, false },
                    { 2, new DateTime(2019, 8, 9, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(495), new DateTime(2019, 8, 12, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(495), 7200, false, true, 18, 15, false },
                    { 9, new DateTime(2019, 8, 12, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6308), new DateTime(2019, 8, 27, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6308), 6000, false, true, 26, 15, false },
                    { 5, new DateTime(2019, 8, 8, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6151), new DateTime(2019, 8, 18, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6151), 3000, false, true, 22, 17, false },
                    { 8, new DateTime(2019, 8, 2, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6250), new DateTime(2019, 8, 8, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6250), 6000, false, false, 6, 17, false },
                    { 12, new DateTime(2019, 8, 8, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6472), new DateTime(2019, 8, 9, 16, 45, 54, 182, DateTimeKind.Local).AddTicks(6472), 5500, false, true, 16, 17, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomCosts_CategoryId",
                table: "RoomCosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RoomId",
                table: "Transactions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomCosts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
