<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityService_API.Models
{
    [Table("posts", Schema = "app")]
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CommunityId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Community? Community { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
        public ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();
=======
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
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
    }
}
