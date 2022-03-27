using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Data.Repository.Interfaces
{
    public interface IMatriculaRepository :  IBaseRepository
    {
        Task<Matricula> BuscarMatriculaIdAsync(int alunoId);
    }
}