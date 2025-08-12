using CommunityService_API.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace CommunityService_API
{
    public class CommunityDbContext : DbContext
    {
        public CommunityDbContext(DbContextOptions<CommunityDbContext> options) : base(options) { }

        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Reaction> Reactions => Set<Reaction>();
        public DbSet<Bookmark> Bookmarks => Set<Bookmark>();
    }
}
