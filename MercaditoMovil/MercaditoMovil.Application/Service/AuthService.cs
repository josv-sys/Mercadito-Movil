using MercaditoMovil.Application.Features.UserManagement;
using MercaditoMovil.Application.Validators;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Interfaces;

namespace MercaditoMovil.Application.Service
{
    /// <summary>
    /// Basic authentication service backed by repository.
    /// </summary>
    public sealed class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;

        /// <summary>
        /// Builds the service with repository dependency.
        /// </summary>
        public AuthService(IUserRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Validates credentials and compares password.
        /// </summary>
        public bool Login(string username, string password, out string message)
        {
            if (!UserValidator.ValidateLogin(username, password, out message))
                return false;

            var user = _repo.GetByUsername(username);
            if (user is null || user.Password != password)
            {
                message = "Usuario o contraseña incorrectos.";
                return false;
            }

            message = "Inicio de sesión exitoso.";
            return true;
        }

        /// <summary>
        /// Registers user after checks and duplicates by username.
        /// </summary>
        public bool Register(User user, out string message)
        {
            if (!UserValidator.ValidateRegister(user, out message))
                return false;

            var existing = _repo.GetByUsername(user.Username);
            if (existing != null)
            {
                message = "El nombre de usuario ya existe.";
                return false;
            }

            if (!_repo.Add(user, out var repoError))
            {
                message = repoError;
                return false;
            }

            message = user.MarketId == "MKT-000"
                ? "Usuario registrado correctamente. Por ahora no hay una feria cercana a tu ubicación; seguimos trabajando para cubrir todo CR."
                : "Usuario registrado correctamente.";
            return true;
        }
    }
}

