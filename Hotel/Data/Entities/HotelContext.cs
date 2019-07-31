using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace Hotel.Entities
{
    public class HotelContext : DbContext
    {
        private readonly string _connectionString;

        public HotelContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public HotelContext()
        {
            /*var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            _connectionString = configuration.GetSection("ConnectionStrings").GetConnectionString("HotelContext");*/
            _connectionString = "data source=LAPTOP-CGORDSJ4\\MSSQLSERVERX;initial catalog=Hotelxx;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;";
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<RoomCost> RoomCosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                //.UseLazyLoadingProxies() // включает lazy load, нужна установка пакета Microsoft.EntityFrameworkCore.Proxies 
                .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);

            // Инициализация БД
            // /*
            Role Owner = new Role { RoleId = 1, Name = "Owner", Rights = (Role.AccessRights)2047 };
            Role Admin = new Role { RoleId = 2, Name = "Admin", Rights = Role.AccessRights.CanRegisterClients | Role.AccessRights.CanBookRooms | Role.AccessRights.CanCheckInOut | Role.AccessRights.CanGetAnyHistory | Role.AccessRights.CanGetInfo };
            Role Visitor = new Role { RoleId = 3, Name = "Visitor", Rights = Role.AccessRights.CanCheckInOut | Role.AccessRights.CanGetOwnHistory };

            User user1 = new User { UserId = 1, FirstName = "Tom", LastName = "Timmi", BirthDate = DateTime.Parse("01.05.1996"), Phone = "8-800-555-35-35", Email = "Tom@mail.ru", ClientID = "123456789012", RoleId = Owner.RoleId, IsDeleted = false };
            User user2 = new User { UserId = 2, FirstName = "Dik", LastName = "Dom", BirthDate = DateTime.Parse("05.07.1999"), Phone = "8-800-555-35-36", Email = "Dik@mail.ru", ClientID = "123456789013", RoleId = Admin.RoleId, IsDeleted = false };
            User user3 = new User { UserId = 3, FirstName = "Jorge", LastName = "Vim", BirthDate = DateTime.Parse("11.05.1986"), Phone = "8-800-555-35-37", Email = "Jorge@mail.ru", ClientID = "123456789014", RoleId = Visitor.RoleId, IsDeleted = false };

            Category Economy = new Category { CategoryId = 1, Name = "Economy" };
            Category Ordinary = new Category { CategoryId = 2, Name = "Ordinary" };
            Category Lux = new Category { CategoryId = 3, Name = "Lux" };

            Room room1 = new Room { RoomId = 1, Name = "101", Floor = "Подвал", RoomTypeId = Economy.CategoryId, NumberOfSeats = 2, HasMiniBar = false, IsDeleted = false };
            Room room2 = new Room { RoomId = 2, Name = "121", Floor = "3", RoomTypeId = Ordinary.CategoryId, NumberOfSeats = 3, HasMiniBar = false, IsDeleted = false };
            Room room3 = new Room { RoomId = 3, Name = "14a", Floor = "12", RoomTypeId = Lux.CategoryId, NumberOfSeats = 2, HasMiniBar = true, IsDeleted = false };

            RoomCost room1Cost = new RoomCost { RoomCostId = 1, CategoryId = 1, NumberOfSeats = 2, HasMiniBar = false, Cost = 3500 };
            RoomCost room2Cost = new RoomCost { RoomCostId = 2, CategoryId = 2, NumberOfSeats = 3, HasMiniBar = false, Cost = 5200 };
            RoomCost room3Cost = new RoomCost { RoomCostId = 3, CategoryId = 3, NumberOfSeats = 2, HasMiniBar = true, Cost = 11700 };

            modelBuilder.Entity<Role>().HasData(Owner, Admin, Visitor);
            modelBuilder.Entity<User>().HasData(user1, user2, user3);
            modelBuilder.Entity<Category>().HasData(Economy, Ordinary, Lux);
            modelBuilder.Entity<Room>().HasData(room1, room2, room3);
            modelBuilder.Entity<RoomCost>().HasData(room1Cost, room2Cost, room3Cost);
            /*
            modelBuilder.Entity<Transaction>().HasData(
            new Transaction { TransactionId = 1, CheckInTime = DateTime.Now, CheckOutTime = DateTime.Now.AddDays(1), UserId = user3.UserId, RoomId = room1.RoomId, Cost = room1Cost.Cost, IsPaid = true });
            //*/
        }

    }
}