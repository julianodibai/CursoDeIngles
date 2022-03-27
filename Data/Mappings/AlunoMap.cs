
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
                    .UsingEntity<Matricula>();/*
                        m => m.HasOne(a => a.Turma)
                                .WithMany()
                                .HasForeignKey(t => t.TurmaId),
                        m => m.HasOne(t => t.Aluno)
                                .WithMany()
                                .HasForeignKey(a => a.AlunoId),  
                       /* m =>
                        {
                            m.ToTable("tb_matricula");

                            m.HasKey(m => new {m.TurmaId, m.AlunoId});
                            m.Property(m => m.Id)
                                .HasColumnName("id").ValueGeneratedOnAdd();
                            m.Property(m => m.TurmaId)
                                .HasColumnName("id_turma")
                                .IsRequired();
                            m.Property(m => m.AlunoId)
                                .HasColumnName("id_aluno")
                                .IsRequired();          

                        }                
                )*/
        }
    }
}