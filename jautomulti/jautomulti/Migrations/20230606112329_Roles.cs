using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace jautomulti.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f6c32ff8-a06c-487b-ac18-3b83cafd97f2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "adm", null, "Admin", "ADMINISTRADOR" },
                    { "cli", null, "Cliente", "CLIENTE" },
                    { "prof", null, "Profissional", "PROFISSIONAL" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "251bbc7e-7737-4366-826a-0d72ddae97d6", 0, "b26758cc-0fda-430f-a327-50e0b487f5f7", "joaopfbatista@gmail.com", false, false, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEH0Lu2Pj8XRBiCxzrkIiuYFLG/c/G+LDb6jV6/vf71wDt5x2WKQktYeVUkj/eBG43g==", null, false, "3c81662c-4e9d-4866-9f5e-e6e9f05fd4b6", false, "joaopfbatista@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adm");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cli");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "prof");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "251bbc7e-7737-4366-826a-0d72ddae97d6");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f6c32ff8-a06c-487b-ac18-3b83cafd97f2", 0, "8d3b5e25-e77a-4b42-9238-852bf649d64c", "joaopfbatista@gmail.com", false, false, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEHu4KTgJZV64yJR/eUlsSVORKKXcDgZ85v/L0Ua0lgCHbEWZ4lV9LgRhOXqLA9EOWA==", null, false, "83a21b72-7cab-4d3d-b009-98751c8fe445", false, "joaopfbatista@gmail.com" });
        }
    }
}
