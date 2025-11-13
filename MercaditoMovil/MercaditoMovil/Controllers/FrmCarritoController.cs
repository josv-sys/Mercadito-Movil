using System.Collections.Generic;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Application.Services;

namespace MercaditoMovil.Views.WinForms.Controllers
{
    public class FrmCarritoController
    {
        private readonly CarritoService _service;

        public FrmCarritoController(Usuario usuario)
        {
            _service = new CarritoService(usuario);
        }

        // ======================================================
        //    OBTENER FERIA DEL USUARIO
        // ======================================================
        public Feria? ObtenerFeria()
        {
            return _service.ObtenerFeria();
        }

        // ======================================================
        //    OBTENER PRODUCTOS DISPONIBLES PARA LA FERIA
        // ======================================================
        public List<Producto> ObtenerProductos()
        {
            return _service.ObtenerProductos();
        }

        // ======================================================
        //    AGREGAR PRODUCTO AL CARRITO
        // ======================================================
        public void Agregar(Producto producto)
        {
            _service.Agregar(producto);
        }

        // ======================================================
        //    QUITAR PRODUCTO DEL CARRITO
        // ======================================================
        public void Quitar(Producto producto)
        {
            _service.Quitar(producto);
        }

        // ======================================================
        //    FINALIZAR COMPRA
        // ======================================================
        public bool FinalizarCompra()
        {
            return _service.FinalizarCompra();
        }
    }
}
