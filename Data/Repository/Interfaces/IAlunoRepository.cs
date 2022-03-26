
using CursoDeIngles.Models.DTOs;
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Data.Repository.Interfaces
{
    public interface IAlunoRepository : IBaseRepository
    {
        Task<List<AlunoDTO>> BuscarAlunosAsync();
        Task<Aluno> BuscarAlunosIdAsync(int id);

    }
}