using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Dados.Migracoes
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcaProduto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProdutos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 180, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrlFoto = table.Column<string>(nullable: false),
                    IdTipoDeProduto = table.Column<int>(nullable: false),
                    IdMarcaProduto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_MarcaProduto_IdMarcaProduto",
                        column: x => x.IdMarcaProduto,
                        principalTable: "MarcaProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_TipoProdutos_IdTipoDeProduto",
                        column: x => x.IdTipoDeProduto,
                        principalTable: "TipoProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdMarcaProduto",
                table: "Produtos",
                column: "IdMarcaProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdTipoDeProduto",
                table: "Produtos",
                column: "IdTipoDeProduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "MarcaProduto");

            migrationBuilder.DropTable(
                name: "TipoProdutos");
        }
    }
}
