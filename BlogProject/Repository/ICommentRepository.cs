using BlogProject.Models;

namespace BlogProject.Repository
{
    public interface ICommentRepository
    {
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<IEnumerable<Comment>> GetCommentsByBlogPostIdAsync(int blogPostId);
        Task AddCommentAsync(Comment comment);

    }
}
