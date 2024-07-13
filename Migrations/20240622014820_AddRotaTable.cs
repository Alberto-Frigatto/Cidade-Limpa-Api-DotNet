using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeLimpa.Migrations
{
    /// <inheritdoc />
    public partial class AddRotaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRota",
                table: "PontoColeta",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HorarioInicio = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: false),
                    HorarioFim = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rota", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PontoColeta_IdRota",
                table: "PontoColeta",
                column: "IdRota");

            migrationBuilder.AddForeignKey(
                name: "FK_PontoColeta_Rota_IdRota",
                table: "PontoColeta",
                column: "IdRota",
                principalTable: "Rota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontoColeta_Rota_IdRota",
                table: "PontoColeta");

            migrationBuilder.DropTable(
                name: "Rota");

            migrationBuilder.DropIndex(
                name: "IX_PontoColeta_IdRota",
                table: "PontoColeta");

            migrationBuilder.DropColumn(
                name: "IdRota",
                table: "PontoColeta");
        }
    }
}
