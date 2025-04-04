using BlogProject.DTOs;
using BlogProject.JWThelper;
using BlogProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogWriterController : ControllerBase
    {
        private readonly BloggingContext _context;
        private readonly JwtTokenHelper _jwtTokenHelper;

        public BlogWriterController(BloggingContext context, JwtTokenHelper jwtTokenHelper)
        {
            _context = context;
            _jwtTokenHelper = jwtTokenHelper;
        }

        //Register
        [HttpPost("blogwriter-register")]

        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            var user = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = registerDto.Password,
                Age = registerDto.Age,
                Gender = registerDto.Gender,
                IsBlogWriter = registerDto.IsBlogWriter
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "BlogWriter Registered Successfully" });
        }


        //Login
        [HttpPost("blogwriter-login")]

        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.Email == model.Username && m.Password == model.Password && m.IsBlogWriter);
            if (user == null)
            {
                return Unauthorized();
            }
            var token = _jwtTokenHelper.GenerateToken(user.UserId.ToString(), user.Email);
            return Ok(new { token });

        }

        [Authorize]
        [HttpPost("create-blog")]
    

        public async Task<IActionResult> CreateBlogPost([FromBody] BlogPostDto blogPostDto)
        {
            var blogPost = new BlogPost
            {
                Title = blogPostDto.Title,
                Content = blogPostDto.Content,
                CreatedAt = DateTime.UtcNow,
                UserId = blogPostDto.UserId
            };
            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Blog created and added sucessfully" });

        }

        [Authorize]
        [HttpGet("my-blog/{userId}")]
     

        public async Task<IActionResult> GetMyBlogs(int userId)
        {
            var blogs = await _context.BlogPosts
                        .Where(bp => bp.UserId == userId)
                        .Include(bp => bp.Comments)
                        .ToListAsync();
            if (blogs == null)
            {
                return NotFound();
            }
            return Ok(blogs);
        }

        [Authorize]
        [HttpPut("edit/{blogPostId}")]
        public async Task<IActionResult> EditMyBlog(int blogPostId, [FromBody] BlogPostDto updatedBlogPostDto)
        {
            var blogPost = await _context.BlogPosts.FindAsync(blogPostId);

            if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.Title = updatedBlogPostDto.Title;
            blogPost.Content = updatedBlogPostDto.Content;
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Blog Updated Successfully" });
        }

        [Authorize]

        [HttpGet("comments/{blogPostId}")]
 
        public async Task<IActionResult> GetComments(int blogPostId)
        {
            var comments = await _context.Comments
                           .Where(cm => cm.BlogPostId == blogPostId)
                           .ToListAsync();

            return Ok(comments);

        }
    }
}
