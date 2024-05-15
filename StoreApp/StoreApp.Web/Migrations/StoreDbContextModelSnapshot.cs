﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreApp.data.Concrete;

#nullable disable

namespace StoreApp.web.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreApp.data.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Telefon",
                            Description = "İphone",
                            Name = "İphone 10",
                            Price = 20000m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Telefon",
                            Description = "İphone",
                            Name = "İphone 11",
                            Price = 25000m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Telefon",
                            Description = "İphone",
                            Name = "İphone 12",
                            Price = 30000m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Telefon",
                            Description = "İphone",
                            Name = "İphone 13",
                            Price = 35000m
                        },
                        new
                        {
                            Id = 5,
                            Category = "Telefon",
                            Description = "İphone",
                            Name = "İphone 14",
                            Price = 40000m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
