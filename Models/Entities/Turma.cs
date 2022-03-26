namespace CursoDeIngles.Models.Entities
{
    public class Turma : Base
    {
        public string Nivel { get; set; }
        public DateTime AnoLetivo { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}