using System;
using System.Windows.Forms;
using MercaditoMovil.Controllers;
using MercaditoMovil.Mov.Infrastructure.Repositories.InMemory;

namespace MercaditoMovil.Views
{
    public class RegistroView : Form
    {
        private TextBox txtNombre = null!;
        private TextBox txtCorreo = null!;
        private TextBox txtContrasena = null!;
        private Button btnGuardar = null!;
        private readonly UserController _controller;

        public RegistroView()
        {
            Text = "Registro";
            Width = 420; Height = 260;
            StartPosition = FormStartPosition.CenterParent;

            _controller = new UserController(new InMemoryUserRepository());
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Controls.Add(new Label { Text = "Nombre:", Left = 20, Top = 20 });
            txtNombre = new TextBox { Left = 120, Top = 20, Width = 240 };
            Controls.Add(txtNombre);

            Controls.Add(new Label { Text = "Correo:", Left = 20, Top = 60 });
            txtCorreo = new TextBox { Left = 120, Top = 60, Width = 240 };
            Controls.Add(txtCorreo);

            Controls.Add(new Label { Text = "Contraseña:", Left = 20, Top = 100 });
            txtContrasena = new TextBox { Left = 120, Top = 100, Width = 240, UseSystemPasswordChar = true };
            Controls.Add(txtContrasena);

            btnGuardar = new Button { Text = "Guardar", Left = 120, Top = 140, Width = 100 };
            btnGuardar.Click += BtnGuardar_Click;
            Controls.Add(btnGuardar);
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            string resultado = _controller.Registrar(
                txtNombre.Text.Trim(),
                txtCorreo.Text.Trim(),
                txtContrasena.Text.Trim()
            );

            MessageBox.Show(resultado);
            if (resultado.Contains("correctamente"))
                Close();
        }
    }
}
