using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace jautomulti.Migrations
{
    /// <inheritdoc />
    public partial class Dados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "251bbc7e-7737-4366-826a-0d72ddae97d6");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3e956114-2d9a-4884-b46f-949b1763e91d", 0, "e676fab8-84c3-44c4-8772-0522466eecf0", "joaopfbatista@gmail.com", false, false, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAENQofJuWN0CCnk8MF+cIpi/Y/r+vu2GSe88qsN4hjYjft7/prQaJAv4g1VOG482hJw==", null, false, "4b921ddc-96e3-40db-9c40-6f3d51ede1d2", false, "joaopfbatista@gmail.com" });

            migrationBuilder.InsertData(
                table: "Profissionais",
                columns: new[] { "Id", "Alcunha", "CodPostal", "Email", "Especializacao", "Morada", "Nome", "Telemovel" },
                values: new object[,]
                {
                    { 1, null, null, "jjj@gmail.com", "Eletricista", null, "José Silva", "951357852" },
                    { 2, null, null, "jjj@gmail.com", "Pintura", null, "Maria Gomes dos Santos", "951357852" },
                    { 3, null, null, "jjj@gmail.com", "Mecanica", null, "Ricardo Sousa", "951357852" }
                });

            migrationBuilder.InsertData(
                table: "Proprietarios",
                columns: new[] { "Id", "Email", "NIF", "Nome", "Sexo", "Telemovel" },
                values: new object[,]
                {
                    { 1, null, "813635582", "Luís Freitas", "M", null },
                    { 2, null, "854613462", "Andreia Gomes", "F", null },
                    { 3, null, "265368715", "Cristina Sousa", "F", null },
                    { 4, null, "835623190", "Sónia Rosa", "F", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e956114-2d9a-4884-b46f-949b1763e91d");

            migrationBuilder.DeleteData(
                table: "Profissionais",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profissionais",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profissionais",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "251bbc7e-7737-4366-826a-0d72ddae97d6", 0, "b26758cc-0fda-430f-a327-50e0b487f5f7", "joaopfbatista@gmail.com", false, false, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEH0Lu2Pj8XRBiCxzrkIiuYFLG/c/G+LDb6jV6/vf71wDt5x2WKQktYeVUkj/eBG43g==", null, false, "3c81662c-4e9d-4866-9f5e-e6e9f05fd4b6", false, "joaopfbatista@gmail.com" });
        }
    }
}
