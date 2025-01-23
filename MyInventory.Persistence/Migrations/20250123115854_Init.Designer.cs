﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyInventory.Persistence.Context;

#nullable disable

namespace MyInventory.Persistence.Migrations
{
    [DbContext(typeof(MyInventoryDbContext))]
    [Migration("20250123115854_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyInventory.Domain.Entities.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"));

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AssignedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignedUserLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignmentFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("EquipmentId")
                        .IsUnique();

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.AssignmentHistory", b =>
                {
                    b.Property<int>("AssignmentHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentHistoryId"));

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AssignedFinishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AssignedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignedUserLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignmentFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentHistoryId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("AssignmentHistories");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.EquipmentImage", b =>
                {
                    b.Property<int>("EquipmentImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentImageId"));

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentImageId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("EquipmentImages");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.Assignment", b =>
                {
                    b.HasOne("MyInventory.Domain.Entities.Equipment", "Equipment")
                        .WithOne("Assignment")
                        .HasForeignKey("MyInventory.Domain.Entities.Assignment", "EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.AssignmentHistory", b =>
                {
                    b.HasOne("MyInventory.Domain.Entities.Equipment", "Equipment")
                        .WithMany("AssignmentHistories")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.Equipment", b =>
                {
                    b.HasOne("MyInventory.Domain.Entities.Category", "Category")
                        .WithMany("Equipments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyInventory.Domain.Entities.Location", "Location")
                        .WithMany("Equipments")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.EquipmentImage", b =>
                {
                    b.HasOne("MyInventory.Domain.Entities.Equipment", "Equipment")
                        .WithMany("EquipmentImages")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.Category", b =>
                {
                    b.Navigation("Equipments");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.Equipment", b =>
                {
                    b.Navigation("Assignment")
                        .IsRequired();

                    b.Navigation("AssignmentHistories");

                    b.Navigation("EquipmentImages");
                });

            modelBuilder.Entity("MyInventory.Domain.Entities.Location", b =>
                {
                    b.Navigation("Equipments");
                });
#pragma warning restore 612, 618
        }
    }
}
