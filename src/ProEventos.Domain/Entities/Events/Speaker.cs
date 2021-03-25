using System;
using System.Collections.Generic;

namespace ProEventos.Domain.Entities.Events
{
    public class Speaker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MiniCurriculum { get; set; }
        public string ImageURL { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public IEnumerable<EventSpeaker> EventSpeakers { get; set; }
        public IEnumerable<SocialNetWorker> SocialMedia { get; set; }
    }
}