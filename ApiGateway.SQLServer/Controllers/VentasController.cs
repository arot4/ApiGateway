using ApiGateway.SQLServer.Models;
using ApiGateway.SQLServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGateway.SQLServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CrearVenta([FromBody] Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVenta", new { id = venta.Id }, venta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
                return NotFound();

            return Ok(venta);
        }
    }

}
