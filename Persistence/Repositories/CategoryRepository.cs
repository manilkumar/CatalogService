using Application.RepositoryInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Category?> GetById(int? categoryId)
        {
            return await _context.Set<Category>().FindAsync(categoryId);
        }
        public async ValueTask<List<Category>> GetCategories()
        {
            return await _context.Set<Category>().ToListAsync();
        }
    }
}
