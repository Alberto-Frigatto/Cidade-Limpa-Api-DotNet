using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeLimpa.Migrations
{
    /// <inheritdoc />
    public partial class AddCaminhaoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caminhao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Modelo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Capacidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Placa = table.Column<string>(type: "NVARCHAR2(7)", maxLength: 7, nullable: false),
                    IdRota = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caminhao_Rota_IdRota",
                        column: x => x.IdRota,
                        principalTable: "Rota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caminhao_IdRota",
                table: "Caminhao",
                column: "IdRota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caminhao");
        }
    }
}
