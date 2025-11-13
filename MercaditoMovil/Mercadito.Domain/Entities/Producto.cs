namespace MercaditoMovil.Domain.Entities
{
    public class Producto
    {
        public string ProductCatalogId { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
        public int Stock { get; set; }

        public string ProducerId { get; set; }
        public string MarketId { get; set; }
    }
}
