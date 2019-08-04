using Hotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Controllers;

namespace Hotel.Data
{
    public static class InitDataBase
    {
        private static int lastUserId = 1;
        private static int lastRoomId = 1;
        private static int lastTransactionId = 1;
        private static Random random = new Random();

        private static List<Transaction> Transactions = new List<Transaction>();
        private static List<Room> Rooms = new List<Room>();
        private static List<RoomCost> RoomCosts = new List<RoomCost>();

        public static List<Role> CreateRoles()
        {
            Role Owner = new Role { RoleId = 1, Name = "Владелец", Rights = (Role.AccessRights)2047 };
            Role Admin = new Role { RoleId = 2, Name = "Администратор", Rights = Role.AccessRights.CanRegisterClients | Role.AccessRights.CanBookRooms | Role.AccessRights.CanCheckInOut | Role.AccessRights.CanGetAnyHistory | Role.AccessRights.CanGetInfo };
            Role Visitor = new Role { RoleId = 3, Name = "Посетитель", Rights = Role.AccessRights.CanCheckInOut | Role.AccessRights.CanGetOwnHistory | Role.AccessRights.IsCustomer };

            List<Role> list = new List<Role> {Owner,Admin,Visitor };

            return list;
        }

        public static User CreateUser(int roleId = 0)
        {

            string[] firstNames = { "Илья", "Никита", "Егор", "Алексей", "Михаил", "Роман", "Юлия", "Екатерина", "Анастасия", "Ксения" };
            string[] lastNames = { "Воробьев", "Ситников", "Поляков", "Иванов", "Сидоров", "Смирнов", "Комаров", "Астахов", "Ускова", "Горбенко" };

            if (roleId == 0)
            {
                roleId = random.Next(1, 4);
            }

            string FirstName = firstNames[random.Next(firstNames.Length)];
            string LastName = lastNames[random.Next(lastNames.Length)];

            User user = new User {
                UserId = lastUserId++,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = RandomDay(),
                Phone = RandomPhone(),
                Email = FirstName + "@mail.ru",
                ClientId = RandomClientId(),
                RoleId = roleId,
                IsDeleted = false };

            return user;
        }

        public static List<Category> CreateCategory()
        {

            Category Economy = new Category { CategoryId = 1, Name = "Economy" };
            Category Ordinary = new Category { CategoryId = 2, Name = "Ordinary" };
            Category Lux = new Category { CategoryId = 3, Name = "Lux" };

            List<Category> list = new List<Category> {Economy,Ordinary,Lux };

            return list;
        }

        public static Room CreateRoom(int CategoryId = 0)
        {
            string[] suffixName = {"a","b", "","","","",""};
            string[] floors = { "Подвал", "1","2","3","4","5","6","7" };

            if(CategoryId == 0)
            {
                CategoryId = random.Next(1, 4);
            }


            string Name = random.Next(100,999).ToString() + suffixName[random.Next(suffixName.Length)];
            string floor = floors[random.Next(floors.Length)];

            Room room = new Room {
                RoomId = lastRoomId++,
                Name = Name,
                Floor = floor,
                RoomTypeId = CategoryId,
                NumberOfSeats = 2,
                HasMiniBar = random.Next(2) == 1,
                IsDeleted = false };

            Rooms.Add(room);
            return room;
        }

        public static List<RoomCost> CreateRoomCost()
        {
            RoomCost cost_categ_1_num_1 = new RoomCost { RoomCostId = 1, CategoryId = 1, NumberOfSeats = 1, HasMiniBar = false, Cost = 2000 };
            RoomCost cost_categ_1_num_2 = new RoomCost { RoomCostId = 2, CategoryId = 1, NumberOfSeats = 2, HasMiniBar = false, Cost = 3000 };
            RoomCost cost_categ_1_num_3 = new RoomCost { RoomCostId = 3, CategoryId = 1, NumberOfSeats = 3, HasMiniBar = false, Cost = 3700 };
            RoomCost cost_categ_1_num_4 = new RoomCost { RoomCostId = 4, CategoryId = 1, NumberOfSeats = 4, HasMiniBar = false, Cost = 4200 };

            RoomCost cost_categ_1_num_5 = new RoomCost { RoomCostId = 5, CategoryId = 1, NumberOfSeats = 1, HasMiniBar = true, Cost = 3000 };
            RoomCost cost_categ_1_num_6 = new RoomCost { RoomCostId = 6, CategoryId = 1, NumberOfSeats = 2, HasMiniBar = true, Cost = 4000 };
            RoomCost cost_categ_1_num_7 = new RoomCost { RoomCostId = 7, CategoryId = 1, NumberOfSeats = 3, HasMiniBar = true, Cost = 5700 };
            RoomCost cost_categ_1_num_8 = new RoomCost { RoomCostId = 8, CategoryId = 1, NumberOfSeats = 4, HasMiniBar = true, Cost = 6200 };



            RoomCost cost_categ_2_num_1 = new RoomCost { RoomCostId = 9, CategoryId = 2, NumberOfSeats = 1, HasMiniBar = false, Cost = 3000 };
            RoomCost cost_categ_2_num_2 = new RoomCost { RoomCostId = 10, CategoryId = 2, NumberOfSeats = 2, HasMiniBar = false, Cost = 4000 };
            RoomCost cost_categ_2_num_3 = new RoomCost { RoomCostId = 11, CategoryId = 2, NumberOfSeats = 3, HasMiniBar = false, Cost = 5700 };
            RoomCost cost_categ_2_num_4 = new RoomCost { RoomCostId = 12, CategoryId = 2, NumberOfSeats = 4, HasMiniBar = false, Cost = 6200 };

            RoomCost cost_categ_2_num_5 = new RoomCost { RoomCostId = 13, CategoryId = 2, NumberOfSeats = 1, HasMiniBar = true, Cost = 4500 };
            RoomCost cost_categ_2_num_6 = new RoomCost { RoomCostId = 14, CategoryId = 2, NumberOfSeats = 2, HasMiniBar = true, Cost = 5500 };
            RoomCost cost_categ_2_num_7 = new RoomCost { RoomCostId = 15, CategoryId = 2, NumberOfSeats = 3, HasMiniBar = true, Cost = 6300 };
            RoomCost cost_categ_2_num_8 = new RoomCost { RoomCostId = 16, CategoryId = 2, NumberOfSeats = 4, HasMiniBar = true, Cost = 6800 };

            RoomCost cost_categ_3_num_1 = new RoomCost { RoomCostId = 17, CategoryId = 3, NumberOfSeats = 1, HasMiniBar = false, Cost = 5000 };
            RoomCost cost_categ_3_num_2 = new RoomCost { RoomCostId = 18, CategoryId = 3, NumberOfSeats = 2, HasMiniBar = false, Cost = 6000 };
            RoomCost cost_categ_3_num_3 = new RoomCost { RoomCostId = 19, CategoryId = 3, NumberOfSeats = 3, HasMiniBar = false, Cost = 7700 };
            RoomCost cost_categ_3_num_4 = new RoomCost { RoomCostId = 20, CategoryId = 3, NumberOfSeats = 4, HasMiniBar = false, Cost = 8200 };

            RoomCost cost_categ_3_num_5 = new RoomCost { RoomCostId = 21, CategoryId = 3, NumberOfSeats = 1, HasMiniBar = true, Cost = 6800 };
            RoomCost cost_categ_3_num_6 = new RoomCost { RoomCostId = 22, CategoryId = 3, NumberOfSeats = 2, HasMiniBar = true, Cost = 7200 };
            RoomCost cost_categ_3_num_7 = new RoomCost { RoomCostId = 23, CategoryId = 3, NumberOfSeats = 3, HasMiniBar = true, Cost = 8300 };
            RoomCost cost_categ_3_num_8 = new RoomCost { RoomCostId = 24, CategoryId = 3, NumberOfSeats = 4, HasMiniBar = true, Cost = 10000 };

            List<RoomCost> list = new List<RoomCost> {
                cost_categ_1_num_1, cost_categ_1_num_2, cost_categ_1_num_3, cost_categ_1_num_4,
                cost_categ_1_num_5, cost_categ_1_num_6, cost_categ_1_num_7, cost_categ_1_num_8,

                cost_categ_2_num_1, cost_categ_2_num_2, cost_categ_2_num_3, cost_categ_2_num_4,
                cost_categ_2_num_5, cost_categ_2_num_6, cost_categ_2_num_7, cost_categ_2_num_8,

                cost_categ_3_num_1, cost_categ_3_num_2, cost_categ_3_num_3, cost_categ_3_num_4,
                cost_categ_3_num_5, cost_categ_3_num_6, cost_categ_3_num_7, cost_categ_3_num_8

            };

            RoomCosts = list;
            return list;
        }

        public static Transaction CreateTransaction()
        {
            DateTime CheckInTime = DateTime.Now.AddDays(random.Next(-10, 11));
            DateTime CheckOutTime = CheckInTime.AddDays(random.Next(1, 16));
            int userId = random.Next(1,lastUserId);

            var busyRooms = Transactions
                .Where(t => CheckInTime >= t.CheckInTime && CheckInTime <= t.CheckOutTime ||
                 CheckOutTime >= t.CheckInTime && CheckOutTime <= t.CheckOutTime).Select(t => t.RoomId).ToList();

            int roomId = 0;
            int _k = 0;
            while (roomId == 0 && _k < 20)
            {
                int value = random.Next(1, lastRoomId);

                if (busyRooms == null  || !busyRooms.Contains(value))
                {
                    roomId = value;
                }
                _k++;
            }

            Room room = Rooms.Find(r => r.RoomId == roomId);
            if (roomId == 0 || room == null)
            {
                return null;
            }
            
            int cost = 0;

            cost = RoomCosts
                .Where(rc => rc.CategoryId == room.RoomTypeId)
                .Where(rc => rc.NumberOfSeats == room.NumberOfSeats)
                .Where(rc => rc.HasMiniBar == room.HasMiniBar).Select(rc => rc.Cost).FirstOrDefault();

            if(cost == 0)
            {
                return null;
            }

            Transaction transaction = 
                new Transaction { TransactionId = lastTransactionId++,
                    CheckInTime = CheckInTime,
                    CheckOutTime = CheckOutTime,
                    UserId = userId,
                    RoomId = roomId,
                    Cost = cost,
                    IsPaid = CheckInTime >= DateTime.Today
                };

            Transactions.Add(transaction);

            return transaction;
        }

        private static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        private static string RandomPhone()
        {
            string randomNum = "";
            //1,5,9,12
            List<int> list = new List<int>{ 1, 5, 9, 12 };
            for(int i = 0; i < 10; i++)
            {
                if(list.Contains(i))
                {
                    randomNum += '-';
                }
                randomNum += random.Next(10).ToString();
            }
            return randomNum;
        }

        private static string RandomClientId()
        {
            string randomId = "";

            for (int i = 0; i < 12; i++) { 
                randomId += random.Next(10).ToString();
            }
            return randomId;
        }
    }
}
