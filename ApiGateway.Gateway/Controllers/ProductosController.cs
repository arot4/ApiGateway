using Microsoft.AspNetCore.Mvc;
using ApiGateway.Gateway.Models;

namespace ApiGateway.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductosController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/productos/{id}");
            var client = _clientFactory.CreateClient("SQLServer");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var producto = await response.Content.ReadFromJsonAsync<Producto>();
                return Ok(producto);
            }
            else
            {
                return NotFound();
            }
        }
    }

}