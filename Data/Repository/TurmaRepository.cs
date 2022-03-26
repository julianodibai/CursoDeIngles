
using CursoDeIngles.Data.Context;
using CursoDeIngles.Data.Repository.Interfaces;

namespace CursoDeIngles.Data.Repository
{
    public class TurmaRepository : BaseRepository, ITurmaRepository
    {
        public TurmaRepository(CursoContext context) : base(context)
        {
        }
    }
}