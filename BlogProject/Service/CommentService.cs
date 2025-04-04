using BlogProject.DTOs;
using BlogProject.Models;
using BlogProject.Repository;

namespace BlogProject.Service
{
    public class CommentService : ICommentService

    {

        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _commentRepository.GetCommentByIdAsync(commentId);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByBlogPostIdAsync(int blogPostId)
        {
            return await _commentRepository.GetCommentsByBlogPostIdAsync(blogPostId);
        }

        public async Task AddCommentAsync(CommentDto commentdto)
        {
            var comment = new Comment
            {
                Content = commentdto.Content,
                CreatedAt = commentdto.CreatedAt,
                BlogPostId = commentdto.BlogPostId,
                UserId = commentdto.UserId

            };

            await _commentRepository.AddCommentAsync(comment);
        }



    }
}
