using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeLimpa.Migrations
{
    /// <inheritdoc />
    public partial class AddLixeiraParaColetaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LixeiraParaColeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataSolicitacao = table.Column<DateTime>(type: "date", nullable: false),
                    DataLimite = table.Column<DateTime>(type: "date", nullable: false),
                    Ativo = table.Column<bool>(type: "number(1)", nullable: false),
                    IdLixeira = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LixeiraParaColeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LixeiraParaColeta_Lixeira_IdLixeira",
                        column: x => x.IdLixeira,
                        principalTable: "Lixeira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LixeiraParaColeta_IdLixeira",
                table: "LixeiraParaColeta",
                column: "IdLixeira");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LixeiraParaColeta");
        }
    }
}
