using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVIlla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(3965), new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4016) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4023), new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4024) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4028), new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4029) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4032), new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4034) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4036), new DateTime(2024, 5, 15, 15, 48, 32, 121, DateTimeKind.Local).AddTicks(4038) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 8, 15, 50, 39, 984, DateTimeKind.Local).AddTicks(7356), new DateTime(2024, 5, 8, 15, 50, 39, 984, DateTimeKind.Local).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 8, 15, 50, 39, 984, DateTimeKind.Local).AddTicks(7417), new DateTime(2024, 5, 8, 15, 50, 39, 984, DateTimeKind.Local).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 8, 15, 50, 39, 984, DateTimeKind.Local).AddTicks(7422), new DateTime(2024, 5, 8, 15, 50, 39, 984, DateTimeKind.Local).AddTicks(7423) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 8, 15, 50, 39, 984, DateTimeKind.Local).AddTicks(7426), new DateTime(2024, 5, 8, 15, 50, 39, 984, DateTimeKind.Local).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 8, 15, 50, 39, 984, DateTimeKind.Local).AddTicks(7430), new DateTime(2024, 5, 8, 15, 50, 39, 984, DateTimeKind.Local).AddTicks(7431) });
        }
    }
}
