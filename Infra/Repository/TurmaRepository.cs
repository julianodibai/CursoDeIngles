
using CursoDeIngles.Infra.Context;
using CursoDeIngles.Infra.Repository.Interfaces;
using CursoDeIngles.Services.DTOs;
using CursoDeIngles.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIngles.Infra.Repository
{
    public class TurmaRepository : BaseRepository, ITurmaRepository
    {
        private readonly CursoContext _context;
        public TurmaRepository(CursoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TurmaDTO>> BuscarTurmasAsync()
        {
            return await _context.Turmas
                             .Select(
                                 x => new TurmaDTO{
                                        Id = x.Id,
                                        Nivel = x.Nivel,
                                        AnoLetivo = x.AnoLetivo 
                             })
                             .ToListAsync();   
        }

        public async Task<Turma> BuscarTurmaIdAsync(int id)
        {
            return await _context.Turmas
                                    .Include(t => t.Alunos)
                                    .ThenInclude(a => a.Turmas)                                             
                                    .Where(t => t.Id == id)
                                    .FirstOrDefaultAsync();                     
        }

    }
}