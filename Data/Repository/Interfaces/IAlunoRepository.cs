
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Data.Repository.Interfaces
{
    public interface IAlunoRepository : IBaseRepository
    {
        List<Aluno> BuscarAlunos();
        Aluno BuscarAlunosId(int id);

    }
}