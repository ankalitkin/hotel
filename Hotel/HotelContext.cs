using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace Hotel
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
            _connectionString = "data source=localhost;initial catalog=HotelProd;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;";
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

    }

    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [StringLength(12)]
        public string ClientID { get; set; }
        public virtual Role Role { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped] public bool CanEditRooms => Role.Rights.HasFlag(Role.AccessRights.CanEditRooms);
        [NotMapped] public bool CanEditCost => Role.Rights.HasFlag(Role.AccessRights.CanEditCost);
        [NotMapped] public bool CanEditStuff => Role.Rights.HasFlag(Role.AccessRights.CanEditStuff);
        [NotMapped] public bool CanRegisterClients => Role.Rights.HasFlag(Role.AccessRights.CanRegisterClients);
        [NotMapped] public bool CanEditClients => Role.Rights.HasFlag(Role.AccessRights.CanEditClients);
        [NotMapped] public bool CanBookRooms => Role.Rights.HasFlag(Role.AccessRights.CanBookRooms);
        [NotMapped] public bool CanCheckInOut => Role.Rights.HasFlag(Role.AccessRights.CanCheckInOut);
        [NotMapped] public bool CanGetInfo => Role.Rights.HasFlag(Role.AccessRights.CanGetInfo);
        [NotMapped] public bool CanGetAnyHistory => Role.Rights.HasFlag(Role.AccessRights.CanGetAnyHistory);
        [NotMapped] public bool CanGetOwnHistory => Role.Rights.HasFlag(Role.AccessRights.CanGetOwnHistory);
        [NotMapped] public bool CanGetFinancialInformation => Role.Rights.HasFlag(Role.AccessRights.CanGetFinancialInformation);

    }

    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }
        public virtual Category RoomType { get; set; }
        public int NumberOfSeats { get; set; }
        public bool HasMiniBar { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped] public bool IsFree { get; } //ToDo
    }

    public class Role
    {
        [Flags]
        public enum AccessRights
        {
            CanEditRooms = 1,
            CanEditCost = 2,
            CanEditStuff = 4,
            CanRegisterClients = 8,
            CanEditClients = 16,
            CanBookRooms = 32,
            CanCheckInOut = 64,
            CanGetInfo = 128,
            CanGetAnyHistory = 256,
            CanGetOwnHistory = 512,
            CanGetFinancialInformation = 1024
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public AccessRights Rights { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }

    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public virtual User Uset { get; set; }
        public virtual Room Room { get; set; }
        public int Cost { get; set; }
        public bool IsPaid { get; set; }
    }

    public class RoomCost
    {
        public int CostID { get; set; }
        public virtual Category Category { get; set; }
        public int NumberOfSeats { get; set; }
        public bool HasMiniBar { get; set; }
        public int Cost { get; set; }
    }
}