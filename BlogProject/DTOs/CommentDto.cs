using BlogProject.Models;

namespace BlogProject.DTOs
{
    public class CommentDto
    {
        //public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BlogPostId { get; set; }
        //public BlogPostDto BlogPost { get; set; }
        public int UserId { get; set; }
       // public LoginModel User { get; set; }
    }
}
