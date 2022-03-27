
namespace CursoDeIngles.Services.DTOs
{
    public class TurmaDetalhesDTO
    {
        public int Id { get; set; }
        public string Nivel { get; set; }
        public DateTime AnoLetivo { get; set; }
        public List<AlunoDTO> Alunos { get; set; }
    }
}