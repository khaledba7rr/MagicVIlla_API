﻿// <auto-generated />
using System;
using MagicVIlla_VillaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVIlla_VillaAPI.Migrations
{
    [DbContext(typeof(VillaDbContext))]
    partial class VillaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVIlla_VillaAPI.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "Flatley Inc",
                            CreatedDate = new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(3965),
                            Details = "Supplement Left Temporomandibular Joint with Synthetic Substitute, Open Approach",
                            ImageUrl = "Image",
                            Name = "Bandon State Airport",
                            Occupancy = 1,
                            Rate = 4.4800000000000004,
                            Sqft = 123,
                            UpdatedDate = new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4016)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "Kreiger, Marquardt and Jast",
                            CreatedDate = new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4023),
                            Details = "Division of Oculomotor Nerve, Percutaneous Approach",
                            ImageUrl = "Image",
                            Name = "Taree Airport",
                            Occupancy = 2,
                            Rate = 8.0099999999999998,
                            Sqft = 183,
                            UpdatedDate = new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4024)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "Douglas, Smith and Herman",
                            CreatedDate = new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4028),
                            Details = "Revision of Autologous Tissue Substitute in Right Eye, Open Approach",
                            ImageUrl = "Image",
                            Name = "Dunhuang Airport",
                            Occupancy = 3,
                            Rate = 0.98999999999999999,
                            Sqft = 134,
                            UpdatedDate = new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4029)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "Yost, Parker and Quigley",
                            CreatedDate = new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4032),
                            Details = "Introduction of Other Therapeutic Substance into Female Reproductive, Via Natural or Artificial Opening",
                            ImageUrl = "Image",
                            Name = "Inisheer Aerodrome",
                            Occupancy = 4,
                            Rate = 1.24,
                            Sqft = 187,
                            UpdatedDate = new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4034)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "Dickinson-Greenholt",
                            CreatedDate = new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4036),
                            Details = "Stereotactic Gamma Beam Radiosurgery of Trachea",
                            ImageUrl = "Image",
                            Name = "Wabush Airport",
                            Occupancy = 5,
                            Rate = 9.6799999999999997,
                            Sqft = 74,
                            UpdatedDate = new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4038)
                        });
                });

            modelBuilder.Entity("MagicVIlla_VillaAPI.Models.VillaNumber", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("VillaNo");

                    b.HasIndex("VillaId");

                    b.ToTable("VillaNumbers");
                });

            modelBuilder.Entity("MagicVIlla_VillaAPI.Models.VillaNumber", b =>
                {
                    b.HasOne("MagicVIlla_VillaAPI.Models.Villa", "Villa")
                        .WithMany("VillaNumber")
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });

            modelBuilder.Entity("MagicVIlla_VillaAPI.Models.Villa", b =>
                {
                    b.Navigation("VillaNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
