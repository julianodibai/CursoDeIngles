using CursoDeIngles.Data.Context;
using CursoDeIngles.Models.DTOs;
using CursoDeIngles.Data.Repository.Interfaces;
using CursoDeIngles.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIngles.Data.Repository
{
    public class AlunoRepository : BaseRepository, IAlunoRepository
    {
        private readonly CursoContext _context;
        public AlunoRepository(CursoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AlunoDTO>> BuscarAlunosAsync()
        {
            //Include(x => x.Turmas)faz o join entre as tabelas
            return await _context.Alunos
                             .Select(x => new AlunoDTO{
                                        Id = x.Id,
                                        Nome = x.Nome 
                             })
                             .ToListAsync();   
        }

        public async Task<Aluno> BuscarAlunosIdAsync(int id)
        {
            return await _context.Alunos
                                    .Include(a => a.Turmas)
                                    .ThenInclude(t => t.Alunos)
                                    .Where(a => a.Id == id)
                                    .FirstOrDefaultAsync();                     
        }
    }
}