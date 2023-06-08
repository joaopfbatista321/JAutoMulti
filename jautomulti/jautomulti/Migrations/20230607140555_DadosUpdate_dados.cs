using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jautomulti.Migrations
{
    /// <inheritdoc />
    public partial class DadosUpdate_dados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e48629eb-cbf6-4edc-9cee-ffe31b042104");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "985f6efc-eb2f-4c49-a52b-0691b51dddaa", 0, "5bdd2c1c-7451-4cb5-9a0f-bd0fdd2261b9", "joaopfbatista@gmail.com", false, false, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEB2UR0lCjs2YjWBD65yI/uBEw82TF1nc39UKg5teGGP4dV8lwPjlEctEXZoki6Ujww==", null, false, "23b008cf-8a13-4d13-ab37-7817e1e9e978", false, "joaopfbatista@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "985f6efc-eb2f-4c49-a52b-0691b51dddaa");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e48629eb-cbf6-4edc-9cee-ffe31b042104", 0, "3182f07e-98fb-4ca6-aa3e-a841c5e81703", "joaopfbatista@gmail.com", false, false, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEG4ob8OPZKhxQSg94HdUxprutMIvi4rKmg8evFEAzee5QKGL1idugoakythCixgIzw==", null, false, "d60e4a2e-24d8-4d7c-a452-7e2658ea756f", false, "joaopfbatista@gmail.com" });
        }
    }
}
