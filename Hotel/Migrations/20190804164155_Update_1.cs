using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class Update_1 : Migration
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
                    { 8, 1, 6200, true, 4 },
                    { 14, 2, 5500, true, 2 },
                    { 13, 2, 4500, true, 1 },
                    { 12, 2, 6200, false, 4 },
                    { 11, 2, 5700, false, 3 },
                    { 10, 2, 4000, false, 2 },
                    { 9, 2, 3000, false, 1 },
                    { 15, 2, 6300, true, 3 },
                    { 7, 1, 5700, true, 3 },
                    { 6, 1, 4000, true, 2 },
                    { 5, 1, 3000, true, 1 },
                    { 4, 1, 4200, false, 4 },
                    { 16, 2, 6800, true, 4 },
                    { 2, 1, 3000, false, 2 },
                    { 1, 1, 2000, false, 1 },
                    { 17, 3, 5000, false, 1 },
                    { 18, 3, 6000, false, 2 },
                    { 24, 3, 10000, true, 4 },
                    { 23, 3, 8300, true, 3 },
                    { 22, 3, 7200, true, 2 },
                    { 21, 3, 6800, true, 1 },
                    { 20, 3, 8200, false, 4 },
                    { 19, 3, 7700, false, 3 },
                    { 3, 1, 3700, false, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Floor", "HasMiniBar", "IsDeleted", "Name", "NumberOfSeats", "RoomTypeId" },
                values: new object[,]
                {
                    { 3, "5", true, false, "518b", 2, 3 },
                    { 11, "4", true, false, "144b", 1, 3 },
                    { 17, "5", false, false, "705", 2, 3 },
                    { 20, "2", false, false, "947", 1, 3 },
                    { 21, "3", true, false, "787a", 2, 3 },
                    { 22, "5", true, false, "793", 4, 3 },
                    { 24, "7", true, false, "297", 3, 3 },
                    { 25, "7", false, false, "751", 3, 3 },
                    { 6, "4", true, false, "553b", 2, 3 },
                    { 1, "3", true, false, "490", 3, 1 },
                    { 4, "6", false, false, "633", 2, 3 },
                    { 14, "Подвал", true, false, "111", 1, 1 },
                    { 28, "1", false, false, "933", 2, 2 },
                    { 8, "4", false, false, "742", 4, 1 },
                    { 10, "5", false, false, "594", 4, 1 },
                    { 12, "4", true, false, "388b", 2, 1 },
                    { 13, "4", true, false, "658a", 3, 1 },
                    { 16, "3", false, false, "682", 1, 1 },
                    { 18, "1", true, false, "910b", 2, 1 },
                    { 23, "7", false, false, "406", 4, 1 },
                    { 5, "4", false, false, "320", 2, 2 },
                    { 7, "Подвал", false, false, "760", 2, 2 },
                    { 9, "4", true, false, "578", 3, 2 },
                    { 15, "3", true, false, "215", 2, 2 },
                    { 19, "4", true, false, "761a", 3, 2 },
                    { 26, "3", true, false, "459", 4, 2 },
                    { 27, "4", true, false, "807", 1, 2 },
                    { 2, "1", true, false, "852", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "ClientId", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 13, new DateTime(2005, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "206278334461", "Роман@mail.ru", "Роман", false, "Воробьев", null, "9-0948-9341-1", 3 },
                    { 12, new DateTime(2015, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "444376330172", "Михаил@mail.ru", "Михаил", false, "Смирнов", null, "4-2785-7233-5", 3 },
                    { 14, new DateTime(1995, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "738461021557", "Михаил@mail.ru", "Михаил", false, "Ситников", null, "2-6341-1764-5", 3 },
                    { 18, new DateTime(2016, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "807493266975", "Михаил@mail.ru", "Михаил", false, "Ускова", null, "8-1050-6616-2", 3 },
                    { 16, new DateTime(2002, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "259681638220", "Ксения@mail.ru", "Ксения", false, "Ускова", null, "6-8264-4511-7", 3 },
                    { 17, new DateTime(2019, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "830028883794", "Егор@mail.ru", "Егор", false, "Ситников", null, "1-5437-8933-0", 3 },
                    { 11, new DateTime(2005, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "167091679659", "Анастасия@mail.ru", "Анастасия", false, "Ситников", null, "9-7095-5747-4", 3 },
                    { 15, new DateTime(2001, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "390095416955", "Никита@mail.ru", "Никита", false, "Поляков", null, "3-8167-7674-6", 3 },
                    { 10, new DateTime(1996, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "481423950557", "Екатерина@mail.ru", "Екатерина", false, "Иванов", null, "5-0475-2448-2", 3 },
                    { 1, new DateTime(1997, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "947422130074", "Екатерина@mail.ru", "Екатерина", false, "Поляков", null, "8-6127-3235-4", 1 },
                    { 8, new DateTime(2011, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "541116392716", "Екатерина@mail.ru", "Екатерина", false, "Смирнов", null, "8-2685-9694-4", 3 },
                    { 7, new DateTime(2016, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "913268994689", "Алексей@mail.ru", "Алексей", false, "Смирнов", null, "1-8029-8747-9", 3 },
                    { 6, new DateTime(2016, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "376272908834", "Михаил@mail.ru", "Михаил", false, "Комаров", null, "3-9535-3541-9", 3 },
                    { 5, new DateTime(2013, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "430406693983", "Михаил@mail.ru", "Михаил", false, "Ситников", null, "1-1053-9678-0", 3 },
                    { 4, new DateTime(2004, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "879926475578", "Илья@mail.ru", "Илья", false, "Горбенко", null, "2-9691-5825-7", 3 },
                    { 3, new DateTime(1998, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "585085248587", "Ксения@mail.ru", "Ксения", false, "Ситников", null, "6-7623-3996-6", 2 },
                    { 2, new DateTime(2010, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "643216450346", "Юлия@mail.ru", "Юлия", false, "Поляков", null, "1-8474-6412-5", 2 },
                    { 9, new DateTime(2018, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "505103188138", "Анастасия@mail.ru", "Анастасия", false, "Ситников", null, "3-5880-1145-1", 3 },
                    { 19, new DateTime(2004, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "687232237370", "Алексей@mail.ru", "Алексей", false, "Комаров", null, "4-1940-7054-8", 3 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "CheckInTime", "CheckOutTime", "Cost", "IsCanceled", "IsPaid", "RoomId", "UserId", "isEvicted" },
                values: new object[,]
                {
                    { 15, new DateTime(2019, 7, 30, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9364), new DateTime(2019, 8, 5, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9364), 4200, false, false, 8, 1, false },
                    { 4, new DateTime(2019, 8, 9, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8634), new DateTime(2019, 8, 24, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8634), 6800, false, true, 11, 2, false },
                    { 1, new DateTime(2019, 7, 30, 19, 41, 54, 214, DateTimeKind.Local).AddTicks(8233), new DateTime(2019, 8, 11, 19, 41, 54, 214, DateTimeKind.Local).AddTicks(8233), 8300, false, false, 24, 4, false },
                    { 14, new DateTime(2019, 8, 14, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9210), new DateTime(2019, 8, 18, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9210), 7200, false, true, 6, 5, false },
                    { 12, new DateTime(2019, 8, 14, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9136), new DateTime(2019, 8, 26, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9136), 2000, false, true, 16, 6, false },
                    { 2, new DateTime(2019, 8, 6, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(1667), new DateTime(2019, 8, 7, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(1667), 5000, false, true, 20, 7, false },
                    { 5, new DateTime(2019, 7, 31, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8691), new DateTime(2019, 8, 6, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8691), 10000, false, false, 22, 8, false },
                    { 6, new DateTime(2019, 8, 1, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8748), new DateTime(2019, 8, 2, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8748), 4000, false, false, 28, 10, false },
                    { 8, new DateTime(2019, 8, 6, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8970), new DateTime(2019, 8, 19, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8970), 5500, false, true, 15, 12, false },
                    { 11, new DateTime(2019, 7, 27, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9096), new DateTime(2019, 8, 1, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9096), 5500, false, false, 2, 12, false },
                    { 13, new DateTime(2019, 7, 26, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9170), new DateTime(2019, 8, 5, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9170), 2000, false, false, 16, 12, false },
                    { 9, new DateTime(2019, 8, 2, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9016), new DateTime(2019, 8, 12, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9016), 4500, false, false, 27, 14, false },
                    { 3, new DateTime(2019, 7, 25, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8417), new DateTime(2019, 8, 1, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8417), 6000, false, false, 17, 15, false },
                    { 10, new DateTime(2019, 8, 14, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9062), new DateTime(2019, 8, 23, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(9062), 5700, false, true, 13, 16, false },
                    { 7, new DateTime(2019, 8, 6, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8788), new DateTime(2019, 8, 10, 19, 41, 54, 228, DateTimeKind.Local).AddTicks(8788), 5500, false, true, 2, 19, false }
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
