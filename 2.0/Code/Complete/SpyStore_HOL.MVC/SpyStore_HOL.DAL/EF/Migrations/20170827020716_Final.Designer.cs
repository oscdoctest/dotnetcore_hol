﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SpyStore_HOL.DAL.EF;
using System;

namespace SpyStore_HOL.DAL.EF.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20170827020716_Final")]
    partial class Final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpyStore_HOL.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Categories","Store");
                });

            modelBuilder.Entity("SpyStore_HOL.Models.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique()
                        .HasName("IX_Customers");

                    b.ToTable("Customers","Store");
                });

            modelBuilder.Entity("SpyStore_HOL.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<decimal?>("OrderTotal")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("money")
                        .HasComputedColumnSql("Store.GetOrderTotal([Id])");

                    b.Property<DateTime>("ShipDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders","Store");
                });

            modelBuilder.Entity("SpyStore_HOL.Models.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("LineItemTotal")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("money")
                        .HasComputedColumnSql("[Quantity]*[UnitCost]");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails","Store");
                });

            modelBuilder.Entity("SpyStore_HOL.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .HasMaxLength(3800);

                    b.Property<bool>("IsFeatured");

                    b.Property<string>("ModelName")
                        .HasMaxLength(50);

                    b.Property<string>("ModelNumber")
                        .HasMaxLength(50);

                    b.Property<string>("ProductImage")
                        .HasMaxLength(150);

                    b.Property<string>("ProductImageLarge")
                        .HasMaxLength(150);

                    b.Property<string>("ProductImageThumb")
                        .HasMaxLength(150);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("money");

                    b.Property<int>("UnitsInStock");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products","Store");
                });

            modelBuilder.Entity("SpyStore_HOL.Models.Entities.ShoppingCartRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<decimal>("LineItemTotal");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity")
                        .HasDefaultValue(1);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("Id", "ProductId", "CustomerId")
                        .IsUnique()
                        .HasName("IX_ShoppingCart");

                    b.ToTable("ShoppingCartRecords","Store");
                });

            modelBuilder.Entity("SpyStore_HOL.Models.Entities.Order", b =>
                {
                    b.HasOne("SpyStore_HOL.Models.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpyStore_HOL.Models.Entities.OrderDetail", b =>
                {
                    b.HasOne("SpyStore_HOL.Models.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpyStore_HOL.Models.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpyStore_HOL.Models.Entities.Product", b =>
                {
                    b.HasOne("SpyStore_HOL.Models.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpyStore_HOL.Models.Entities.ShoppingCartRecord", b =>
                {
                    b.HasOne("SpyStore_HOL.Models.Entities.Customer", "Customer")
                        .WithMany("ShoppingCartRecords")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpyStore_HOL.Models.Entities.Product", "Product")
                        .WithMany("ShoppingCartRecords")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
