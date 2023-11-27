﻿// <auto-generated />
using System;
using Categories.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Categories.API.Database.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Categories.API.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Abbrev")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsHidden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ShortDisplay")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Tenant")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("402ab577-379f-4e42-86ea-9ecf2e454dd5"),
                            Abbrev = "SC",
                            CreatedAt = new DateTime(2023, 11, 27, 13, 16, 27, 484, DateTimeKind.Utc).AddTicks(6520),
                            IsDeleted = false,
                            IsHidden = false,
                            ShortDisplay = "Sidearm Category",
                            ShortName = "SCat",
                            Tenant = "Sidearmu",
                            Title = "The Sidearm Category"
                        },
                        new
                        {
                            Id = new Guid("be4cc0d7-029c-45b6-a121-726a53ccd21a"),
                            Abbrev = "OC1",
                            CreatedAt = new DateTime(2023, 11, 27, 13, 16, 27, 484, DateTimeKind.Utc).AddTicks(6560),
                            IsDeleted = false,
                            IsHidden = false,
                            ShortDisplay = "Oklahoma Category #1",
                            ShortName = "OklCategory#1",
                            Tenant = "Oklahoma",
                            Title = "The Oklahoma Category #1"
                        },
                        new
                        {
                            Id = new Guid("0fdc6594-102f-4f05-872b-6746b65bdee9"),
                            Abbrev = "OC2",
                            CreatedAt = new DateTime(2023, 11, 27, 13, 16, 27, 484, DateTimeKind.Utc).AddTicks(6560),
                            IsDeleted = false,
                            IsHidden = false,
                            ShortDisplay = "Oklahoma Category #2",
                            ShortName = "OklCategory#2",
                            Tenant = "Oklahoma",
                            Title = "The Oklahoma Category #2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}