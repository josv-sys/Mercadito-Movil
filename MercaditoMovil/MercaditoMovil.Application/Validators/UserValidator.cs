using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Application.Validators
{
    /// <summary>
    /// Centralized validation for login and register.
    /// </summary>
    public static partial class UserValidator
    {
        /// <summary>
        /// Validates login inputs.
        /// </summary>
        public static bool ValidateLogin(string username, string password, out string message)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                message = "Por favor ingresa usuario y contraseña.";
                return false;
            }

            message = string.Empty;
            return true;
        }

        /// <summary>
        /// Validates required fields for registration.
        /// </summary>
        public static bool ValidateRegister(User user, out string message)
        {
            if (user is null)
            {
                message = "Datos de usuario inválidos.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.Username) ||
                string.IsNullOrWhiteSpace(user.Password) ||
                string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.NationalId) ||
                string.IsNullOrWhiteSpace(user.Email))
            {
                message = "Campos obligatorios vacíos: usuario, contraseña, nombre, cédula y correo.";
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}
