using Microsoft.EntityFrameworkCore;
using CommunityService_API.Models;

namespace CommunityService_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Community> Communities { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Schema mặc định là "app"
            modelBuilder.HasDefaultSchema("app");

            // COMMUNITY
            modelBuilder.Entity<Community>(entity =>
            {
                entity.ToTable("communities");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
            });

            // MEMBERSHIP
            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("memberships");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Role).HasMaxLength(50).IsRequired();
                entity.Property(e => e.JoinedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");

                entity.HasOne(e => e.Community)
                      .WithMany(c => c.Memberships)
                      .HasForeignKey(e => e.CommunityId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // POST
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");

                entity.HasOne(e => e.Community)
                      .WithMany(c => c.Posts)
                      .HasForeignKey(e => e.CommunityId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // COMMENT
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");

                entity.HasOne(e => e.Post)
                      .WithMany(p => p.Comments)
                      .HasForeignKey(e => e.PostId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // REACTION
            modelBuilder.Entity<Reaction>(entity =>
            {
                entity.ToTable("reactions");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Type).HasMaxLength(50).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");

                entity.HasOne(e => e.Post)
                      .WithMany(p => p.Reactions)
                      .HasForeignKey(e => e.PostId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // BOOKMARK
            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.ToTable("bookmarks");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");

                entity.HasOne(e => e.Post)
                      .WithMany(p => p.Bookmarks)
                      .HasForeignKey(e => e.PostId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
