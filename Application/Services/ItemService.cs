using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ItemService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<(IEnumerable<Item> entities, string Message)> GetItems(int categoryId, CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.ItemRepository.GetItems(categoryId);
            return (categories, "Items retrieved");
        }

        public async Task<string> AddItem(Item entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                await _repositoryManager.ItemRepository.Add(entity);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "New Item added";
            }
            throw new Exception("Add Error");
        }

        public async Task<string> UpdateItem(Item entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                await _repositoryManager.ItemRepository.Update(entity);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Item updated";
            }
            throw new Exception("Update Error");
        }

        public async Task<Item> GetItem(int itemId, CancellationToken cancellationToken = default)
        {
            return await _repositoryManager.ItemRepository.GetById(itemId);
        }
        public async Task<string> RemoveItem(int? itemId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ItemRepository.GetById(itemId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Item", Convert.ToString(itemId));
            }
            else
            {
                _repositoryManager.ItemRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Item deleted";
            }
        }
    }
}
