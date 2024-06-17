﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TypicalTechTools.DataAccess;

#nullable disable

namespace TypicalTechTools.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240425020815_FixedLogin")]
    partial class FixedLogin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TypicalTechTools.Models.AdminUser", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("AdminUsers");

                    b.HasData(
                        new
                        {
                            AdminId = 1,
                            Password = "$2a$11$7VYwrcFABlWNA7SMUHkatec5/Mlkch6ww0gCViAc.5bRKecCAK29e",
                            Username = "Admin"
                        });
                });

            modelBuilder.Entity("TypicalTechTools.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            CommentText = "This is a great product. Highly Recommended.",
                            ProductId = 12345
                        },
                        new
                        {
                            CommentId = 2,
                            CommentText = "Not worth the excessive price. Stick with a cheaper generic one.",
                            ProductId = 12350
                        },
                        new
                        {
                            CommentId = 3,
                            CommentText = "A great budget buy. As good as some of the expensive alternatives.",
                            ProductId = 12345
                        },
                        new
                        {
                            CommentId = 4,
                            CommentText = "Total garbage. Never buying this brand again. ",
                            ProductId = 12347
                        });
                });

            modelBuilder.Entity("TypicalTechTools.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 12345,
                            ProductDescription = " bluetooth headphones with fair battery life and a 1 month warranty",
                            ProductName = " Generic Headphones",
                            ProductPrice = 84.99m
                        },
                        new
                        {
                            ProductId = 12346,
                            ProductDescription = " bluetooth headphones with good battery life and a 6 month warranty",
                            ProductName = " Expensive Headphones",
                            ProductPrice = 149.99m
                        },
                        new
                        {
                            ProductId = 12347,
                            ProductDescription = " bluetooth headphones with good battery life and a 12 month warranty",
                            ProductName = " Name Brand Headphones",
                            ProductPrice = 199.99m
                        },
                        new
                        {
                            ProductId = 12348,
                            ProductDescription = " simple bluetooth pointing device",
                            ProductName = " Generic Wireless Mouse",
                            ProductPrice = 39.99m
                        },
                        new
                        {
                            ProductId = 12349,
                            ProductDescription = " mouse and keyboard wired combination",
                            ProductName = " Logitach Mouse and Keyboard",
                            ProductPrice = 73.99m
                        },
                        new
                        {
                            ProductId = 12350,
                            ProductDescription = " quality wireless mouse",
                            ProductName = " Logitach Wireless Mouse",
                            ProductPrice = 149.99m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}