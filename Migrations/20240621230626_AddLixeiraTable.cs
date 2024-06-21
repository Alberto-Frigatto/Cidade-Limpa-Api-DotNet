using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeLimpa.Migrations
{
    /// <inheritdoc />
    public partial class AddLixeiraTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lixeira",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Capacidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Ocupacao = table.Column<decimal>(type: "DECIMAL(3,2)", precision: 3, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lixeira", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lixeira");
        }
    }
}
