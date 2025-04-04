using BlogProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggingContext _context;
        public BlogPostRepository(BloggingContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(int blogPostId)
        {
            return await _context.BlogPosts.Include(bp => bp.Comments).FirstOrDefaultAsync(bp => bp.BlogPostId == blogPostId);
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync()
        {
            return await _context.BlogPosts.Include(bp => bp.Comments).ToListAsync();
        }

        public async Task AddBlogPostAsync(BlogPost blogPost)
        {
            await _context.BlogPosts.AddAsync(blogPost);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBlogPostAsync(BlogPost blogPost)
        {
            _context.BlogPosts.Update(blogPost);
            await _context.SaveChangesAsync();
            
        }
        public async Task DeleteBlogPostAsync(int blogPostId)
        {
            var blogpost = await _context.BlogPosts.FindAsync(blogPostId);
            if (blogpost!=null)
            {
                _context.BlogPosts.Remove(blogpost);
                await _context.SaveChangesAsync();
            }
            
           
        }



    }

}
