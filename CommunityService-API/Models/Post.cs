﻿namespace CommunityService_API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public string UserId { get; set; } = ""; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public List<Comment> Comments { get; set; } = new();
        public List<Reaction> Reactions { get; set; } = new();
        public List<Bookmark> Bookmarks { get; set; } = new();
    }
}
