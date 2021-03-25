using System;
using ProEventos.Domain.Entities.Users;

namespace src.ProEventos.Domain.Entities.Peoples
{
    public class People
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LasName { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public User Email { get; set; }
        public User Password { get; set; }
    }
}