using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FeriadoAnbima.Migrations
{
    public partial class renomeacaoTabelaFeriado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_FERIADO_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "TB_FERIADO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_FERIADO",
                table: "TB_FERIADO");

            migrationBuilder.RenameTable(
                name: "TB_FERIADO",
                newName: "TB_Feriado");

            migrationBuilder.RenameIndex(
                name: "IX_TB_FERIADO_LogDeRaspagemRequisicaoID",
                table: "TB_Feriado",
                newName: "IX_TB_Feriado_LogDeRaspagemRequisicaoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Feriado",
                table: "TB_Feriado",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Feriado_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "TB_Feriado",
                column: "LogDeRaspagemRequisicaoID",
                principalTable: "TB_LogDeRaspagemRequisicao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Feriado_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "TB_Feriado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Feriado",
                table: "TB_Feriado");

            migrationBuilder.RenameTable(
                name: "TB_Feriado",
                newName: "TB_FERIADO");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Feriado_LogDeRaspagemRequisicaoID",
                table: "TB_FERIADO",
                newName: "IX_TB_FERIADO_LogDeRaspagemRequisicaoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_FERIADO",
                table: "TB_FERIADO",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_FERIADO_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "TB_FERIADO",
                column: "LogDeRaspagemRequisicaoID",
                principalTable: "TB_LogDeRaspagemRequisicao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
