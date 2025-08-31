using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityService_API.Models
{
    [Table("memberships", Schema = "app")]
    public class Membership
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CommunityId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = "member"; 

        public DateTimeOffset JoinedAt { get; set; }

        public Community? Community { get; set; }
    }
}
