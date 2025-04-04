using BlogProject.JWThelper;
using BlogProject.Models;
using BlogProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;
        private readonly JwtTokenHelper _jwtTokenHelper;

        public AdminController(IBlogPostService blogPostService, JwtTokenHelper jwtTokenHelper)
        {
            _blogPostService = blogPostService;
            _jwtTokenHelper = jwtTokenHelper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "admin")
            {
                var token = _jwtTokenHelper.GenerateToken(model.Username.ToString(), model.Password);
                return Ok(new { token });

            }
            else
            {
                return Unauthorized();
            }
        }

        [Authorize]

        [HttpGet("blogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _blogPostService.GetAllBlogPostsAsync();
            return Ok(blogs);
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBlogs(int id)
        {
            await _blogPostService.DeleteBlogPostAsync(id);
            return Ok(new { Message = "BlogPost deleted successfully" });
        }
    }
}
