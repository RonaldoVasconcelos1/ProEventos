using System;
using System.Threading.Tasks;
using ProEventos.Domain.Entities.Users;

namespace ProEventos.Application.Contracts
{
    public interface IUserService
    {
        Task<User> Add(User model);
        Task<User> Update(User model, Guid id);
        Task<bool> Remove(Guid Id);

        Task<User[]> GetAllUsersAsync();
        Task<User> GetAllUserEmailAsync(string email);
        Task<User> GetUserById(Guid id);
    }
}