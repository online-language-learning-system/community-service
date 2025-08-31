using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityService_API.Models
{
    [Table("bookmarks", Schema = "app")]
    public class Bookmark
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PostId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public Post? Post { get; set; }
    }
}
