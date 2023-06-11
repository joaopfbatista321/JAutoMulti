using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jautomulti.Migrations
{
    /// <inheritdoc />
    public partial class NewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22f51889-d438-43ff-9612-dec648c3eafe");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataRegisto", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NomeDoUtilizador", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9e0929e8-7aed-4f7a-be9d-5c1c45038b31", 0, "54f69d09-e9b8-4968-88e5-0e94e7746c0e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joaopfbatista@gmail.com", false, false, null, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEJbvYwpP4cgolQwzAHlkZqKsIad7fu8GPD55PtY+3NM81rY81sFWd6Ny8psxd+j76A==", null, false, "ca238e78-315f-40df-9d22-f40ecb3987aa", false, "joaopfbatista@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e0929e8-7aed-4f7a-be9d-5c1c45038b31");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataRegisto", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NomeDoUtilizador", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22f51889-d438-43ff-9612-dec648c3eafe", 0, "434abff9-aeb0-48bc-a355-c6623e34c63f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joaopfbatista@gmail.com", false, false, null, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEOhi/cIcC6Q82YzSLSH00ySnK4fH81KKpApShkyLBp9dZ4ASInI2ICp/RAAsHbNE/A==", null, false, "fdc68d2d-ec19-4440-8674-3725bf1e21b3", false, "joaopfbatista@gmail.com" });
        }
    }
}
