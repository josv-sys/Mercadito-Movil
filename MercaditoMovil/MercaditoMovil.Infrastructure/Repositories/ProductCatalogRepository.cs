using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Infrastructure.Repositories
{
    public class ProductCatalogRepository
    {
        private readonly string _file;

        public ProductCatalogRepository()
        {
            _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles", "Catalogs", "product_catalog.csv");
        }

        public List<Producto> GetAll()
        {
            var result = new List<Producto>();

            if (!File.Exists(_file))
                return result;

            var lines = File.ReadAllLines(_file).Skip(1);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length < 4)
                    continue;

                result.Add(new Producto
                {
                    ProductCatalogId = parts[0],
                    Nombre = parts[1],
                    Unidad = parts[2],
                    Activo = parts[3].Trim().ToLower() == "true"
                });
            }

            return result;
        }
    }
}

