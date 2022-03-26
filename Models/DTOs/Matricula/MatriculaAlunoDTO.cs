
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Models.DTOs
{
    public class MatriculaAlunoDTO
    {
        public int Id { get; set; }
        public TurmaDTO Turma { get; set; }
    }
}