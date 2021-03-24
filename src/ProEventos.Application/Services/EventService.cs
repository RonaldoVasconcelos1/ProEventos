using System;
using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Repository.Contracts;
using ProEventos.Application.Contracts;

namespace ProEventos.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IGenericRepository _genericRepo;
        private readonly IEventRepository _eventRepo;
        public EventService(IGenericRepository genericRepo, IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
            _genericRepo = genericRepo;

        }
        public async Task<Event> Add(Event model)
        {
            try
            {
                _genericRepo.Post<Event>(model);
                if (await _genericRepo.SaveChangesAsync())
                {
                    return await _eventRepo.GetAllEventById(model.Id, false);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> Update(Event model, Guid id)
        {
            try
            {
                var eventUpdated = await _eventRepo.GetAllEventById(id, false);
                if (eventUpdated == null) return null;
                _genericRepo.Update(eventUpdated);
                if (await _genericRepo.SaveChangesAsync())
                {
                    return await _eventRepo.GetAllEventById(id, false);
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
            var eventRemoved = await _eventRepo.GetAllEventById(id, false);
            if (eventRemoved == null) return false;
            _genericRepo.Delete<Event>(eventRemoved);
            return await _genericRepo.SaveChangesAsync();
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeaker)
        {
            var events = await _eventRepo.GetAllEventsAsync(includeSpeaker);
            if (events == null) return null;
            return events;
        }

        public async Task<Event[]> GetAllEventThemeAsync(string theme, bool includeSpeaker)
        {
            var eventsTheme = await _eventRepo.GetAllEventsByTheme(theme, includeSpeaker);
            if (eventsTheme == null) return null;
            return eventsTheme;
        }

        public async Task<Event> GetEventById(Guid id, bool includeSpeaker)
        {
            var eventId = await _eventRepo.GetAllEventById(id, includeSpeaker);
            if (eventId == null) return null;
            return eventId;
        }
    }
}