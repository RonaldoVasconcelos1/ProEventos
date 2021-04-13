using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Repository.Data;
using ProEventos.Repository.Contracts;
using ProEventos.Domain.Entities.Peoples;
using System.Linq;

namespace ProEventos.Repository.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly ProEventosRepository _context;
        private IQueryable<People> query;
        public PeopleRepository(ProEventosRepository context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        public async Task<People[]> GetAllPeoplesAsync()
        {
            query = _context.Peoples.AsNoTracking().Include(p => p.Users);
            return await query.ToArrayAsync();

        }
        public async Task<People> GetPeopleById(Guid id)
        {
            query = _context.Peoples.AsNoTracking().Include(p => p.Users);
            query = query.Where(p => p.Id == id);
            return await query.SingleOrDefaultAsync();

        }
    }
}