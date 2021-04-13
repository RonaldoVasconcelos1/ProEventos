using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities.Users;
using ProEventos.Repository.Data;
using ProEventos.Repository.Contracts;

namespace ProEventos.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ProEventosRepository _context;
        public UserRepository(ProEventosRepository context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        public async Task<User[]> GetAllUsersAsync()
        {
            var users = await _context.Users.AsNoTracking().ToArrayAsync();
            return users;

        }
        public async Task<User> GetAllUsersByEmail(string email)
        {
            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync();
            return user;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync();
            return user;
        }
    }
}