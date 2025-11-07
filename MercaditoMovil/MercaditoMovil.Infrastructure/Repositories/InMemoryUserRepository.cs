using System.Collections.Generic;
using System.Linq;
using MercaditoMovil.Mov.Domain.Entities;
using MercaditoMovil.Mov.Domain.Interfaces;

namespace MercaditoMovil.Mov.Infrastructure.Repositories.InMemory
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public bool ExistsByEmail(string correo) => _users.Any(u => u.Correo == correo);
        public void Add(User user) => _users.Add(user);
        public IEnumerable<User> GetAll() => _users;
    }
}
