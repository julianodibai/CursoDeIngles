using CursoDeIngles.Services.DTOs;
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Infra.Repository.Interfaces
{
    public interface IMatriculaRepository :  IBaseRepository
    {
        Task<List<MatriculaDTO>> BuscarMatriculasAsync();
        Task<Matricula> BuscarMatriculaIdAsync(int alunoId);
    }
}