namespace CommunityService_API.DTOs
{
    public class PostCreateDto
    {
        public Guid CommunityId { get; set; }   // Bắt buộc
        public Guid AuthorId { get; set; }      // Bắt buộc
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; } = "";
    }
}
