using System;

namespace ProEventos.Domain
{
    public class Lot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Quantity { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
    }
}