using System;
using System.Linq;
using System.Windows.Forms;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Infrastructure.Repositories;
using MercaditoMovil.Application.Services;

namespace MercaditoMovil.Views.WinForms.Controllers
{
    public class FrmCarritoController
    {
        private readonly CarritoService _service;
        private readonly FrmCarrito _form;
        private readonly Usuario _usuarioActual;

        public FrmCarritoController(Usuario usuario, FrmCarrito form)
        {
            _usuarioActual = usuario;
            _form = form;

            // Inyecta el repositorio real dentro del servicio
            var repo = new DataFileRepository();
            _service = new CarritoService(repo);
        }

        // ===============================
        // CARGAR FERIAS
        // ===============================
        public void CargarFerias()
        {
            var ferias = _service.ObtenerFerias();
            if (!ferias.Any())
            {
                MessageBox.Show("No hay ferias registradas.");
                return;
            }

            _form.ComboFerias.Items.Clear();
            foreach (var feria in ferias)
                _form.ComboFerias.Items.Add($"{feria.MarketName} - {feria.Province}");
        }

        // ===============================
        // CARGAR PRODUCTOS
        // ===============================
        public void CargarProductos()
        {
            var productos = _service.ObtenerProductos();
            _form.ListaProductos.Items.Clear();

            foreach (var p in productos)
                _form.ListaProductos.AddItem($"{p.Nombre} ({p.Unidad})");
        }

        // ===============================
        // AGREGAR PRODUCTO AL CARRITO
        // ===============================
        public void AgregarProducto()
        {
            int index = _form.ListaProductos.SelectedIndex;
            if (index < 0) return;

            var productos = _service.ObtenerProductos();
            var productoSeleccionado = productos[index];

            // Obtener precio desde CSV producer_products.csv
            var repo = new DataFileRepository();
            productoSeleccionado.Precio = repo.ObtenerPrecioProducto(productoSeleccionado.ProductCatalogId);

            _service.AgregarAlCarrito(productoSeleccionado);
            _form.ListaCarrito.AddItem($"{productoSeleccionado.Nombre} - ₡{productoSeleccionado.Precio:N2}");
        }

        // ===============================
        // QUITAR PRODUCTO DEL CARRITO
        // ===============================
        public void QuitarProducto()
        {
            int index = _form.ListaCarrito.SelectedIndex;
            if (index < 0) return;

            var carrito = _service.ObtenerCarrito();
            if (index < carrito.Count)
            {
                var producto = carrito[index];
                _service.QuitarDelCarrito(producto.ProductCatalogId);
                _form.ListaCarrito.Items.RemoveAt(index);
            }
        }

        // ===============================
        // FINALIZAR COMPRA
        // ===============================
        public void FinalizarCompra()
        {
            var carrito = _service.ObtenerCarrito();
            if (!carrito.Any())
            {
                MessageBox.Show("El carrito está vacío.");
                return;
            }

            decimal total = _service.CalcularTotal();
            _service.FinalizarCompra(_usuarioActual);

            MessageBox.Show($"Compra realizada por ₡{total:N2}\nGracias, {_usuarioActual.Nombre}!");

            _form.ListaCarrito.Items.Clear();
        }
    }
}
