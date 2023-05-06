using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace jautomulti.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mecanics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Alcunha = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Morada = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    CodPostal = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Telemovel = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecanics", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VIN = table.Column<string>(type: "longtext", nullable: true),
                    DataMatricula = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Tipo = table.Column<string>(type: "longtext", nullable: true),
                    Matricula = table.Column<string>(type: "longtext", nullable: true),
                    MecanicoFK = table.Column<int>(type: "int", nullable: false),
                    MarcaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_Marcas_MarcaFK",
                        column: x => x.MarcaFK,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carros_Mecanics_MecanicoFK",
                        column: x => x.MecanicoFK,
                        principalTable: "Mecanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MarcasMecanicos",
                columns: table => new
                {
                    ListaMarcasId = table.Column<int>(type: "int", nullable: false),
                    ListaMecanicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcasMecanicos", x => new { x.ListaMarcasId, x.ListaMecanicosId });
                    table.ForeignKey(
                        name: "FK_MarcasMecanicos_Marcas_ListaMarcasId",
                        column: x => x.ListaMarcasId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcasMecanicos_Mecanics_ListaMecanicosId",
                        column: x => x.ListaMecanicosId,
                        principalTable: "Mecanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fotografias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NomeFicheiro = table.Column<string>(type: "longtext", nullable: true),
                    Local = table.Column<string>(type: "longtext", nullable: true),
                    DataFotografia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CarroFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotografias_Carros_CarroFK",
                        column: x => x.CarroFK,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_MarcaFK",
                table: "Carros",
                column: "MarcaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_MecanicoFK",
                table: "Carros",
                column: "MecanicoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografias_CarroFK",
                table: "Fotografias",
                column: "CarroFK");

            migrationBuilder.CreateIndex(
                name: "IX_MarcasMecanicos_ListaMecanicosId",
                table: "MarcasMecanicos",
                column: "ListaMecanicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotografias");

            migrationBuilder.DropTable(
                name: "MarcasMecanicos");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Mecanics");
        }
    }
}
