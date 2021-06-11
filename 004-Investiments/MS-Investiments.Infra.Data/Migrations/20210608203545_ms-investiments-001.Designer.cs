﻿// <auto-generated />
using System;
using MS_Investiments.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MS_Investiments.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210608203545_ms-investiments-001")]
    partial class msinvestiments001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MS_Investiments.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("AccountAmount")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasDefaultValue(0m);

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Accounts", "Toro");
                });

            modelBuilder.Entity("MS_Investiments.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<decimal>("Value")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Orders", "Toro");
                });

            modelBuilder.Entity("MS_Investiments.Domain.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CurrentPrice")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("Stocks", "Toro");
                });

            modelBuilder.Entity("MS_Investiments.Domain.Entities.Order", b =>
                {
                    b.HasOne("MS_Investiments.Domain.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
