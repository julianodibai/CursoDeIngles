
using CursoDeIngles.Models.DTOs;
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Data.Repository.Interfaces
{
    public interface ITurmaRepository : IBaseRepository
    {
        Task<IEnumerable<TurmaDTO>> BuscarTurmasAsync();
        Task<Turma> BuscarTurmaIdAsync(int id);
    }
}