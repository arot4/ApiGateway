﻿namespace ApiGateway.Gateway.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double Precio { get; set; }
    }
}
