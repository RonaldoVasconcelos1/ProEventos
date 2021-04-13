using System;
using System.Threading.Tasks;
using ProEventos.Domain.Entities.Users;
using ProEventos.Repository.Contracts;
using ProEventos.Application.Contracts;

namespace ProEventos.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository _genericRepo;
        private readonly IUserRepository _userRepo;

        public UserService(IGenericRepository genericRepo, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _genericRepo = genericRepo;
        }
        public async Task<User> Add(User model)
        {
            try
            {
                _genericRepo.Post<User>(model);
                if (await _genericRepo.SaveChangesAsync())
                {
                    return await _userRepo.GetUserById(model.Id);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> Update(User model, Guid id)
        {
            try
            {
                var user = await _userRepo.GetUserById(id);
                if (user == null) return null;
                _genericRepo.Update(user);
                if (await _genericRepo.SaveChangesAsync())
                {
                    return await _userRepo.GetUserById(id);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Remove(Guid id)
        {
            try
            {
                var user = await _userRepo.GetUserById(id);
                if (user == null) return false;
                _genericRepo.Delete<User>(user);
                return await _genericRepo.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<User[]> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepo.GetAllUsersAsync();
                if (users == null) return null;
                return users;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<User> GetAllUserEmailAsync(string email)
        {
            try
            {

                var user = await _userRepo.GetAllUsersByEmail(email);
                if (user == null) return null;
                return user;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<User> GetUserById(Guid id)
        {
            try
            {
                var user = await _userRepo.GetUserById(id);
                if (user == null) return null;
                return user;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}