using System;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Place { get; set; }
        public DateTime EventDate { get; set; }
        public string Theme { get; set; }
        public int QtyPeople { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string imageURL { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
        public IEnumerable<SocialNetWorker> SocialMedia { get; set; }
        public IEnumerable<EventSpeaker> EventSpeakers { get; set; }
    }
}