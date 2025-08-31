using CommunityService_API.DTOs;
using CommunityService_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
<<<<<<< HEAD
using System;
=======
using System.Collections.Generic;
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598

namespace CommunityService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;
        public PostsController(PostService postService) => _postService = postService;

<<<<<<< HEAD
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostCreateDto dto)
        {
            if (dto.CommunityId == Guid.Empty || dto.AuthorId == Guid.Empty)
                return BadRequest("CommunityId và AuthorId là bắt buộc.");

=======
        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostCreateDto dto)
        {
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
            var post = await _postService.CreatePostAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

<<<<<<< HEAD
      
=======
        // READ ALL
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

<<<<<<< HEAD
   
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
=======
        // READ BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
        {
            var post = await _postService.GetPostByIdAsync(id);
            return post == null ? NotFound() : Ok(post);
        }

<<<<<<< HEAD
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PostUpdateDto dto)
=======
        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PostUpdateDto dto)
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
        {
            var updated = await _postService.UpdatePostAsync(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }

<<<<<<< HEAD
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
=======
        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
        {
            var deleted = await _postService.DeletePostAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
