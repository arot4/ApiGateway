using Microsoft.AspNetCore.Mvc;
using ApiGateway.Gateway.Models;

namespace ApiGateway.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public ClientesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/clientes/{id}");
            var client = _clientFactory.CreateClient("SQLServer");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var cliente = await response.Content.ReadFromJsonAsync<Cliente>();
                return Ok(cliente);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/clientes");
            var client = _clientFactory.CreateClient("SQLServer");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var cliente = await response.Content.ReadFromJsonAsync<List<Cliente>>();
                return Ok(cliente);
            }
            else
            {
                return NotFound();
            }
        }
    }

}