
namespace CursoDeIngles.Models.Entities
{
    public class Matricula : Base
    {
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
    }
}