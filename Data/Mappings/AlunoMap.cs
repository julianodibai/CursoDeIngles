
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

            builder.Property(x => x.Nome)
                    .HasColumnName("nome")
                    .IsRequired();
            builder.Property(x => x.CPF)
                    .HasColumnName("cpf")
                    .IsRequired();
            builder.Property(x => x.Email)
                    .HasColumnName("email");
        }
    }
}