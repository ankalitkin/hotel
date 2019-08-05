using Hotel.Data;
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
            // _connectionString = "data source=LAPTOP-G6OO0Q2P\\SQLEXPRESS;initial catalog=HotelProd;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;"; // заачееем??
            _connectionString = "data source=LAPTOP-G6OO0Q2P\\SQLEXPRESS;initial catalog=HotelProd;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;"; // ПРОСТО ЗАКОМЕНТЬ, Костя, не удаляй
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
            List<Role> roles = InitDataBase.CreateRoles();
            List<User> users = new List<User> { InitDataBase.CreateUser(1), InitDataBase.CreateUser(2), InitDataBase.CreateUser(2), InitDataBase.CreateUser(3) };

            for (int i = 0; i < 15; i++)
            {
                users.Add(InitDataBase.CreateUser(3));
            }

            List<Category> categores = InitDataBase.CreateCategory();

            List<Room> rooms = new List<Room> { InitDataBase.CreateRoom(1), InitDataBase.CreateRoom(2), InitDataBase.CreateRoom(3) };

            for (int i = 0; i < 25; i++)
            {
                rooms.Add(InitDataBase.CreateRoom());
            }

            List<RoomCost> costs = InitDataBase.CreateRoomCost();

            List<Transaction> transctions = new List<Transaction>();

            for (int i = 0; i < 15; i++)
            {
                var trans = InitDataBase.CreateTransaction();
                if (transctions != null)
                    transctions.Add(trans);
            }

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Category>().HasData(categores);
            modelBuilder.Entity<Room>().HasData(rooms);
            modelBuilder.Entity<RoomCost>().HasData(costs);
            modelBuilder.Entity<Transaction>().HasData(transctions);

            /*
            */
        }

    }
}
