using CursoDeIngles.Data.Context;
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

        public List<Aluno> BuscarAlunos()
        {
            //include faz o join entre as tabelas
            return _context.Alunos.Include(x => x.Turmas).ToList();   
        }

        public Aluno BuscarAlunosId(int id)
        {
            return _context.Alunos.Include(x => x.Turmas).Where(x => x.Id == id).FirstOrDefault(); 
        }
    }
}