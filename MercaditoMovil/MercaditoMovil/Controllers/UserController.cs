using MercaditoMovil.Mov.Application.Features.UserManagement.Handlers;
using MercaditoMovil.Mov.Application.Validators;
using MercaditoMovil.Mov.Domain.Entities;
using MercaditoMovil.Mov.Domain.Interfaces;

namespace MercaditoMovil.Controllers
{
    public class UserController
    {
        private readonly IUserRepository _repo;
        private readonly CreateUserHandler _createUser;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
            _createUser = new CreateUserHandler(repo);
        }

        public string Registrar(string nombre, string correo, string contrasena)
        {
            if (!UserValidator.EsCorreoValido(correo))
                return "Correo inválido";

            var nuevo = new User { Nombre = nombre, Correo = correo, Contrasena = contrasena };

            return _createUser.Handle(nuevo)
                ? "Usuario registrado correctamente."
                : "Ya existe un usuario con ese correo.";
        }
    }
}
