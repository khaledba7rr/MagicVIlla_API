using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVIlla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Flatley Inc", new DateTime(2024, 5, 5, 1, 38, 58, 507, DateTimeKind.Local).AddTicks(5512), "Supplement Left Temporomandibular Joint with Synthetic Substitute, Open Approach", "Image", "Bandon State Airport", 1, 4.4800000000000004, 123, new DateTime(2024, 5, 5, 1, 38, 58, 507, DateTimeKind.Local).AddTicks(5577) },
                    { 2, "Kreiger, Marquardt and Jast", new DateTime(2024, 5, 5, 1, 38, 58, 507, DateTimeKind.Local).AddTicks(5584), "Division of Oculomotor Nerve, Percutaneous Approach", "Image", "Taree Airport", 2, 8.0099999999999998, 183, new DateTime(2024, 5, 5, 1, 38, 58, 507, DateTimeKind.Local).AddTicks(5587) },
                    { 3, "Douglas, Smith and Herman", new DateTime(2024, 5, 5, 1, 38, 58, 507, DateTimeKind.Local).AddTicks(5592), "Revision of Autologous Tissue Substitute in Right Eye, Open Approach", "Image", "Dunhuang Airport", 3, 0.98999999999999999, 134, new DateTime(2024, 5, 5, 1, 38, 58, 507, DateTimeKind.Local).AddTicks(5594) },
                    { 4, "Yost, Parker and Quigley", new DateTime(2024, 5, 5, 1, 38, 58, 507, DateTimeKind.Local).AddTicks(5598), "Introduction of Other Therapeutic Substance into Female Reproductive, Via Natural or Artificial Opening", "Image", "Inisheer Aerodrome", 4, 1.24, 187, new DateTime(2024, 5, 5, 1, 38, 58, 507, DateTimeKind.Local).AddTicks(5600) },
                    { 5, "Dickinson-Greenholt", new DateTime(2024, 5, 5, 1, 38, 58, 507, DateTimeKind.Local).AddTicks(5603), "Stereotactic Gamma Beam Radiosurgery of Trachea", "Image", "Wabush Airport", 5, 9.6799999999999997, 74, new DateTime(2024, 5, 5, 1, 38, 58, 507, DateTimeKind.Local).AddTicks(5605) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
