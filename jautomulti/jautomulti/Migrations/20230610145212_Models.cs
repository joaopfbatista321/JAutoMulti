using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jautomulti.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_AspNetUsers_UserID",
                table: "Profissionais");

            migrationBuilder.DropForeignKey(
                name: "FK_Proprietarios_AspNetUsers_UserID",
                table: "Proprietarios");

            migrationBuilder.DropIndex(
                name: "IX_Proprietarios_UserID",
                table: "Proprietarios");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_UserID",
                table: "Profissionais");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e0929e8-7aed-4f7a-be9d-5c1c45038b31");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Proprietarios",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Profissionais",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIF",
                table: "Profissionais",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Profissionais",
                type: "varchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataRegisto", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NomeDoUtilizador", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "93074ffb-b892-4024-9a87-5c2b26889c1c", 0, "c61ca6ba-80ad-4b03-9cc1-1a2229a5483f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joaopfbatista@gmail.com", false, false, null, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEGI1rmJVgJxTJ66A1SH3bMtUG500Vis+pfDSNygBE48t0nzVFStpLepMd9y6WOJ8ZQ==", null, false, "23c6d514-8dd5-4e94-8f2b-986610259ae7", false, "joaopfbatista@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Profissionais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NIF", "Sexo" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Profissionais",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NIF", "Sexo" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Profissionais",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NIF", "Sexo" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93074ffb-b892-4024-9a87-5c2b26889c1c");

            migrationBuilder.DropColumn(
                name: "NIF",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Profissionais");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Proprietarios",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Profissionais",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataRegisto", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NomeDoUtilizador", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9e0929e8-7aed-4f7a-be9d-5c1c45038b31", 0, "54f69d09-e9b8-4968-88e5-0e94e7746c0e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joaopfbatista@gmail.com", false, false, null, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEJbvYwpP4cgolQwzAHlkZqKsIad7fu8GPD55PtY+3NM81rY81sFWd6Ny8psxd+j76A==", null, false, "ca238e78-315f-40df-9d22-f40ecb3987aa", false, "joaopfbatista@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Proprietarios_UserID",
                table: "Proprietarios",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_UserID",
                table: "Profissionais",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_AspNetUsers_UserID",
                table: "Profissionais",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proprietarios_AspNetUsers_UserID",
                table: "Proprietarios",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
