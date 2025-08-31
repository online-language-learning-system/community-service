<<<<<<< HEAD
﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityService_API.Models
{
    [Table("reactions", Schema = "app")]
    public class Reaction
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PostId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;

        public DateTimeOffset CreatedAt { get; set; }

        public Post? Post { get; set; }
=======
﻿namespace CommunityService_API.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public int PostId { get; set; } 
        public Post Post { get; set; } = null!;
        public string UserId { get; set; } = ""; 
        public string Type { get; set; } = ""; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
    }
}
