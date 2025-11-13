using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Infrastructure.Repositories;

namespace MercaditoMovil.Application.Services
{
    public class CarritoService
    {
        private readonly Usuario _usuario;
        private readonly MarketRepository _marketRepo;
        private readonly ProductAvailabilityRepository _availabilityRepo;

        private readonly List<Producto> _carrito = new();

        public CarritoService(Usuario usuario)
        {
            _usuario = usuario;
            _marketRepo = new MarketRepository();
            _availabilityRepo = new ProductAvailabilityRepository();
        }

        public Feria? ObtenerFeria()
            => _marketRepo.GetById(_usuario.MarketId);

        public List<Producto> ObtenerProductos()
            => _availabilityRepo.GetByMarket(_usuario.MarketId);

        public List<Producto> ObtenerCarrito()
            => _carrito;

        public void Agregar(Producto p)
        {
            if (p.Stock > 0)
                _carrito.Add(p);
        }

        public void Quitar(Producto p)
        {
            _carrito.Remove(p);
        }

        // ==========================================
        // FINALIZAR COMPRA
        // ==========================================
        public bool FinalizarCompra()
        {
            if (_carrito.Count == 0)
                return false;

            string folder = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles", "Commerce");

            Directory.CreateDirectory(folder);

            string file = Path.Combine(folder, "compras.csv");

            decimal total = _carrito.Sum(p => p.Precio);

            string linea =
                $"{_usuario.UserId},{_usuario.Nombre},{total},{DateTime.Now:yyyy-MM-dd HH:mm:ss}";

            File.AppendAllText(file, linea + Environment.NewLine);

            _carrito.Clear();
            return true;
        }
    }
}
