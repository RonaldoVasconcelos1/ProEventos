using System;
using System.Threading.Tasks;
using ProEventos.Domain.Entities.Events;

namespace ProEventos.Repository.Contracts
{
    public interface ISpeakerRepository
    {
        Task<Speaker[]> GetAllSpeakersAsync(string Speaker, bool includeSpeaker);
        Task<Speaker> GetSpeakersByIdAsync(Guid id, bool includeSpeaker);
        Task<Speaker[]> GetAllSpeakersByThemeAsync(string theme, bool includeSpeaker);
    }
}