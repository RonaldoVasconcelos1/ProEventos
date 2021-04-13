using System;
using System.Threading.Tasks;
using ProEventos.Domain.Entities.Users;

namespace ProEventos.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User[]> GetAllUsersAsync();
        Task<User> GetUserById(Guid id);
        Task<User> GetAllUsersByEmail(string email);
    }
}