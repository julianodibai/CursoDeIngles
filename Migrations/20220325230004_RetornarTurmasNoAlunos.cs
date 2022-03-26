﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoDeIngles.Migrations
{
    public partial class RetornarTurmasNoAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_aluno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_turma",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anoLetivo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_turma", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_aluno_turma",
                columns: table => new
                {
                    id_aluno = table.Column<int>(type: "int", nullable: false),
                    id_turma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_aluno_turma", x => new { x.id_turma, x.id_aluno });
                    table.ForeignKey(
                        name: "FK_tb_aluno_turma_tb_aluno_id_aluno",
                        column: x => x.id_aluno,
                        principalTable: "tb_aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_aluno_turma_tb_turma_id_turma",
                        column: x => x.id_turma,
                        principalTable: "tb_turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_aluno_turma_id_aluno",
                table: "tb_aluno_turma",
                column: "id_aluno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_aluno_turma");

            migrationBuilder.DropTable(
                name: "tb_aluno");

            migrationBuilder.DropTable(
                name: "tb_turma");
        }
    }
}
