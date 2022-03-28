using CursoDeIngles.Infra.Context;
using CursoDeIngles.Services.DTOs;
using CursoDeIngles.Infra.Repository.Interfaces;
using CursoDeIngles.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIngles.Infra.Repository
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

        public async Task<Aluno> VerificarCpfAsync(Aluno aluno)
        {
           return await _context.Alunos
                                .Where(a => a.CPF == aluno.CPF)
                                .FirstOrDefaultAsync();         
        }
    }
}