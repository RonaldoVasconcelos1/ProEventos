using System;

namespace ProEventos.Domain
{
    public class SocialNetWorker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public Guid? EventId { get; set; }
        public Event Event { get; set; }
        public Guid SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
    }
}