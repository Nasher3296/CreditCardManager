﻿// <auto-generated />
using System;
using CreditCardManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CreditCardManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250102010842_payerMigration")]
    partial class payerMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CreditCardManager.Models.Movement.Movement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstallmentsQty")
                        .HasColumnType("int");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PayerId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("CreditCardManager.Models.Payers.Payer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payer");
                });

            modelBuilder.Entity("CreditCardManager.Models.Movement.Movement", b =>
                {
                    b.HasOne("CreditCardManager.Models.Payers.Payer", "Payer")
                        .WithMany()
                        .HasForeignKey("PayerId");

                    b.Navigation("Payer");
                });
#pragma warning restore 612, 618
        }
    }
}
