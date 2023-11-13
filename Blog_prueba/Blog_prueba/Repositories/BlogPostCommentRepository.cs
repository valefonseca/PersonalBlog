using Blog_prueba.Data;
using Blog_prueba.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog_prueba.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogDbContext blogDbContext;

        public BlogPostCommentRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await blogDbContext.BlogPostComment.AddAsync(blogPostComment);
            await blogDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await blogDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId).ToListAsync();

        }
    }
}
