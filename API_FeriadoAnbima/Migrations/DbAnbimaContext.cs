using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FeriadoAnbima.Migrations
{
    public partial class DbAnbimaContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_LogDeRaspagemRequisicao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isSucess = table.Column<bool>(type: "bit", nullable: false),
                    anoSolicitado = table.Column<int>(type: "int", nullable: false),
                    enderecoHttps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descrição = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LogDeRaspagemRequisicao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "feriado",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diaDaSemana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    logDeRaspagemRequisicaoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feriado", x => x.ID);
                    table.ForeignKey(
                        name: "FK_feriado_TB_LogDeRaspagemRequisicao_logDeRaspagemRequisicaoid",
                        column: x => x.logDeRaspagemRequisicaoid,
                        principalTable: "TB_LogDeRaspagemRequisicao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    log = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logDeRaspagemRequisicaoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.ID);
                    table.ForeignKey(
                        name: "FK_status_TB_LogDeRaspagemRequisicao_logDeRaspagemRequisicaoid",
                        column: x => x.logDeRaspagemRequisicaoid,
                        principalTable: "TB_LogDeRaspagemRequisicao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_feriado_logDeRaspagemRequisicaoid",
                table: "feriado",
                column: "logDeRaspagemRequisicaoid");

            migrationBuilder.CreateIndex(
                name: "IX_status_logDeRaspagemRequisicaoid",
                table: "status",
                column: "logDeRaspagemRequisicaoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feriado");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "TB_LogDeRaspagemRequisicao");
        }
    }
}
