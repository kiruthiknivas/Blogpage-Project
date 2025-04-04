namespace BlogProject.DTOs
{
    public class BlogPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; } // The ID of the blog writer creating the post
    }
}
