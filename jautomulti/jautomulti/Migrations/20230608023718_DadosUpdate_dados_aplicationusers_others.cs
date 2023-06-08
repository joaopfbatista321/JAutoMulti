using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jautomulti.Migrations
{
    /// <inheritdoc />
    public partial class DadosUpdate_dados_aplicationusers_others : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "1925379c-49dd-4b5e-88e3-9db88e23b927");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Proprietarios",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "559541c2-5816-4b3e-ba09-b4dd3d88d5c8", 0, "dce2d364-8446-4581-8d9b-ec76c7bc84cd", "joaopfbatista@gmail.com", false, false, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEGjohSkiuHp46Bh1l2cC82C470+dCTX7Hl4Y3PIQ4sHq7voAA0qAJlT/fqhsDqpSng==", null, false, "95c03a1d-0b59-47bc-abd4-ba5833ed4862", false, "joaopfbatista@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Proprietarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserID",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "559541c2-5816-4b3e-ba09-b4dd3d88d5c8");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Proprietarios");

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1925379c-49dd-4b5e-88e3-9db88e23b927", 0, "3b1caf81-58dd-4e0c-a3f4-b8809b2b0073", "joaopfbatista@gmail.com", false, false, null, "JOAOPFBATISTA@GMAIL.COM", "JOAOPFBATISTA@GMAIL.COM", "AQAAAAIAAYagAAAAEKt4ojIAhrgRu5L22T8Gbv1NcoqK7LarTuTvI7wKNSTatokPf5tBGKmTqx76etAzjw==", null, false, "841ab844-c53e-4cb9-8c66-ce465aa37ec6", false, "joaopfbatista@gmail.com" });
        }
    }
}
