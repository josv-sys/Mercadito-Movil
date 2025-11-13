namespace MercaditoMovil.Domain.Entities
{
    public class Usuario
    {
        public string UserId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        // Feria asignada al usuario
        public string MarketId { get; set; }
    }
}

