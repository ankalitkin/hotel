using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class BaseInitial : Migration
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
                    { 1, "Owner", 2047 },
                    { 2, "Admin", 488 },
                    { 3, "Visitor", 576 }
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
                    { 16, "3", true, false, "202a", 2, 3 },
                    { 21, "6", false, false, "501a", 2, 3 },
                    { 8, "3", true, false, "263a", 2, 3 },
                    { 3, "2", false, false, "464", 2, 3 },
                    { 23, "5", true, false, "859", 2, 3 },
                    { 22, "5", false, false, "544", 2, 3 },
                    { 19, "4", false, false, "966", 2, 3 },
                    { 12, "3", true, false, "953b", 2, 3 },
                    { 1, "2", true, false, "862a", 2, 1 },
                    { 25, "6", true, false, "539", 2, 2 },
                    { 28, "Подвал", true, false, "278a", 2, 2 },
                    { 6, "3", false, false, "849a", 2, 1 },
                    { 7, "6", true, false, "147", 2, 1 },
                    { 14, "4", true, false, "844", 2, 1 },
                    { 15, "2", true, false, "849", 2, 1 },
                    { 17, "1", true, false, "312", 2, 1 },
                    { 18, "6", true, false, "773", 2, 1 },
                    { 24, "5", false, false, "966", 2, 1 },
                    { 26, "2", false, false, "281", 2, 1 },
                    { 5, "5", false, false, "136b", 2, 1 },
                    { 2, "5", false, false, "186", 2, 2 },
                    { 4, "7", true, false, "960", 2, 2 },
                    { 9, "Подвал", false, false, "433", 2, 2 },
                    { 10, "2", false, false, "309", 2, 2 },
                    { 11, "1", true, false, "837", 2, 2 },
                    { 13, "2", true, false, "823", 2, 2 },
                    { 20, "4", false, false, "755", 2, 2 },
                    { 27, "2", false, false, "493", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "ClientId", "Email", "FirstName", "IsDeleted", "LastName", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 17, new DateTime(2017, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "613920422162", "Юлия@mail.ru", "Юлия", false, "Ситников", "7-0041-5173-4", 3 },
                    { 16, new DateTime(1998, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "945934191051", "Егор@mail.ru", "Егор", false, "Ситников", "1-8014-3085-6", 3 },
                    { 15, new DateTime(2006, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "027801886136", "Екатерина@mail.ru", "Екатерина", false, "Смирнов", "1-4945-4153-6", 3 },
                    { 14, new DateTime(1996, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "663718851058", "Никита@mail.ru", "Никита", false, "Ситников", "2-7498-3404-8", 3 },
                    { 13, new DateTime(2007, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "583470003993", "Егор@mail.ru", "Егор", false, "Сидоров", "8-3648-8777-3", 3 },
                    { 12, new DateTime(1997, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "552554213424", "Екатерина@mail.ru", "Екатерина", false, "Сидоров", "7-6406-9386-9", 3 },
                    { 11, new DateTime(2002, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "396255677549", "Михаил@mail.ru", "Михаил", false, "Горбенко", "7-4181-2331-7", 3 },
                    { 10, new DateTime(1998, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "753081149040", "Михаил@mail.ru", "Михаил", false, "Ситников", "0-8896-0716-8", 3 },
                    { 6, new DateTime(2000, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "238918892597", "Роман@mail.ru", "Роман", false, "Ситников", "2-8301-6483-0", 3 },
                    { 8, new DateTime(2010, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "863542302292", "Илья@mail.ru", "Илья", false, "Ситников", "2-2262-5968-0", 3 },
                    { 7, new DateTime(1999, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "886415595348", "Ксения@mail.ru", "Ксения", false, "Комаров", "0-7757-5098-7", 3 },
                    { 5, new DateTime(2017, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "043567703411", "Никита@mail.ru", "Никита", false, "Горбенко", "7-5009-7165-8", 3 },
                    { 4, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "055153043987", "Юлия@mail.ru", "Юлия", false, "Горбенко", "4-5827-8499-9", 3 },
                    { 3, new DateTime(2002, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "169256666633", "Екатерина@mail.ru", "Екатерина", false, "Комаров", "1-8652-5253-4", 2 },
                    { 2, new DateTime(2000, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "668814735542", "Алексей@mail.ru", "Алексей", false, "Астахов", "0-1520-9104-1", 2 },
                    { 1, new DateTime(2007, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "770729151429", "Екатерина@mail.ru", "Екатерина", false, "Воробьев", "5-6355-3223-4", 1 },
                    { 18, new DateTime(2011, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "294317725637", "Анастасия@mail.ru", "Анастасия", false, "Иванов", "1-6115-9192-6", 3 },
                    { 9, new DateTime(2018, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "373529273281", "Роман@mail.ru", "Роман", false, "Ситников", "4-7427-2758-5", 3 },
                    { 19, new DateTime(2017, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "895745212019", "Илья@mail.ru", "Илья", false, "Ускова", "1-9492-4277-9", 3 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "CheckInTime", "CheckOutTime", "Cost", "IsCanceled", "IsPaid", "RoomId", "UserId", "isEvicted" },
                values: new object[,]
                {
                    { 5, new DateTime(2019, 8, 3, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(8945), new DateTime(2019, 8, 8, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(8945), 6000, false, true, 21, 2, false },
                    { 8, new DateTime(2019, 8, 8, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9304), new DateTime(2019, 8, 10, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9304), 3000, false, true, 26, 2, false },
                    { 14, new DateTime(2019, 7, 31, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9681), new DateTime(2019, 8, 5, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9681), 3000, false, false, 6, 2, false },
                    { 2, new DateTime(2019, 8, 12, 20, 38, 59, 745, DateTimeKind.Local).AddTicks(7057), new DateTime(2019, 8, 27, 20, 38, 59, 745, DateTimeKind.Local).AddTicks(7057), 3000, false, true, 26, 3, false },
                    { 13, new DateTime(2019, 8, 12, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9532), new DateTime(2019, 8, 23, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9532), 5500, false, true, 28, 3, false },
                    { 7, new DateTime(2019, 7, 24, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9264), new DateTime(2019, 7, 31, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9264), 5500, false, false, 13, 7, false },
                    { 9, new DateTime(2019, 7, 31, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9338), new DateTime(2019, 8, 14, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9338), 6000, false, false, 22, 8, false },
                    { 4, new DateTime(2019, 8, 12, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(8814), new DateTime(2019, 8, 18, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(8814), 7200, false, true, 8, 9, false },
                    { 12, new DateTime(2019, 8, 3, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9492), new DateTime(2019, 8, 17, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9492), 3000, false, true, 5, 10, false },
                    { 15, new DateTime(2019, 7, 27, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9726), new DateTime(2019, 8, 7, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9726), 6000, false, false, 19, 10, false },
                    { 3, new DateTime(2019, 8, 11, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(8597), new DateTime(2019, 8, 23, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(8597), 4000, false, true, 7, 11, false },
                    { 6, new DateTime(2019, 8, 3, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9207), new DateTime(2019, 8, 15, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9207), 7200, false, true, 16, 12, false },
                    { 1, new DateTime(2019, 8, 10, 20, 38, 59, 728, DateTimeKind.Local).AddTicks(6271), new DateTime(2019, 8, 23, 20, 38, 59, 728, DateTimeKind.Local).AddTicks(6271), 4000, false, true, 20, 14, false },
                    { 10, new DateTime(2019, 8, 9, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9390), new DateTime(2019, 8, 13, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9390), 6000, false, true, 21, 16, false },
                    { 11, new DateTime(2019, 7, 27, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9435), new DateTime(2019, 8, 1, 20, 38, 59, 746, DateTimeKind.Local).AddTicks(9435), 4000, false, false, 17, 17, false }
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
