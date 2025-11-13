using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Views.WinForms.Controllers;
using ReaLTaiizor.Child.Material;
using ReaLTaiizor.Controls;
using System;
using System.Windows.Forms;

namespace MercaditoMovil.Views.WinForms
{
    public partial class FrmCarrito : ReaLTaiizor.Forms.MaterialForm
    {
        private readonly FrmCarritoController _controller;

        public FrmCarrito(Usuario usuario)
        {
            InitializeComponent();
            _controller = new FrmCarritoController(usuario);
        }

        private void FrmCarrito_Load(object sender, EventArgs e)
        {
            CargarFeria();
            CargarProductos();
        }

        private void CargarFeria()
        {
            var feria = _controller.ObtenerFeria();
            ComboFerias.Items.Clear();

            if (feria != null)
            {
                ComboFerias.Items.Add($"{feria.MarketId} - {feria.MarketName}");
                ComboFerias.SelectedIndex = 0;
            }
            else
            {
                ComboFerias.Items.Add("No asignada");
                ComboFerias.SelectedIndex = 0;
            }
        }

        private void CargarProductos()
        {
            ListaProductos.Items.Clear();

            var productos = _controller.ObtenerProductos();

            foreach (var p in productos)
            {
                ListaProductos.Items.Add(new MaterialListBoxItem
                {
                    Text = $"{p.Nombre} - ₡{p.Precio:N0} - Stock:{p.Stock}",
                    Tag = p
                });
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ListaProductos.SelectedItem is MaterialListBoxItem item &&
                item.Tag is Producto prod)
            {
                if (prod.Stock <= 0)
                {
                    MessageBox.Show("Producto sin stock", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _controller.Agregar(prod);

                ListaCarrito.Items.Add(new MaterialListBoxItem
                {
                    Text = $"{prod.Nombre} - ₡{prod.Precio:N0}",
                    Tag = prod
                });
            }
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (ListaCarrito.SelectedItem is MaterialListBoxItem item &&
                item.Tag is Producto prod)
            {
                _controller.Quitar(prod);
                ListaCarrito.Items.Remove(item);
            }
        }

        // ---------------------------------------------------------
        //  ✔ FINALIZAR COMPRA (ya arreglado)
        // ---------------------------------------------------------
        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (_controller.FinalizarCompra())
            {
                MessageBox.Show("Compra registrada con éxito.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListaCarrito.Items.Clear();
            }
            else
            {
                MessageBox.Show("No hay productos en el carrito.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
