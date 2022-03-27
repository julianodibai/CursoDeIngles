

namespace CursoDeIngles.Services.DTOs
{
    public class MatriculaDetalhesDTO
    {
        public int Id { get; set; }
        public AlunoDTO Aluno { get; set; }
        public int AlunoId { get; set; }
        public TurmaDTO Turma { get; set; }
        public int TurmaId { get; set; }
    }
}