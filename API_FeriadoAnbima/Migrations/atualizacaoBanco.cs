using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FeriadoAnbima.Migrations
{
    public partial class atualizacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isSucess",
                table: "TB_LogDeRaspagemRequisicao",
                newName: "IsSucess");

            migrationBuilder.RenameColumn(
                name: "enderecoHttps",
                table: "TB_LogDeRaspagemRequisicao",
                newName: "EnderecoHttps");

            migrationBuilder.RenameColumn(
                name: "data",
                table: "TB_LogDeRaspagemRequisicao",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "anoSolicitado",
                table: "TB_LogDeRaspagemRequisicao",
                newName: "AnoSolicitado");

            migrationBuilder.RenameColumn(
                name: "descrição",
                table: "TB_LogDeRaspagemRequisicao",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "log",
                table: "status",
                newName: "Log");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "status",
                newName: "Descrição");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "feriado",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "diaDaSemana",
                table: "feriado",
                newName: "DiaDaSemana");

            migrationBuilder.RenameColumn(
                name: "data",
                table: "feriado",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "ano",
                table: "feriado",
                newName: "Ano");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoHttps",
                table: "TB_LogDeRaspagemRequisicao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TB_LogDeRaspagemRequisicao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Log",
                table: "status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descrição",
                table: "status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "feriado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaDaSemana",
                table: "feriado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSucess",
                table: "TB_LogDeRaspagemRequisicao",
                newName: "isSucess");

            migrationBuilder.RenameColumn(
                name: "EnderecoHttps",
                table: "TB_LogDeRaspagemRequisicao",
                newName: "enderecoHttps");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "TB_LogDeRaspagemRequisicao",
                newName: "data");

            migrationBuilder.RenameColumn(
                name: "AnoSolicitado",
                table: "TB_LogDeRaspagemRequisicao",
                newName: "anoSolicitado");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "TB_LogDeRaspagemRequisicao",
                newName: "descrição");

            migrationBuilder.RenameColumn(
                name: "Log",
                table: "status",
                newName: "log");

            migrationBuilder.RenameColumn(
                name: "Descrição",
                table: "status",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "feriado",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "DiaDaSemana",
                table: "feriado",
                newName: "diaDaSemana");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "feriado",
                newName: "data");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "feriado",
                newName: "ano");

            migrationBuilder.AlterColumn<string>(
                name: "enderecoHttps",
                table: "TB_LogDeRaspagemRequisicao",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "descrição",
                table: "TB_LogDeRaspagemRequisicao",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "log",
                table: "status",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "status",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "feriado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "diaDaSemana",
                table: "feriado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
