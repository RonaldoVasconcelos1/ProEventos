using System.Linq;
using System;
using System.Threading.Tasks;
using ProEventos.Domain.Entities.Events;
using ProEventos.Repository.Contracts;
using ProEventos.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace src.ProEventos.Repository.Repository
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly ProEventosRepository _context;
        private IQueryable<Speaker> query;
        public SpeakerRepository(ProEventosRepository context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;


        }
        public async Task<Speaker[]> GetAllSpeakersAsync(string Speaker, bool includeSpeaker)
        {
            query = _context.Speakers.AsNoTracking()
                .Include(s => s.SocialMedia);
            if (includeSpeaker)
            {
                query = query
                    .Include(s => s.EventSpeakers)
                    .ThenInclude(s => s.Event);
            }
            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByThemeAsync(string theme, bool includeSpeaker)
        {
            query = _context.Speakers.AsNoTracking()
               .Include(s => s.SocialMedia);
            if (includeSpeaker)
            {
                query = query
                    .Include(s => s.EventSpeakers)
                    .ThenInclude(s => s.Event);
            }
            query = query.OrderBy(s => s.Id)
                 .Where(s => s.Name.ToLower().Contains(theme));
            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakersByIdAsync(Guid id, bool includeSpeaker)
        {
            query = _context.Speakers.AsNoTracking()
                 .Include(s => s.SocialMedia);
            if (includeSpeaker)
            {
                query = query
                    .Include(s => s.EventSpeakers)
                    .ThenInclude(s => s.Speaker);
            }
            query = query.Where(s => s.Id == id);
            return await query.SingleOrDefaultAsync();
        }
    }
}