using System;
using System.Threading.Tasks;
using ProEventos.Domain.Entities.Peoples;

namespace ProEventos.Repository.Contracts
{
    public interface IPeopleRepository
    {
        Task<People[]> GetAllPeoplesAsync();
        Task<People> GetPeopleById(Guid id);
    }
}