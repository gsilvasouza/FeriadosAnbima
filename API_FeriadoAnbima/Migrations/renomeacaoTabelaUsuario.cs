using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FeriadoAnbima.Migrations
{
    public partial class renomeacaoTabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "TB_Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Usuario",
                table: "TB_Usuario",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Usuario",
                table: "TB_Usuario");

            migrationBuilder.RenameTable(
                name: "TB_Usuario",
                newName: "usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "ID");
        }
    }
}
