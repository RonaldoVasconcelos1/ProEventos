using System.Threading.Tasks;
using ProEventos.Repository.Contracts;
using ProEventos.Repository.Data;

namespace ProEventos.Repository.Repository
{
    public class GenericRepository : IGenereicRepository
    {
        private readonly ProEventosRepository _context;
        public GenericRepository(ProEventosRepository context)
        {
            _context = context;

        }
        public void Post<T>(T entity) where T : class
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

        public void DeleteRange<T>(T entity) where T : class
        {
            _context.RemoveRange(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

    }
}