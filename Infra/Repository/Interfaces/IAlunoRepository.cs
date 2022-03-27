
using CursoDeIngles.Services.DTOs;
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Infra.Repository.Interfaces
{
    public interface IAlunoRepository : IBaseRepository
    {
        Task<List<AlunoDTO>> BuscarAlunosAsync();
        Task<Aluno> BuscarAlunosIdAsync(int id);

    }
}