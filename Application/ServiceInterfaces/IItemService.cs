using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces
{
    public interface IItemService
    {
        Task<string> AddItem(Item entity, CancellationToken cancellationToken = default);
        Task<string> UpdateItem(Item entity, CancellationToken cancellationToken = default);
        Task<Item> GetItem(int itemId, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Item> entities, string Message)> GetItems(int categoryId, CancellationToken cancellationToken = default);
        Task<string> RemoveItem(int? itemId, CancellationToken cancellationToken = default);
    }
}
