
using CursoDeIngles.Infra.Context;
using CursoDeIngles.Infra.Repository.Interfaces;
using CursoDeIngles.Services.DTOs;
using CursoDeIngles.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIngles.Infra.Repository
{
    public class MatriculaRepository : BaseRepository, IMatriculaRepository
    {
        private readonly CursoContext _context;
        public MatriculaRepository(CursoContext context) : base(context)
        {
             _context = context;
        }

        public async Task<List<MatriculaDTO>> BuscarMatriculasAsync()
        {
            return await _context.Matriculas
                             .Select(
                                 m => new MatriculaDTO{
                                        Id = m.Id,
                                        AlunoId = m.AlunoId,
                                        TurmaId = m.TurmaId

                             })
                             .ToListAsync();   
        }
        public async Task<Matricula> BuscarMatriculaIdAsync(int matriculaId)
        {
            return await _context.Matriculas
                .Where(x => x.Id == matriculaId)
                .FirstOrDefaultAsync();
                
        }

    }
}