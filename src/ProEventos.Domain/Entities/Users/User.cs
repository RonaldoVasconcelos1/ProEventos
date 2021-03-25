using System;

namespace ProEventos.Domain.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}