using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities.Events;
using ProEventos.Repository.Contracts;
using ProEventos.Repository.Data;

namespace ProEventos.Repository.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ProEventosRepository _context;
        private IQueryable<Event> query;
        public EventRepository(ProEventosRepository context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Event[]> GetAllEventsAsync(bool includeSpeaker)
        {
            query = _context.Events.AsNoTracking()
                 .Include(e => e.Lots)
                 .Include(e => e.SocialMedia);
            if (includeSpeaker)
            {
                query = _context.Events
                    .Include(e => e.EventSpeakers)
                    .ThenInclude(e => e.Speaker);
            }
            return await query.ToArrayAsync();
        }
        public async Task<Event> GetAllEventById(Guid id, bool includeSpeaker)
        {
            query = _context.Events.AsNoTracking()
                .Include(e => e.Lots)
                .Include(e => e.SocialMedia);
            if (includeSpeaker)
            {
                query = _context.Events
                    .Include(e => e.EventSpeakers)
                    .ThenInclude(e => e.Speaker);
            }
            query = query.Where(e => e.Id == id);
            return await query.SingleOrDefaultAsync();
        }
        public async Task<Event[]> GetAllEventsByTheme(string theme, bool includeSpeaker)
        {
            query = _context.Events.AsNoTracking()
                .Include(e => e.Lots)
                .Include(e => e.SocialMedia);
            if (includeSpeaker)
            {
                query = _context.Events
                    .Include(e => e.EventSpeakers)
                    .ThenInclude(e => e.Speaker);
            }
            query = query.Where(e => e.Theme.ToLower().Contains(theme.ToLower()));
            return await query.ToArrayAsync();
        }
    }
}