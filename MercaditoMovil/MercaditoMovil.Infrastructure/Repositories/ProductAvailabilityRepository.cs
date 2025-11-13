using System.Collections.Generic;
using System.Linq;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Infrastructure.Repositories
{
    public class ProductAvailabilityRepository
    {
        private readonly ProductCatalogRepository _catalogRepo;
        private readonly ProducerProductsRepository _producerRepo;

        public ProductAvailabilityRepository()
        {
            _catalogRepo = new ProductCatalogRepository();
            _producerRepo = new ProducerProductsRepository();
        }

        public List<Producto> GetByMarket(string marketId)
        {
            // 1. Catálogo
            var catalog = _catalogRepo.GetAll();

            // 2. Precios y stock
            var availability = _producerRepo.GetAvailability();

            // 3. Unión catálogo + disponibilidad
            var lista = (from c in catalog
                         join a in availability
                         on c.ProductCatalogId equals a.ProductCatalogId
                         select new Producto
                         {
                             ProductCatalogId = c.ProductCatalogId,
                             Nombre = c.Nombre,
                             Unidad = c.Unidad,
                             Precio = a.Price,
                             Stock = a.Stock,
                             Activo = c.Activo
                         }).ToList();

            return lista;
        }
    }
}



