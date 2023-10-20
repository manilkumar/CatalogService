using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        ValueTask<Item?> GetById(int? itemId);
        ValueTask<List<Item>> GetItems(int categoryId);
    }
}
