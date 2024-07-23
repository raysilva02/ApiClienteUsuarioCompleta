using ApiClienteUsuarioCompleta.Data;
using ApiClienteUsuarioCompleta.Repository.Interface;

namespace ApiClienteUsuarioCompleta.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ApiDbContext _context;

        public BaseRepository(ApiDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
