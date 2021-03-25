using System;
using System.Threading.Tasks;
using ProEventos.Domain.Entities.Events;

namespace ProEventos.Application.Contracts
{
    public interface IEventService
    {
        Task<Event> Add(Event model);
        Task<Event> Update(Event model, Guid id);
        Task<bool> Remove(Guid id);

        Task<Event[]> GetAllEventsAsync(bool includeSpeaker);
        Task<Event[]> GetAllEventThemeAsync(string theme, bool includeSpeaker);
        Task<Event> GetEventById(Guid id, bool includeSpeaker);
    }
}