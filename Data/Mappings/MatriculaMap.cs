
using CursoDeIngles.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIngles.Data.Mappings
{
    public class MatriculaMap : BaseMap<Matricula>
    {
        public MatriculaMap() : base("tb_matricula")
        { }

        
        public override void Configure(EntityTypeBuilder<Matricula> builder)
        {
            base.Configure(builder);

            builder.HasKey(m => new {m.TurmaId, m.AlunoId});
            builder.Property(m => m.TurmaId)
                        .HasColumnName("id_turma")
                        .IsRequired();
            builder.Property(m => m.AlunoId)
                        .HasColumnName("id_aluno")
                        .IsRequired();  
            builder.HasOne(a => a.Turma)
                        .WithMany()
                        .HasForeignKey(t => t.TurmaId);
            builder.HasOne(t => t.Aluno)
                        .WithMany()
                        .HasForeignKey(a => a.AlunoId);
               
        }
    }
}