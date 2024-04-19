﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using News.Persistence.Context;

#nullable disable

namespace News.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240419195954_AddedNewsAndNewsCategory")]
    partial class AddedNewsAndNewsCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("News.Domain.Entities.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ReadCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorName = "Braun, Hackett and Blanda",
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 4, 19, 23, 59, 54, 436, DateTimeKind.Local).AddTicks(3285),
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            ImagePath = "Awesome Wooden Chicken",
                            IsDeleted = false,
                            ReadCount = 0,
                            Title = "Handmade Steel Towels"
                        },
                        new
                        {
                            Id = 2,
                            AuthorName = "Langworth and Sons",
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 4, 19, 23, 59, 54, 436, DateTimeKind.Local).AddTicks(3570),
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            ImagePath = "Unbranded Wooden Sausages",
                            IsDeleted = false,
                            ReadCount = 5,
                            Title = "Ergonomic Cotton Towels"
                        },
                        new
                        {
                            Id = 3,
                            AuthorName = "Altenwerth - Haag",
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 4, 19, 23, 59, 54, 436, DateTimeKind.Local).AddTicks(3888),
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            ImagePath = "Unbranded Soft Gloves",
                            IsDeleted = false,
                            ReadCount = 10,
                            Title = "Sleek Wooden Chair"
                        },
                        new
                        {
                            Id = 4,
                            AuthorName = "Auer LLC",
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 4, 19, 23, 59, 54, 436, DateTimeKind.Local).AddTicks(4100),
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            ImagePath = "Intelligent Metal Towels",
                            IsDeleted = false,
                            ReadCount = 15,
                            Title = "Sleek Metal Salad"
                        });
                });

            modelBuilder.Entity("News.Domain.Entities.NewsCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("NewsCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 4, 19, 23, 59, 54, 433, DateTimeKind.Local).AddTicks(7775),
                            IsDeleted = false,
                            Name = "Music"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 4, 19, 23, 59, 54, 433, DateTimeKind.Local).AddTicks(7842),
                            IsDeleted = false,
                            Name = "Toys"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 4, 19, 23, 59, 54, 433, DateTimeKind.Local).AddTicks(7852),
                            IsDeleted = false,
                            Name = "Music"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 4, 19, 23, 59, 54, 433, DateTimeKind.Local).AddTicks(7861),
                            IsDeleted = false,
                            Name = "Movies"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 4, 19, 23, 59, 54, 433, DateTimeKind.Local).AddTicks(7870),
                            IsDeleted = false,
                            Name = "Kids"
                        });
                });

            modelBuilder.Entity("News.Domain.Entities.News", b =>
                {
                    b.HasOne("News.Domain.Entities.NewsCategory", "Category")
                        .WithMany("News")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("News.Domain.Entities.NewsCategory", b =>
                {
                    b.Navigation("News");
                });
#pragma warning restore 612, 618
        }
    }
}
