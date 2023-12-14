using ApiGateway.SQLServer.Models;
using ApiGateway.SQLServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGateway.SQLServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los clientes
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return clientes;
        }

        // Obtener un cliente por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            return cliente;
        }

    }


}