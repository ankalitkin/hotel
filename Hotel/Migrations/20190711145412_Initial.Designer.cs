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
    [Migration("20190711145412_Initial")]
    partial class Initial
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

                    b.Property<int?>("RoomTypeCategoryId");

                    b.HasKey("RoomId");

                    b.HasIndex("RoomTypeCategoryId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hotel.Entities.RoomCost", b =>
                {
                    b.Property<int>("RoomCostID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<int>("Cost");

                    b.Property<bool>("HasMiniBar");

                    b.Property<int>("NumberOfSeats");

                    b.HasKey("RoomCostID");

                    b.HasIndex("CategoryId");

                    b.ToTable("RoomCosts");
                });

            modelBuilder.Entity("Hotel.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckInTime");

                    b.Property<DateTime>("CheckOutTime");

                    b.Property<int>("Cost");

                    b.Property<bool>("IsPaid");

                    b.Property<int?>("RoomId");

                    b.Property<int?>("UserId");

                    b.HasKey("TransactionID");

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

                    b.Property<string>("ClientID")
                        .HasMaxLength(12);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<int?>("RoleId");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hotel.Entities.Room", b =>
                {
                    b.HasOne("Hotel.Entities.Category", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeCategoryId");
                });

            modelBuilder.Entity("Hotel.Entities.RoomCost", b =>
                {
                    b.HasOne("Hotel.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Hotel.Entities.Transaction", b =>
                {
                    b.HasOne("Hotel.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.HasOne("Hotel.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Hotel.Entities.User", b =>
                {
                    b.HasOne("Hotel.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
