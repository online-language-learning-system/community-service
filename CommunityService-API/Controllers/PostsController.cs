using CommunityService_API.DTOs;
using CommunityService_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CommunityService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;
        public PostsController(PostService postService) => _postService = postService;

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostCreateDto dto)
        {
            var post = await _postService.CreatePostAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        // READ ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        // READ BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            return post == null ? NotFound() : Ok(post);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PostUpdateDto dto)
        {
            var updated = await _postService.UpdatePostAsync(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _postService.DeletePostAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
