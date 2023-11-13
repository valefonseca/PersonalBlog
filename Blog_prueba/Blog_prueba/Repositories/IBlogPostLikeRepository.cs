using Blog_prueba.Models.Domain;

namespace Blog_prueba.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikes(Guid blogPostId);

        Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);

        Task<BlogPostLike>AddLikeForBlog(BlogPostLike blogPostLike);
    }
}
