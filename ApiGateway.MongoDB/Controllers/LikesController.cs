using ApiGateway.MongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiGateway.MongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : ControllerBase
    {
        private readonly IMongoCollection<UserPreference> _userPreferences;

        public LikesController(IMongoDatabase database)
        {
            _userPreferences = database.GetCollection<UserPreference>("UserPreferences");
        }

        // Agregar un like a un producto
        [HttpPost("{userId}/like/{productId}")]
        public async Task<IActionResult> AddLike(string userId, int productId)
        {
            var filter = Builders<UserPreference>.Filter.Eq(up => up.UserId, userId);
            var update = Builders<UserPreference>.Update.AddToSet(up => up.LikedProductIds, productId);
            await _userPreferences.UpdateOneAsync(filter, update);

            return Ok();
        }

        // Agregar un dislike a un producto
        [HttpPost("{userId}/dislike/{productId}")]
        public async Task<IActionResult> AddDislike(string userId, int productId)
        {
            var filter = Builders<UserPreference>.Filter.Eq(up => up.UserId, userId);
            var update = Builders<UserPreference>.Update.AddToSet(up => up.DislikedProductIds, productId);
            await _userPreferences.UpdateOneAsync(filter, update);

            return Ok();
        }

        // Otros métodos según sea necesario...
    }
}
