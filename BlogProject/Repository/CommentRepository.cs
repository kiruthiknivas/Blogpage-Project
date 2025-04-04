using BlogProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BlogProject.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BloggingContext _context;

        public CommentRepository (BloggingContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByBlogPostIdAsync(int blogPostId)
        {
            return await _context.Comments.Where(cm => cm.BlogPostId == blogPostId).ToListAsync();
        }
        public async Task AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }



    }
}
