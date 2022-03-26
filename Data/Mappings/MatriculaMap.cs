using CursoDeIngles.Models.Entities;
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

        }
    }
}