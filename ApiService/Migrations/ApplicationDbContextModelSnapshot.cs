﻿// <auto-generated />
using System;
using ApiService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiService.Models.CanvasItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("BufferHeight")
                        .HasColumnType("real");

                    b.Property<float>("BufferWidth")
                        .HasColumnType("real");

                    b.Property<Guid>("CatalogItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("PlantingPadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.Property<float>("X")
                        .HasColumnType("real");

                    b.Property<float>("Y")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PlantingPadId");

                    b.ToTable("CanvasItems");
                });

            modelBuilder.Entity("ApiService.Models.CatalogItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("CatalogItems");

                    b.HasDiscriminator<string>("ItemType").HasValue("CatalogItem");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ApiService.Models.PlantingPad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("PlantingPads");
                });

            modelBuilder.Entity("ApiService.Models.PlantingPadVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlantingPadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SerializedData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VersionNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PlantingPadId");

                    b.ToTable("PlantingPadVersion");
                });

            modelBuilder.Entity("ApiService.Models.Plant", b =>
                {
                    b.HasBaseType("ApiService.Models.CatalogItem");

                    b.Property<int?>("DaysToGerminate")
                        .HasColumnType("int");

                    b.Property<int?>("DaysToMaturity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("HardinessZoneLower")
                        .HasColumnType("int");

                    b.Property<int?>("HardinessZoneUpper")
                        .HasColumnType("int");

                    b.Property<int?>("MinSunLower")
                        .HasColumnType("int");

                    b.Property<int?>("MinSunUpper")
                        .HasColumnType("int");

                    b.Property<int?>("MinWaterLower")
                        .HasColumnType("int");

                    b.Property<int?>("MinWaterUpper")
                        .HasColumnType("int");

                    b.Property<float?>("PlantSpacing")
                        .HasColumnType("real");

                    b.Property<string>("PlantingInstructions")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<float?>("RowSpacing")
                        .HasColumnType("real");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("StartIndoors")
                        .HasColumnType("bit");

                    b.Property<int?>("StartIndoorsWeeksLower")
                        .HasColumnType("int");

                    b.Property<int?>("StartIndoorsWeeksUpper")
                        .HasColumnType("int");

                    b.Property<int?>("StartOutdoorsWeeksLower")
                        .HasColumnType("int");

                    b.Property<int?>("StartOutdoorsWeeksUpper")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Plant");
                });

            modelBuilder.Entity("ApiService.Models.CanvasItem", b =>
                {
                    b.HasOne("ApiService.Models.PlantingPad", null)
                        .WithMany("CanvasItems")
                        .HasForeignKey("PlantingPadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiService.Models.PlantingPadVersion", b =>
                {
                    b.HasOne("ApiService.Models.PlantingPad", "PlantingPad")
                        .WithMany("Versions")
                        .HasForeignKey("PlantingPadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlantingPad");
                });

            modelBuilder.Entity("ApiService.Models.PlantingPad", b =>
                {
                    b.Navigation("CanvasItems");

                    b.Navigation("Versions");
                });
#pragma warning restore 612, 618
        }
    }
}
