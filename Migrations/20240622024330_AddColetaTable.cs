using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeLimpa.Migrations
{
    /// <inheritdoc />
    public partial class AddColetaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coleta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdCaminhao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdLixeira = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataColeta = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coleta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coleta_Caminhao_IdCaminhao",
                        column: x => x.IdCaminhao,
                        principalTable: "Caminhao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coleta_Lixeira_IdLixeira",
                        column: x => x.IdLixeira,
                        principalTable: "Lixeira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_IdCaminhao",
                table: "Coleta",
                column: "IdCaminhao");

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_IdLixeira",
                table: "Coleta",
                column: "IdLixeira");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coleta");
        }
    }
}
