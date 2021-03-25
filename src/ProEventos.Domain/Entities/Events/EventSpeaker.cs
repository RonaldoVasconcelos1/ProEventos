using System;

namespace ProEventos.Domain.Entities.Events
{
    public class EventSpeaker
    {
        public Guid SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
    }
}