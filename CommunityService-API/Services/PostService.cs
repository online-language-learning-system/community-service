using CommunityService_API.DTOs;
using CommunityService_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityService_API.Services
{
    public class PostService
    {
        private readonly CommunityDbContext _context;

        public PostService(CommunityDbContext context)
        {
            _context = context;
        }

        public async Task<Post> CreatePostAsync(PostCreateDto dto)
        {
            var post = new Post
            {
                Id = Guid.NewGuid(),
                CommunityId = dto.CommunityId,
                AuthorId = dto.AuthorId,
                Title = dto.Title,
                Content = dto.Content,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post?> GetPostByIdAsync(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<Post?> UpdatePostAsync(Guid id, PostUpdateDto dto)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return null;

            post.Title = dto.Title;
            post.Content = dto.Content;
            post.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> DeletePostAsync(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
