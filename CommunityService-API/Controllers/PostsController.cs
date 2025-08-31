using CommunityService_API.DTOs;
using CommunityService_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace CommunityService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;
        public PostsController(PostService postService) => _postService = postService;

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostCreateDto dto)
        {
            if (dto.CommunityId == Guid.Empty || dto.AuthorId == Guid.Empty)
                return BadRequest("CommunityId và AuthorId là bắt buộc.");

            var post = await _postService.CreatePostAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

   
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            return post == null ? NotFound() : Ok(post);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PostUpdateDto dto)
        {
            var updated = await _postService.UpdatePostAsync(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _postService.DeletePostAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
