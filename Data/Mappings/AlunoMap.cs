
using CursoDeIngles.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIngles.Data.Mappings
{
    public class AlunoMap : BaseMap<Aluno>
    {

        public AlunoMap() : base("tb_aluno")
        {
            
        }
        public override void Configure(EntityTypeBuilder<Aluno> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.Nome)
                    .HasColumnName("nome")
                    .IsRequired();
            builder.Property(a => a.CPF)
                    .HasColumnName("cpf")
                    .IsRequired();
            builder.Property(a => a.Email)
                    .HasColumnName("email");
                    
            builder.HasMany(a => a.Turmas)
                    .WithMany(t => t.Alunos)
                    .UsingEntity<AlunoTurma>(
                        x => x.HasOne(a => a.Turma)
                                .WithMany()
                                .HasForeignKey(t => t.TurmaId),
                        x => x.HasOne(t => t.Aluno)
                                .WithMany()
                                .HasForeignKey(a => a.AlunoId),  
                        x =>
                        {
                            x.ToTable("tb_aluno_turma");

                            x.HasKey(x => new {x.TurmaId, x.AlunoId});
                            x.Property(x => x.TurmaId)
                                .HasColumnName("id_turma")
                                .IsRequired();
                            x.Property(x => x.AlunoId)
                                .HasColumnName("id_aluno")
                                .IsRequired();
                        }                 
                    );
        }
    }
}