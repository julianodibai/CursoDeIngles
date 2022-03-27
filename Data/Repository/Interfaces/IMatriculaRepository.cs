using CursoDeIngles.Models.DTOs;
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Data.Repository.Interfaces
{
    public interface IMatriculaRepository :  IBaseRepository
    {
        Task<List<MatriculaDTO>> BuscarMatriculasAsync();
        Task<Matricula> BuscarMatriculaIdAsync(int alunoId);
    }
}