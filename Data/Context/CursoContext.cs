using CursoDeIngles.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIngles.Data.Context
{
    public class CursoContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public CursoContext(DbContextOptions<CursoContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}