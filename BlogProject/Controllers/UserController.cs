using BlogProject.DTOs;
using BlogProject.JWThelper;
using BlogProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly BloggingContext _context;
        private readonly JwtTokenHelper _jwtTokenHelper;

        public UserController(BloggingContext context, JwtTokenHelper jwtTokenHelper)
        {
            _context = context;
            _jwtTokenHelper = jwtTokenHelper;
        }

        [HttpPost("user-register")]
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
            return Ok(new { message = "User Registration Successfull" });
        }

        [HttpPost("user-login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Username && u.Password == model.Password && !u.IsBlogWriter);
            if(user==null)
            {
                return Unauthorized();
            }
            var token = _jwtTokenHelper.GenerateToken(user.UserId.ToString(), user.Email);
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("blogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _context.BlogPosts
                        .Include(bp => bp.Comments)
                        
                        .ToListAsync();
            return Ok(blogs);
        }

        [Authorize]
        [HttpPost("add-comments")]

        public async Task<IActionResult> AddComments([FromBody]CommentDto commentDto)
        {
            var comment = new Comment
            {
                Content = commentDto.Content,
                CreatedAt = commentDto.CreatedAt,
                BlogPostId = commentDto.BlogPostId,
                UserId = commentDto.UserId
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return Ok(new { message = "comment added successfully" });
        }
        

    }
}
