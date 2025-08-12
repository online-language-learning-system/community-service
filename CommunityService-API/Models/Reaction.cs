namespace CommunityService_API.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public int PostId { get; set; } 
        public Post Post { get; set; } = null!;
        public string UserId { get; set; } = ""; 
        public string Type { get; set; } = ""; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
