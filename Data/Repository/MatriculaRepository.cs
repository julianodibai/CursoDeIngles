
using CursoDeIngles.Data.Context;
using CursoDeIngles.Data.Repository.Interfaces;
using CursoDeIngles.Models.DTOs;
using CursoDeIngles.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIngles.Data.Repository
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
        public async Task<Matricula> BuscarMatriculaIdAsync(int alunoId)
        {
            return await _context.Matriculas
                .Where(x => x.AlunoId == alunoId)
                .FirstOrDefaultAsync();
                
        }


        /*   public async Task<Matricula> BuscarMatriculaIdAsync(int id)
           {
               return await _context.Matriculas
                                       .Include(m => m.Aluno)
                                       .ThenInclude(a => a.Turmas)                                             
                                       .Where(t => t.Id == id)
                                       .FirstOrDefaultAsync();    
           }*/

    }
}