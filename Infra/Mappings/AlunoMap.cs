
using CursoDeIngles.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIngles.Infra.Mappings
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
                    .UsingEntity<Matricula>();

        }
    }
}