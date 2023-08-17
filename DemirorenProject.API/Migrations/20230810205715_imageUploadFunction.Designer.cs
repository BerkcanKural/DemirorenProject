﻿// <auto-generated />
using System;
using DemirorenProject.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemirorenProject.API.Migrations
{
    [DbContext(typeof(NewsContext))]
    [Migration("20230810205715_imageUploadFunction")]
    partial class imageUploadFunction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("DemirorenProject.API.Entities.CategoriesEN", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "sports"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "science"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "politics"
                        });
                });

            modelBuilder.Entity("DemirorenProject.API.Entities.ImagesEN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("filename")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("filepath")
                        .HasColumnType("TEXT");

                    b.Property<int>("newsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("NewsImages");
                });

            modelBuilder.Entity("DemirorenProject.API.Entities.NewsEN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("NoOfViews")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Content = "This is the content for sports news",
                            Date = new DateTime(2023, 8, 10, 23, 57, 15, 594, DateTimeKind.Local).AddTicks(1569),
                            NoOfViews = 0,
                            Title = "Test"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Content = "This is the content for science news",
                            Date = new DateTime(2023, 8, 10, 23, 57, 15, 594, DateTimeKind.Local).AddTicks(1583),
                            NoOfViews = 0,
                            Title = "Test2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Content = "This is the content for politics news",
                            Date = new DateTime(2023, 8, 10, 23, 57, 15, 594, DateTimeKind.Local).AddTicks(1584),
                            NoOfViews = 0,
                            Title = "Test3"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Content = "This is the content for another politics news",
                            Date = new DateTime(2023, 8, 10, 23, 57, 15, 594, DateTimeKind.Local).AddTicks(1585),
                            NoOfViews = 0,
                            Title = "Test4"
                        });
                });

            modelBuilder.Entity("DemirorenProject.API.Entities.NewsReadEN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NewsID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("NewsRead");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NewsID = 1,
                            UserID = 2
                        },
                        new
                        {
                            Id = 2,
                            NewsID = 2,
                            UserID = 2
                        },
                        new
                        {
                            Id = 3,
                            NewsID = 2,
                            UserID = 1
                        });
                });

            modelBuilder.Entity("DemirorenProject.API.Entities.UsersEN", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "FirstNameTest1",
                            LastName = "LastNameTest1",
                            Password = "PasswordTest1",
                            Role = "admin",
                            UserName = "UserNameTest1"
                        },
                        new
                        {
                            UserId = 2,
                            FirstName = "FirstNameTest2",
                            LastName = "LastNameTest2",
                            Password = "PasswordTest2",
                            Role = "user",
                            UserName = "UserNameTest2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
