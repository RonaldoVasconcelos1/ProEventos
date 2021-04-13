using System;
using ProEventos.Domain.Entities.Users;

namespace ProEventos.Domain.Entities.Peoples
{
    public class People
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public User Users { get; set; }

    }
}