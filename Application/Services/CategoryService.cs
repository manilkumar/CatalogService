using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<(IEnumerable<Category> entities, string Message)> GetAllCategories(CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.CategoryRepository.GetCategories();
            return (categories, "Categories retrieved");
        }

        public async Task<string> AddCategory(Category entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                await _repositoryManager.CategoryRepository.Add(entity);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "New category added";
            }
            throw new Exception("Add Error");
        }

        public async Task<string> UpdateCategory(Category entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                await _repositoryManager.CategoryRepository.Update(entity);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Category updated";
            }
            throw new Exception("Update Error");
        }

        public async Task<Category> GetCategory(int categoryId, CancellationToken cancellationToken = default)
        {
            return await _repositoryManager.CategoryRepository.GetById(categoryId);
        }

        public async Task<string> RemoveCategory(int? categoryId, CancellationToken cancellationToken = default)
        {
            var category = await _repositoryManager.CategoryRepository.GetById(categoryId);
            if (category == null)
            {
                throw new EntityKeyNotFoundException("Category", Convert.ToString(categoryId));
            }
            else
            {
                _repositoryManager.CategoryRepository.Remove(category);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Category deleted";
            }
        }
    }
}