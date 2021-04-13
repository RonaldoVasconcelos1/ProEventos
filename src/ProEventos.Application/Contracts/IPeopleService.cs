using System;
using System.Threading.Tasks;
using ProEventos.Domain.Entities.Peoples;

namespace ProEventos.Application.Contracts
{
    public interface IPeopleService
    {
        Task<People> Add(People model);
        Task<People> Update(People model, Guid id);
        Task<bool> Remove(Guid Id);

        Task<People[]> GetAllPeoplesAsync();
        Task<People> GetPeopleById(Guid id);
    }
}