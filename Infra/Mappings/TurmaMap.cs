using CursoDeIngles.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIngles.Infra.Mappings
{
    public class TurmaMap : BaseMap<Turma>
    {

        public TurmaMap() : base("tb_turma")
        { }
        public override void Configure(EntityTypeBuilder<Turma> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.AnoLetivo)
                    .HasColumnName("anoLetivo");
            builder.Property(x => x.Nivel)
                    .HasColumnName("nivel");
        }
                    
    }
}