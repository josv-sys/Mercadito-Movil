using System.Text.RegularExpressions;

namespace MercaditoMovil.Mov.Application.Validators
{
    public static class UserValidator
    {
        public static bool EsCorreoValido(string correo)
        {
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
