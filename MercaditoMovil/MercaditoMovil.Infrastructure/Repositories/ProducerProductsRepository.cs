using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MercaditoMovil.Infrastructure.Repositories
{
    public class ProducerProductsRepository
    {
        private readonly string _file;

        public ProducerProductsRepository()
        {
            _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles", "Commerce", "producer_products.csv");
        }

        public List<(string ProductCatalogId, decimal Price, int Stock)> GetAvailability()
        {
            var result = new List<(string, decimal, int)>();

            if (!File.Exists(_file))
                return result;

            var lines = File.ReadAllLines(_file).Skip(1);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length < 18)
                    continue;

                string catalogId = parts[2].Trim();

                // Precio
                decimal price = 0;
                decimal.TryParse(parts[3], NumberStyles.Any, CultureInfo.InvariantCulture, out price);

                // Stock (si está vacío lo ponemos en 1)
                int stock = 0;
                if (!int.TryParse(parts[13], out stock))
                    stock = 1;

                // Solo activos
                bool active = parts[17].Trim().ToLower() == "true";
                if (!active)
                    continue;

                result.Add((catalogId, price, stock));
            }

            return result;
        }
    }
}


