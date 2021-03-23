using System;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Repository.Contracts
{
    public interface IEventRepository
    {
        Task<Event[]> GetAllEventsAsync(bool includeSpeaker);
        Task<Event[]> GetAllEventById(Guid id, bool includeSpeaker);
        Task<Event[]> GetAllEventsByTheme(string theme, bool includeSpeaker);

    }
}