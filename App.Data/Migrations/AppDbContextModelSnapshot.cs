﻿// <auto-generated />
using System;
using App.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Data.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 9, 7, 20, 6, 23, 516, DateTimeKind.Utc).AddTicks(6180),
                            Description = "Description of product 1",
                            Name = "Product1",
                            Price = 10.0,
                            Stock = 100
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 9, 7, 20, 6, 23, 516, DateTimeKind.Utc).AddTicks(6191),
                            Description = "Description of product 2",
                            Name = "Product2",
                            Price = 20.0,
                            Stock = 50
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 9, 7, 20, 6, 23, 516, DateTimeKind.Utc).AddTicks(6192),
                            Description = "Description of product 3",
                            Name = "Product3",
                            Price = 15.0,
                            Stock = 75
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
