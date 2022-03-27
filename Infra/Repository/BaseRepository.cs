using CursoDeIngles.Infra.Context;
using CursoDeIngles.Infra.Repository.Interfaces;

namespace CursoDeIngles.Infra.Repository
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
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}