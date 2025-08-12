using CommunityService_API.DTOs;
using CommunityService_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityService_API.Services
{
    public class PostService
    {
        private readonly CommunityDbContext _context;

        public PostService(CommunityDbContext context)
        {
            _context = context;
        }
     
        public async Task<PostReadDto> CreatePostAsync(PostCreateDto dto)
        {
            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = dto.UserId
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return new PostReadDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                UserId = post.UserId,
                CreatedAt = post.CreatedAt
            };
        }
 
        public async Task<PostReadDto?> GetPostByIdAsync(int id)
        {
            var post = await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.Reactions)
                .Include(p => p.Bookmarks)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null) return null;

            return new PostReadDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                UserId = post.UserId,
                CreatedAt = post.CreatedAt
            };
        }
     
        public async Task<IEnumerable<PostReadDto>> GetAllPostsAsync()
        {
            return await _context.Posts
                .OrderByDescending(p => p.CreatedAt)
                .Select(post => new PostReadDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    UserId = post.UserId,
                    CreatedAt = post.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<bool> UpdatePostAsync(int id, PostUpdateDto dto)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return false;

            post.Title = dto.Title;
            post.Content = dto.Content;
            post.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
