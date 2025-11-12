using System.Collections.Generic;
using System.Linq;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Infrastructure.Repositories;

namespace MercaditoMovil.Application.Services
{
    public class CarritoService
    {
        private readonly DataFileRepository _repo;
        private readonly List<Producto> _catalogo;
        private readonly List<Feria> _ferias;
        private readonly List<Producto> _carrito;

        public CarritoService(DataFileRepository repo)
        {
            _repo = repo;
            _catalogo = _repo.ObtenerProductosCatalogo();
            _ferias = _repo.ObtenerFerias();
            _carrito = new List<Producto>();
        }

        // === Obtener catálogos y ferias ===
        public List<Feria> ObtenerFerias() => _ferias;
        public List<Producto> ObtenerProductos() => _catalogo;
        public List<Producto> ObtenerCarrito() => _carrito;

        // === Agregar producto ===
        public void AgregarAlCarrito(Producto p)
        {
            var item = _carrito.FirstOrDefault(x => x.ProductCatalogId == p.ProductCatalogId);
            if (item == null)
                _carrito.Add(p);
        }

        // === Quitar producto ===
        public void QuitarDelCarrito(string productCatalogId)
        {
            _carrito.RemoveAll(x => x.ProductCatalogId == productCatalogId);
        }

        // === Calcular total ===
        public decimal CalcularTotal() => _carrito.Sum(x => x.Precio);

        // === Guardar compra ===
        public void FinalizarCompra(Usuario usuario)
        {
            _repo.RegistrarCompra(usuario, _carrito);
            _carrito.Clear();
        }
    }
}
