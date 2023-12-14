using MongoDB.Bson;

namespace ApiGateway.MongoDB.Models
{
    public class UserPreference
    {
        public ObjectId Id { get; set; }
        public string? UserId { get; set; }
        public List<int>? LikedProductIds { get; set; }
        public List<int>? DislikedProductIds { get; set; }
    }

}
