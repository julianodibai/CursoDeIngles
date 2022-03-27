
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Models.DTOs
{
    public class AlunoDetalhesDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public List<TurmaDTO> Turmas { get; set; } 
    }
}