using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        ValueTask<Category?> GetById(int? itemId);
        ValueTask<List<Category>> GetCategories();
    }
}