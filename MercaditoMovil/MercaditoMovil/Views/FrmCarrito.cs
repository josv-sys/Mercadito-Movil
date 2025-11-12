using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Infrastructure.Repositories;
using MercaditoMovil.Views.WinForms.Controllers;
using ReaLTaiizor.Child.Material;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MercaditoMovil.Views.WinForms
{
    public partial class FrmCarrito : Form
    {
        private readonly FrmCarritoController _controller;

        public FrmCarrito(Usuario usuario)
        {
            InitializeComponent();
            _controller = new FrmCarritoController(usuario, this);
        }

        private void FrmCarrito_Load(object sender, EventArgs e)
        {
            _controller.CargarFerias();
            _controller.CargarProductos();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            _controller.AgregarProducto();
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            _controller.QuitarProducto();
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            _controller.FinalizarCompra();
        }

        // === ACCESORES PARA EL CONTROLADOR ===
        public MaterialComboBox ComboFerias => comboFerias;
        public MaterialListBox ListaProductos => listaProductos;
        public MaterialListBox ListaCarrito => listaCarrito;
    }
}

