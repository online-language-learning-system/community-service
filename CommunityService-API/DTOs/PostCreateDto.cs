namespace CommunityService_API.DTOs
{
    public class PostCreateDto
    {
<<<<<<< HEAD
        public Guid CommunityId { get; set; }   // Bắt buộc
        public Guid AuthorId { get; set; }      // Bắt buộc
        public string Title { get; set; }
        public string Content { get; set; }
=======
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
        public string UserId { get; set; } = "";
    }
}
