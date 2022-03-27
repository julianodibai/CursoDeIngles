

using CursoDeIngles.Models.DTOs.Matricula;
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Data.Repository.Interfaces
{
    public interface IMatriculaRepository :  IBaseRepository
    {
        Task<IEnumerable<MatriculaDTO>> BuscarMatriculasAsync();
        Task<Matricula> BuscarMatriculaIdAsync(int id);
    }
}