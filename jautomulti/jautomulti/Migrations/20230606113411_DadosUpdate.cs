using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jautomulti.Migrations
{
    /// <inheritdoc />
    public partial class DadosUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e956114-2d9a-4884-b46f-949b1763e91d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e48629eb-cbf6-4edc-9cee-ffe31b042104", 0, "3182f07e-98fb-4ca6-aa3e-a841c5e81703", "joaopfbatista@gmail.com", false, false, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEG4ob8OPZKhxQSg94HdUxprutMIvi4rKmg8evFEAzee5QKGL1idugoakythCixgIzw==", null, false, "d60e4a2e-24d8-4d7c-a452-7e2658ea756f", false, "joaopfbatista@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Telemovel" },
                values: new object[] { "Luis@gmail.com", "123456789" });

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Telemovel" },
                values: new object[] { "As@gmail.com", "123456789" });

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Telemovel" },
                values: new object[] { "Cris@gmail.com", "123456789" });

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Telemovel" },
                values: new object[] { "so@gmail.com", "123456789" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e48629eb-cbf6-4edc-9cee-ffe31b042104");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3e956114-2d9a-4884-b46f-949b1763e91d", 0, "e676fab8-84c3-44c4-8772-0522466eecf0", "joaopfbatista@gmail.com", false, false, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAENQofJuWN0CCnk8MF+cIpi/Y/r+vu2GSe88qsN4hjYjft7/prQaJAv4g1VOG482hJw==", null, false, "4b921ddc-96e3-40db-9c40-6f3d51ede1d2", false, "joaopfbatista@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Telemovel" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Telemovel" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Telemovel" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Telemovel" },
                values: new object[] { null, null });
        }
    }
}
