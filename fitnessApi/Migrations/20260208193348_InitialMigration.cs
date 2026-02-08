using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fitnessApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GruposMusculares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_GRUPO_MUSCULAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO_GRUPO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposMusculares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musculos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_MUSCULO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MOVIMENTO_PRINCIPAL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FUNCAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIPO_TECIDO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GRUPO_MUSCULAR_ID = table.Column<int>(type: "int", nullable: false),
                    FIBRA_MUSCULAR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musculos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Musculos_GruposMusculares_GRUPO_MUSCULAR_ID",
                        column: x => x.GRUPO_MUSCULAR_ID,
                        principalTable: "GruposMusculares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_EXERCICIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO_EXERCICIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MUSCULOS_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exercicios_Musculos_MUSCULOS_ID",
                        column: x => x.MUSCULOS_ID,
                        principalTable: "Musculos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_MUSCULOS_ID",
                table: "Exercicios",
                column: "MUSCULOS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Musculos_GRUPO_MUSCULAR_ID",
                table: "Musculos",
                column: "GRUPO_MUSCULAR_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Musculos");

            migrationBuilder.DropTable(
                name: "GruposMusculares");
        }
    }
}
