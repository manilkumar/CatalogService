using Application.RepositoryInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Item?> GetById(int? itemId)
        {
            return await _context.Set<Item>().FindAsync(itemId);
        }

        public async ValueTask<List<Item>> GetItems(int categoryId)
        {
            return await _context.Set<Item>().Where(i => i.Id == categoryId).ToListAsync();
        }
    }
}
