using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FeriadoAnbima.Migrations
{
    public partial class criacaoTabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feriado_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "feriado");

            migrationBuilder.DropForeignKey(
                name: "FK_status_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_status",
                table: "status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_feriado",
                table: "feriado");

            migrationBuilder.RenameTable(
                name: "status",
                newName: "TB_Status");

            migrationBuilder.RenameTable(
                name: "feriado",
                newName: "TB_FERIADO");

            migrationBuilder.RenameIndex(
                name: "IX_status_LogDeRaspagemRequisicaoID",
                table: "TB_Status",
                newName: "IX_TB_Status_LogDeRaspagemRequisicaoID");

            migrationBuilder.RenameIndex(
                name: "IX_feriado_LogDeRaspagemRequisicaoID",
                table: "TB_FERIADO",
                newName: "IX_TB_FERIADO_LogDeRaspagemRequisicaoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Status",
                table: "TB_Status",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_FERIADO",
                table: "TB_FERIADO",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_FERIADO_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "TB_FERIADO",
                column: "LogDeRaspagemRequisicaoID",
                principalTable: "TB_LogDeRaspagemRequisicao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Status_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "TB_Status",
                column: "LogDeRaspagemRequisicaoID",
                principalTable: "TB_LogDeRaspagemRequisicao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_FERIADO_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "TB_FERIADO");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Status_TB_LogDeRaspagemRequisicao_LogDeRaspagemRequisicaoID",
                table: "TB_Status");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Status",
                table: "TB_Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_FERIADO",
                table: "TB_FERIADO");

            migrationBuilder.RenameTable(
                name: "TB_Status",
                newName: "status");

            migrationBuilder.RenameTable(
                name: "TB_FERIADO",
                newName: "feriado");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Status_LogDeRaspagemRequisicaoID",
                table: "status",
                newName: "IX_status_LogDeRaspagemRequisicaoID");

            migrationBuilder.RenameIndex(
                name: "IX_TB_FERIADO_LogDeRaspagemRequisicaoID",
                table: "feriado",
                newName: "IX_feriado_LogDeRaspagemRequisicaoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_status",
                table: "status",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feriado",
                table: "feriado",
                column: "ID");

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
    }
}
