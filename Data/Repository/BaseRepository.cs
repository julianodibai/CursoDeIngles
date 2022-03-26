using CursoDeIngles.Data.Context;
using CursoDeIngles.Data.Repository.Interfaces;

namespace CursoDeIngles.Data.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly CursoContext _context;

        public BaseRepository(CursoContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}