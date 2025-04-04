using BlogProject.DTOs;
using BlogProject.Repository;
using System.Reflection.Metadata;

namespace BlogProject.Service
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(int blogPostId)
        {
            return await _blogPostRepository.GetBlogPostByIdAsync(blogPostId);
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync()
        {
            return await _blogPostRepository.GetAllBlogPostsAsync();
        }

        public async Task CreateBlogPostAsync(BlogPostDto blogPostDto)
        {
            var blogPost = new BlogPost
            {
                Title = blogPostDto.Title,
                Content = blogPostDto.Content,
                CreatedAt = DateTime.UtcNow,
                UserId = blogPostDto.UserId
            };
            await _blogPostRepository.AddBlogPostAsync(blogPost);
        }

        public async Task UpdateBlogPostAsync(int blogPostId, BlogPost updatedBlogPost)
        {
            var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(blogPostId);
            if(blogPost != null)
            {
                blogPost.Title = updatedBlogPost.Title;
                blogPost.Content = updatedBlogPost.Content;
                await _blogPostRepository.UpdateBlogPostAsync(blogPost);
            }  
        }

        public async Task DeleteBlogPostAsync(int blogPostId)
        {
            await _blogPostRepository.DeleteBlogPostAsync(blogPostId);
        }


    }
}
