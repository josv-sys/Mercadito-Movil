using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Infrastructure.Repositories
{
    public class DataFileRepository
    {
        private readonly string basePath;

        public DataFileRepository()
        {
            // Ruta base a la carpeta "Data"
            basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        }

        // ===========================
        // OBTENER FERIAS (markets.csv)
        // ===========================
        public List<Feria> ObtenerFerias()
        {
            string file = Path.Combine(basePath, "markets.csv");
            var ferias = new List<Feria>();

            if (!File.Exists(file))
                return ferias;

            var lines = File.ReadAllLines(file).Skip(1);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length < 5) continue;

                ferias.Add(new Feria
                {
                    MarketId = parts[0],
                    MarketName = parts[1],
                    Province = parts[2],
                    Canton = parts[3],
                    District = parts[4]
                });
            }
            return ferias;
        }

        // ===========================
        // OBTENER PRODUCTOS (product_catalog.csv)
        // ===========================
        public List<Producto> ObtenerProductosCatalogo()
        {
            string file = Path.Combine(basePath, "product_catalog.csv");
            var productos = new List<Producto>();

            if (!File.Exists(file))
                return productos;

            var lines = File.ReadAllLines(file).Skip(1);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length < 3) continue;

                productos.Add(new Producto
                {
                    ProductCatalogId = parts[0],
                    Nombre = parts[1],
                    Unidad = parts[2],
                    Activo = parts.Length > 3 && parts[3].ToLower().Contains("true")
                });
            }

            return productos;
        }

        // ===========================
        // OBTENER PRECIOS (producer_products.csv)
        // ===========================
        public decimal ObtenerPrecioProducto(string productCatalogId)
        {
            string file = Path.Combine(basePath, "producer_products.csv");

            if (!File.Exists(file))
                return 0;

            var line = File.ReadAllLines(file)
                           .Skip(1)
                           .Select(l => l.Split(','))
                           .FirstOrDefault(p => p.Length > 3 && p[2] == productCatalogId);

            if (line == null)
                return 0;

            return decimal.TryParse(line[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var precio)
                ? precio
                : 0;
        }

        // ===========================
        // REGISTRAR COMPRA
        // ===========================
        public void RegistrarCompra(Usuario usuario, List<Producto> carrito)
        {
            string folder = Path.Combine(basePath, "commerce");
            Directory.CreateDirectory(folder);
            string file = Path.Combine(folder, "compras.csv");

            decimal total = carrito.Sum(p => p.Precio);
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string linea = $"{usuario.UserId},{usuario.Nombre},{total},{fecha}";
            File.AppendAllText(file, linea + Environment.NewLine);
        }
    }
}

