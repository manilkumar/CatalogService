using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _lazyCartService;
        private readonly Lazy<IItemService> _lazyItemService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyCartService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager));
            _lazyItemService = new Lazy<IItemService>(() => new ItemService(repositoryManager));
        }

        public ICategoryService CategoryService => _lazyCartService.Value;
        public IItemService ItemService => _lazyItemService.Value;
    }
}