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
        public DbSet<Community> Communities => Set<Community>();
        public DbSet<Membership> Memberships => Set<Membership>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Đặt schema mặc định là "app"
            modelBuilder.HasDefaultSchema("app");

            // Map các bảng
            modelBuilder.Entity<Post>().ToTable("posts", "app");
            modelBuilder.Entity<Comment>().ToTable("comments", "app");
            modelBuilder.Entity<Reaction>().ToTable("reactions", "app");
            modelBuilder.Entity<Bookmark>().ToTable("bookmarks", "app");
            modelBuilder.Entity<Community>().ToTable("communities", "app");
            modelBuilder.Entity<Membership>().ToTable("memberships", "app");

            // Quan hệ Community (1) - Membership (n)
            modelBuilder.Entity<Membership>()
                .HasOne(m => m.Community)
                .WithMany(c => c.Memberships)
                .HasForeignKey(m => m.CommunityId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
