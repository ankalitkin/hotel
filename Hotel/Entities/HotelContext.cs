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
}