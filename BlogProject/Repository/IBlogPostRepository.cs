namespace BlogProject.Repository
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> GetBlogPostByIdAsync(int blogPostId);
        Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync();
        Task AddBlogPostAsync(BlogPost blogPost);
        Task UpdateBlogPostAsync(BlogPost blogPost);
        Task DeleteBlogPostAsync(int blogPostId);
    }
}
