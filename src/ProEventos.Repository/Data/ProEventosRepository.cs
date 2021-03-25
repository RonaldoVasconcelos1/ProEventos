using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities.Events;

namespace ProEventos.Repository.Data
{
    public class ProEventosRepository : DbContext
    {
        public ProEventosRepository(DbContextOptions<ProEventosRepository> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventSpeaker> EventSpeaker { get; set; }
        public DbSet<SocialNetWorker> SocialMedia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventSpeaker>()
                .HasKey(es => new { es.EventId, es.SpeakerId });

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialMedia)
                .WithOne(es => es.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
                .HasMany(es => es.SocialMedia)
                .WithOne(es => es.Speaker)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}