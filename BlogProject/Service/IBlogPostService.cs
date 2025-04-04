using BlogProject.DTOs;

namespace BlogProject.Service
{
    public interface IBlogPostService
    {
        Task<BlogPost> GetBlogPostByIdAsync(int blogPostId);
        Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync();
        Task CreateBlogPostAsync(BlogPostDto blogPostDto);
        Task UpdateBlogPostAsync(int blogPostId, BlogPost updatedBlogPost);
        Task DeleteBlogPostAsync(int blogPostId);
    }
}