
using CursoDeIngles.Services.DTOs;
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Infra.Repository.Interfaces
{
    public interface ITurmaRepository : IBaseRepository
    {
        Task<IEnumerable<TurmaDTO>> BuscarTurmasAsync();
        Task<Turma> BuscarTurmaIdAsync(int id);
    }
}