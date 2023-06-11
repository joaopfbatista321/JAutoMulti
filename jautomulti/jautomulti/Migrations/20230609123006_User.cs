using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jautomulti.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f90c7de-775d-49d9-b696-f648cd7e54d9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataRegisto", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NomeDoUtilizador", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22f51889-d438-43ff-9612-dec648c3eafe", 0, "434abff9-aeb0-48bc-a355-c6623e34c63f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joaopfbatista@gmail.com", false, false, null, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEOhi/cIcC6Q82YzSLSH00ySnK4fH81KKpApShkyLBp9dZ4ASInI2ICp/RAAsHbNE/A==", null, false, "fdc68d2d-ec19-4440-8674-3725bf1e21b3", false, "joaopfbatista@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22f51889-d438-43ff-9612-dec648c3eafe");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataRegisto", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NomeDoUtilizador", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2f90c7de-775d-49d9-b696-f648cd7e54d9", 0, "e6bc5e8e-7661-4d87-8bd3-3cc678655931", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joaopfbatista@gmail.com", false, false, null, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEEm5/tQ6i9PIGOr6BaD6QJ801vp6tqhE0O2e8Lj2VTbnVQrc5sERd766U7ytuMR8IA==", null, false, "adaebc43-52ff-4248-a6bd-5f9c59c650cc", false, "joaopfbatista@gmail.com" });
        }
    }
}
