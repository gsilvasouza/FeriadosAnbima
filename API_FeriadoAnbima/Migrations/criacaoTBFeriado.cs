using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FeriadoAnbima.Migrations
{
    public partial class criacaoTBFeriado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feriado_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoid",
                table: "feriado");

            migrationBuilder.DropForeignKey(
                name: "FK_status_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoid",
                table: "status");

            migrationBuilder.RenameColumn(
                name: "LogDeRaspagemRequisicaoid",
                table: "status",
                newName: "LogDeRaspagemRequisicaoID");

            migrationBuilder.RenameIndex(
                name: "IX_status_LogDeRaspagemRequisicaoid",
                table: "status",
                newName: "IX_status_LogDeRaspagemRequisicaoID");

            migrationBuilder.RenameColumn(
                name: "LogDeRaspagemRequisicaoid",
                table: "feriado",
                newName: "LogDeRaspagemRequisicaoID");

            migrationBuilder.RenameIndex(
                name: "IX_feriado_LogDeRaspagemRequisicaoid",
                table: "feriado",
                newName: "IX_feriado_LogDeRaspagemRequisicaoID");

            migrationBuilder.AddForeignKey(
                name: "FK_feriado_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "feriado",
                column: "LogDeRaspagemRequisicaoID",
                principalTable: "TB_LogDeRaspagemRequisicao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_status_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "status",
                column: "LogDeRaspagemRequisicaoID",
                principalTable: "TB_LogDeRaspagemRequisicao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feriado_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "feriado");

            migrationBuilder.DropForeignKey(
                name: "FK_status_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "status");

            migrationBuilder.RenameColumn(
                name: "LogDeRaspagemRequisicaoID",
                table: "status",
                newName: "LogDeRaspagemRequisicaoid");

            migrationBuilder.RenameIndex(
                name: "IX_status_LogDeRaspagemRequisicaoID",
                table: "status",
                newName: "IX_status_LogDeRaspagemRequisicaoid");

            migrationBuilder.RenameColumn(
                name: "LogDeRaspagemRequisicaoID",
                table: "feriado",
                newName: "LogDeRaspagemRequisicaoid");

            migrationBuilder.RenameIndex(
                name: "IX_feriado_LogDeRaspagemRequisicaoID",
                table: "feriado",
                newName: "IX_feriado_LogDeRaspagemRequisicaoid");

            migrationBuilder.AddForeignKey(
                name: "FK_feriado_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoid",
                table: "feriado",
                column: "LogDeRaspagemRequisicaoid",
                principalTable: "TB_LogDeRaspagemRequisicao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_status_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoid",
                table: "status",
                column: "LogDeRaspagemRequisicaoid",
                principalTable: "TB_LogDeRaspagemRequisicao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
