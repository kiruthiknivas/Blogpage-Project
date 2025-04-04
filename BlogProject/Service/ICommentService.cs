using BlogProject.DTOs;
using BlogProject.Models;

namespace BlogProject.Service
{
    public interface ICommentService
    {
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<IEnumerable<Comment>> GetCommentsByBlogPostIdAsync(int blogPostId);
        Task AddCommentAsync(CommentDto commentdto);
    }
}
