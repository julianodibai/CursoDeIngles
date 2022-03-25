using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoDeIngles.Migrations
{
    public partial class RecriandoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos");

            migrationBuilder.RenameTable(
                name: "Alunos",
                newName: "tb_aluno");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_aluno",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tb_aluno",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "tb_aluno",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_aluno",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_aluno",
                table: "tb_aluno",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_aluno",
                table: "tb_aluno");

            migrationBuilder.RenameTable(
                name: "tb_aluno",
                newName: "Alunos");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Alunos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Alunos",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Alunos",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Alunos",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos",
                column: "Id");
        }
    }
}
