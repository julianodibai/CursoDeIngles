
namespace CursoDeIngles.Models.Entities
{
    public class Aluno : Base
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public List<Turma> Turmas { get; set; }
    }
}