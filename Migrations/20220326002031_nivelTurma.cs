using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoDeIngles.Migrations
{
    public partial class nivelTurma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nivel",
                table: "tb_turma",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nivel",
                table: "tb_turma");
        }
    }
}
