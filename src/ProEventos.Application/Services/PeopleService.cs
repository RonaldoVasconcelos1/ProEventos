using System;
using System.Threading.Tasks;
using ProEventos.Application.Contracts;
using ProEventos.Domain.Entities.Peoples;
using ProEventos.Repository.Contracts;

namespace ProEventos.Application.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IGenericRepository _genericRepo;
        private readonly IPeopleRepository _peopleRepo;

        public PeopleService(IGenericRepository genericRepo, IPeopleRepository peopleRepo)
        {
            _peopleRepo = peopleRepo;
            _genericRepo = genericRepo;
        }
        public async Task<People> Add(People model)
        {
            try
            {
                _genericRepo.Post<People>(model);
                if (await _genericRepo.SaveChangesAsync())
                {
                    return await _peopleRepo.GetPeopleById(model.Id);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<People> Update(People model, Guid id)
        {
            try
            {
                var people = await _peopleRepo.GetPeopleById(id);
                if (people == null) return null;
                _genericRepo.Update(people);
                if (await _genericRepo.SaveChangesAsync())
                {
                    return await _peopleRepo.GetPeopleById(id);
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
                var people = await _peopleRepo.GetPeopleById(id);
                if (people == null) return false;
                _genericRepo.Delete<People>(people);
                return await _genericRepo.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<People[]> GetAllPeoplesAsync()
        {
            try
            {
                var people = await _peopleRepo.GetAllPeoplesAsync();
                if (people == null) return null;
                return people;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<People> GetPeopleById(Guid id)
        {
            try
            {
                var people = await _peopleRepo.GetPeopleById(id);
                if (people == null) return null;
                return people;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}