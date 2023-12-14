namespace ApiGateway.SQLServer.Models.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaVenta { get; set; }
        
    }

}
