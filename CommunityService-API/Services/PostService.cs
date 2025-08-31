using CommunityService_API.DTOs;
using CommunityService_API.Models;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
=======
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598

namespace CommunityService_API.Services
{
    public class PostService
    {
        private readonly CommunityDbContext _context;

        public PostService(CommunityDbContext context)
        {
            _context = context;
        }
<<<<<<< HEAD

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
=======
     
        public async Task<PostReadDto> CreatePostAsync(PostCreateDto dto)
        {
            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = dto.UserId
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
<<<<<<< HEAD
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
=======

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
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
