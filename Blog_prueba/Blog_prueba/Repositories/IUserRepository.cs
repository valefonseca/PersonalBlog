using Microsoft.AspNetCore.Identity;

namespace Blog_prueba.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
