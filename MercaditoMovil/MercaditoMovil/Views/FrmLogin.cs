using System;
using System.Windows.Forms;
using ReaLTaiizor.Forms;
using MercaditoMovil.Application.Services;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Views.WinForms
{
    public partial class FrmLogin : MaterialForm
    {
        private readonly AuthService _authService;

        public FrmLogin()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string correo = TxtCorreo.Text.Trim();
            string contrasena = TxtContrasena.Text.Trim();

            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario? usuario = _authService.IniciarSesion(correo, contrasena);

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido {usuario.Nombre}!", "Acceso concedido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abre el formulario de carrito
                FrmCarrito frm = new FrmCarrito(usuario);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
