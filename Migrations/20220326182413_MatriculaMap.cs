using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoDeIngles.Migrations
{
    public partial class MatriculaMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_tb_aluno_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_tb_turma_TurmaId",
                table: "Matriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas");

            migrationBuilder.RenameTable(
                name: "Matriculas",
                newName: "tb_matricula");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_matricula",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_TurmaId",
                table: "tb_matricula",
                newName: "IX_tb_matricula_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_AlunoId",
                table: "tb_matricula",
                newName: "IX_tb_matricula_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_matricula",
                table: "tb_matricula",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_matricula_tb_aluno_AlunoId",
                table: "tb_matricula",
                column: "AlunoId",
                principalTable: "tb_aluno",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_matricula_tb_turma_TurmaId",
                table: "tb_matricula",
                column: "TurmaId",
                principalTable: "tb_turma",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_matricula_tb_aluno_AlunoId",
                table: "tb_matricula");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_matricula_tb_turma_TurmaId",
                table: "tb_matricula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_matricula",
                table: "tb_matricula");

            migrationBuilder.RenameTable(
                name: "tb_matricula",
                newName: "Matriculas");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Matriculas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_matricula_TurmaId",
                table: "Matriculas",
                newName: "IX_Matriculas_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_matricula_AlunoId",
                table: "Matriculas",
                newName: "IX_Matriculas_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_tb_aluno_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                principalTable: "tb_aluno",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_tb_turma_TurmaId",
                table: "Matriculas",
                column: "TurmaId",
                principalTable: "tb_turma",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
