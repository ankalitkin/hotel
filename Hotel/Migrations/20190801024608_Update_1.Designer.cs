﻿// <auto-generated />
using System;
using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hotel.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20190801024608_Update_1")]
    partial class Update_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hotel.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Economy"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Ordinary"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Lux"
                        });
                });

            modelBuilder.Entity("Hotel.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Rights");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "Owner",
                            Rights = 2047
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Admin",
                            Rights = 488
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "Visitor",
                            Rights = 576
                        });
                });

            modelBuilder.Entity("Hotel.Entities.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Floor");

                    b.Property<bool>("HasMiniBar");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfSeats");

                    b.Property<int>("RoomTypeId");

                    b.HasKey("RoomId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            Floor = "Подвал",
                            HasMiniBar = false,
                            IsDeleted = false,
                            Name = "101",
                            NumberOfSeats = 2,
                            RoomTypeId = 1
                        },
                        new
                        {
                            RoomId = 2,
                            Floor = "3",
                            HasMiniBar = false,
                            IsDeleted = false,
                            Name = "121",
                            NumberOfSeats = 3,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomId = 3,
                            Floor = "12",
                            HasMiniBar = true,
                            IsDeleted = false,
                            Name = "14a",
                            NumberOfSeats = 2,
                            RoomTypeId = 3
                        });
                });

            modelBuilder.Entity("Hotel.Entities.RoomCost", b =>
                {
                    b.Property<int>("RoomCostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("Cost");

                    b.Property<bool>("HasMiniBar");

                    b.Property<int>("NumberOfSeats");

                    b.HasKey("RoomCostId");

                    b.HasIndex("CategoryId");

                    b.ToTable("RoomCosts");

                    b.HasData(
                        new
                        {
                            RoomCostId = 1,
                            CategoryId = 1,
                            Cost = 3500,
                            HasMiniBar = false,
                            NumberOfSeats = 2
                        },
                        new
                        {
                            RoomCostId = 2,
                            CategoryId = 2,
                            Cost = 5200,
                            HasMiniBar = false,
                            NumberOfSeats = 3
                        },
                        new
                        {
                            RoomCostId = 3,
                            CategoryId = 3,
                            Cost = 11700,
                            HasMiniBar = true,
                            NumberOfSeats = 2
                        });
                });

            modelBuilder.Entity("Hotel.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckInTime");

                    b.Property<DateTime>("CheckOutTime");

                    b.Property<int>("Cost");

                    b.Property<bool>("IsCanceled");

                    b.Property<bool>("IsPaid");

                    b.Property<int>("RoomId");

                    b.Property<int>("UserId");

                    b.Property<bool>("isEvicted");

                    b.HasKey("TransactionId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Hotel.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("ClientId")
                        .HasMaxLength(12);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            BirthDate = new DateTime(1996, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClientId = "123456789012",
                            Email = "Tom@mail.ru",
                            FirstName = "Tom",
                            IsDeleted = false,
                            LastName = "Timmi",
                            Phone = "8-800-555-35-35",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            BirthDate = new DateTime(1999, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClientId = "123456789013",
                            Email = "Dik@mail.ru",
                            FirstName = "Dik",
                            IsDeleted = false,
                            LastName = "Dom",
                            Phone = "8-800-555-35-36",
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            BirthDate = new DateTime(1986, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClientId = "123456789014",
                            Email = "Jorge@mail.ru",
                            FirstName = "Jorge",
                            IsDeleted = false,
                            LastName = "Vim",
                            Phone = "8-800-555-35-37",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Hotel.Entities.Room", b =>
                {
                    b.HasOne("Hotel.Entities.Category", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Entities.RoomCost", b =>
                {
                    b.HasOne("Hotel.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Entities.Transaction", b =>
                {
                    b.HasOne("Hotel.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Entities.User", b =>
                {
                    b.HasOne("Hotel.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
