using Domain.Entities;

namespace Application.ServiceInterfaces
{
    public interface ICategoryService
    {
        Task<string> AddCategory(Category entity, CancellationToken cancellationToken = default);
        Task<string> UpdateCategory(Category entity, CancellationToken cancellationToken = default);
        Task<Category> GetCategory(int categoryId, CancellationToken cancellationToken = default);

        Task<(IEnumerable<Category> entities, string Message)> GetAllCategories(CancellationToken cancellationToken = default);
        Task<string> RemoveCategory(int? categoryId, CancellationToken cancellationToken = default);
    }
}