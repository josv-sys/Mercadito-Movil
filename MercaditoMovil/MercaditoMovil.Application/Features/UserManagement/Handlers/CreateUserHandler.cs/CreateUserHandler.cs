using MercaditoMovil.Mov.Domain.Entities;
// Cambia el namespace a aquel donde realmente está IUserRepository
// using MercaditoMovil.Mov.Domain.Repository; // <-- Corrige "Repositories" por "Repository"

// Usa el namespace correcto donde está IUserRepository
using MercaditoMovil.Mov.Domain.Repositories; // Asegúrate que este namespace contiene IUserRepository

namespace MercaditoMovil.Mov.Application.Features.UserManagement.Handlers
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _repo;

        public CreateUserHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public bool Handle(User nuevo)
        {
            if (_repo.ExistsByEmail(nuevo.Correo))
                return false;

            _repo.Add(nuevo);
            return true;
        }
    }
}
