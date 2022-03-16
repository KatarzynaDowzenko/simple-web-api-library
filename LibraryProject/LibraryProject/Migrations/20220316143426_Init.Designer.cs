﻿// <auto-generated />
using System;
using LibraryProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryProject.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20220316143426_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("LibraryProject.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AuthoLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("IdBookStatus")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TypeOfBook")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryProject.Entities.BookStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("BooksStatus");
                });

            modelBuilder.Entity("LibraryProject.Entities.BorrowedBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfBorrowingBook")
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfReturningBook")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdBook")
                        .HasColumnType("int");

                    b.Property<int>("IdCostumer")
                        .HasColumnType("int");

                    b.Property<int?>("bookId")
                        .HasColumnType("int");

                    b.Property<int?>("customerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("bookId");

                    b.HasIndex("customerId");

                    b.ToTable("BorrowedBooks");
                });

            modelBuilder.Entity("LibraryProject.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfBirth")
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LibraryProject.Entities.Book", b =>
                {
                    b.HasOne("LibraryProject.Entities.BookStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("LibraryProject.Entities.BorrowedBook", b =>
                {
                    b.HasOne("LibraryProject.Entities.Book", "book")
                        .WithMany()
                        .HasForeignKey("bookId");

                    b.HasOne("LibraryProject.Entities.Customer", "customer")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("customerId");

                    b.Navigation("book");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("LibraryProject.Entities.Customer", b =>
                {
                    b.Navigation("BorrowedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}