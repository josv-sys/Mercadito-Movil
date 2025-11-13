using System;
using System.Windows.Forms;
using MercaditoMovil.Application.Services;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Views.WinForms.Controllers
{
    public class LoginController
    {
        private readonly AuthService _authService;

        public LoginController()
        {
            _authService = new AuthService();
        }

        /// <summary>
        /// Valida las credenciales del usuario contra users.csv
        /// </summary>
        public Usuario? IniciarSesion(string correo, string contrasena)
        {
            try
            {
                var usuario = _authService.IniciarSesion(correo, contrasena);

                if (usuario == null)
                {
                    MessageBox.Show("Correo o contraseña incorrectos.",
                        "Error de autenticación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }

                return usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}",
                    "Error interno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
