using System.Threading.Tasks;

namespace ProEventos.Repository.Contracts
{
    public interface IGenereicRepository
    {
        void Post<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
    }
}