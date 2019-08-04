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
                    { 1, "Эконом" },
                    { 2, "Стандарт" },
                    { 3, "Люкс" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "Rights" },
                values: new object[,]
                {
                    { 1, "Владелец", 1471 },
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
                    { 7, 1, 5700, true, 3 },
                    { 6, 1, 4000, true, 2 },
                    { 11, 2, 5700, false, 3 },
                    { 4, 1, 4200, false, 4 },
                    { 3, 1, 3700, false, 3 },
                    { 5, 1, 3000, true, 1 },
                    { 1, 1, 2000, false, 1 },
                    { 24, 3, 10000, true, 4 },
                    { 23, 3, 8300, true, 3 },
                    { 22, 3, 7200, true, 2 },
                    { 21, 3, 6800, true, 1 },
                    { 20, 3, 8200, false, 4 },
                    { 2, 1, 3000, false, 2 },
                    { 12, 2, 6200, false, 4 },
                    { 19, 3, 7700, false, 3 },
                    { 18, 3, 6000, false, 2 },
                    { 17, 3, 5000, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Floor", "HasMiniBar", "IsDeleted", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[,]
                {
                    { 10, "5", false, false, "123", 2, 3 },
                    { 22, "5", true, false, "622", 3, 3 },
                    { 4, "2", false, false, "935", 3, 3 },
                    { 3, "5", true, false, "263", 2, 3 },
                    { 28, "1", false, false, "534b", 3, 3 },
                    { 23, "Подвал", false, false, "403a", 4, 3 },
                    { 11, "4", false, false, "789", 4, 3 },
                    { 7, "7", false, false, "582", 3, 3 },
                    { 1, "3", true, false, "655b", 4, 1 },
                    { 24, "Подвал", false, false, "930", 4, 2 },
                    { 26, "7", false, false, "775", 2, 2 },
                    { 12, "Подвал", true, false, "349", 4, 1 },
                    { 13, "Подвал", true, false, "831", 4, 1 },
                    { 14, "6", true, false, "618", 3, 1 },
                    { 15, "1", false, false, "866", 3, 1 },
                    { 16, "3", true, false, "271b", 2, 1 },
                    { 18, "1", true, false, "418", 3, 1 },
                    { 19, "4", true, false, "741b", 3, 1 },
                    { 25, "3", false, false, "785", 1, 1 },
                    { 5, "Подвал", false, false, "959", 1, 1 },
                    { 2, "Подвал", true, false, "728", 4, 2 },
                    { 6, "4", true, false, "965", 1, 2 },
                    { 8, "5", true, false, "919", 1, 2 },
                    { 9, "4", true, false, "316a", 2, 2 },
                    { 17, "6", true, false, "895", 2, 2 },
                    { 20, "6", false, false, "920a", 2, 2 },
                    { 21, "6", true, false, "153", 3, 2 },
                    { 27, "6", true, false, "301", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "ClientId", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 17, new DateTime(2001, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "627480950496", "Анастасия@mail.ru", "Анастасия", false, "Астахов", "1234567890", "6-4209-4933-0", 3 },
                    { 16, new DateTime(1998, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "843523014677", "Егор@mail.ru", "Егор", false, "Горбенко", "1234567890", "3-3959-9119-3", 3 },
                    { 15, new DateTime(2003, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "115323081437", "Алексей@mail.ru", "Алексей", false, "Смирнов", "1234567890", "1-1353-9234-8", 3 },
                    { 14, new DateTime(2009, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "546288220662", "Илья@mail.ru", "Илья", false, "Ситников", "1234567890", "1-5725-0788-1", 3 },
                    { 13, new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "187397358965", "Никита@mail.ru", "Никита", false, "Смирнов", "1234567890", "4-2590-7888-3", 3 },
                    { 12, new DateTime(1995, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "711485975056", "Егор@mail.ru", "Егор", false, "Иванов", "1234567890", "7-9386-7952-5", 3 },
                    { 11, new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "697467640113", "Роман@mail.ru", "Роман", false, "Ситников", "1234567890", "0-1190-1250-7", 3 },
                    { 10, new DateTime(2016, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "858374452616", "Роман@mail.ru", "Роман", false, "Смирнов", "1234567890", "4-4646-8304-0", 3 },
                    { 6, new DateTime(2011, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "103612849091", "Михаил@mail.ru", "Михаил", false, "Астахов", "1234567890", "8-9481-4267-4", 3 },
                    { 8, new DateTime(2018, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "076779550826", "Екатерина@mail.ru", "Екатерина", false, "Иванов", "1234567890", "4-6467-6675-9", 3 },
                    { 7, new DateTime(2001, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "391058232700", "Алексей@mail.ru", "Алексей", false, "Астахов", "1234567890", "2-3509-6257-6", 3 },
                    { 5, new DateTime(2002, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "190691335130", "Илья@mail.ru", "Илья", false, "Ситников", "1234567890", "7-7244-2402-9", 3 },
                    { 4, new DateTime(2013, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "686928106367", "Никита@mail.ru", "Никита", false, "Поляков", "1234567890", "1-3801-9370-4", 3 },
                    { 3, new DateTime(2007, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "414971649509", "Егор@mail.ru", "Егор", false, "Горбенко", "1234567890", "2-5290-5708-8", 2 },
                    { 2, new DateTime(2010, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "628587109441", "Анастасия@mail.ru", "Анастасия", false, "Сидоров", "1234567890", "0-5756-1050-8", 2 },
                    { 1, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "225822861524", "owner@mail.ru", "Алексей", false, "Сидоров", "1234567890", "9-6549-0906-9", 1 },
                    { 18, new DateTime(1997, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "591989195502", "Егор@mail.ru", "Егор", false, "Горбенко", "1234567890", "2-5734-5412-3", 3 },
                    { 9, new DateTime(1999, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "078096151415", "Алексей@mail.ru", "Алексей", false, "Сидоров", "1234567890", "7-8092-1620-5", 3 },
                    { 19, new DateTime(2011, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "910941151308", "Екатерина@mail.ru", "Екатерина", false, "Смирнов", "1234567890", "7-1833-9129-6", 3 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "CheckInTime", "CheckOutTime", "Cost", "IsCanceled", "IsPaid", "RoomId", "UserId", "isEvicted" },
                values: new object[,]
                {
                    { 15, new DateTime(2019, 8, 7, 0, 12, 2, 540, DateTimeKind.Local).AddTicks(98), new DateTime(2019, 8, 17, 0, 12, 2, 540, DateTimeKind.Local).AddTicks(98), 2000, false, true, 5, 1, false },
                    { 1, new DateTime(2019, 8, 8, 0, 12, 2, 532, DateTimeKind.Local).AddTicks(3317), new DateTime(2019, 8, 14, 0, 12, 2, 532, DateTimeKind.Local).AddTicks(3317), 8300, false, true, 22, 4, false },
                    { 10, new DateTime(2019, 7, 29, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9955), new DateTime(2019, 8, 12, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9955), 8200, false, false, 23, 5, false },
                    { 14, new DateTime(2019, 8, 6, 0, 12, 2, 540, DateTimeKind.Local).AddTicks(71), new DateTime(2019, 8, 18, 0, 12, 2, 540, DateTimeKind.Local).AddTicks(71), 6200, false, true, 1, 5, false },
                    { 11, new DateTime(2019, 7, 27, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9987), new DateTime(2019, 8, 11, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9987), 4000, false, false, 20, 7, false },
                    { 7, new DateTime(2019, 8, 9, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9805), new DateTime(2019, 8, 17, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9805), 6000, false, true, 10, 9, false },
                    { 13, new DateTime(2019, 8, 4, 0, 12, 2, 540, DateTimeKind.Local).AddTicks(43), new DateTime(2019, 8, 16, 0, 12, 2, 540, DateTimeKind.Local).AddTicks(43), 6200, false, false, 13, 9, false },
                    { 4, new DateTime(2019, 8, 14, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9694), new DateTime(2019, 8, 18, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9694), 7700, false, true, 7, 10, false },
                    { 5, new DateTime(2019, 7, 26, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9729), new DateTime(2019, 8, 7, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9729), 4000, false, false, 27, 12, false },
                    { 2, new DateTime(2019, 8, 5, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(4956), new DateTime(2019, 8, 14, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(4956), 6200, false, true, 12, 15, false },
                    { 3, new DateTime(2019, 7, 27, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(8463), new DateTime(2019, 8, 5, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(8463), 7700, false, false, 28, 15, false },
                    { 6, new DateTime(2019, 8, 14, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9783), new DateTime(2019, 8, 24, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9783), 3700, false, true, 15, 15, false },
                    { 9, new DateTime(2019, 7, 27, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9924), new DateTime(2019, 8, 4, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9924), 6300, false, false, 21, 15, false },
                    { 8, new DateTime(2019, 7, 27, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9832), new DateTime(2019, 8, 4, 0, 12, 2, 539, DateTimeKind.Local).AddTicks(9832), 2000, false, false, 25, 16, false },
                    { 12, new DateTime(2019, 8, 4, 0, 12, 2, 540, DateTimeKind.Local).AddTicks(14), new DateTime(2019, 8, 14, 0, 12, 2, 540, DateTimeKind.Local).AddTicks(14), 4500, false, false, 8, 19, false }
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
