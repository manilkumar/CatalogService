using Application.RepositoryInterfaces;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICategoryRepository> _lazyCartRepository;
        private readonly Lazy<IItemRepository> _lazyItemRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(ApplicationDbContext context)
        {
            _lazyCartRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
            _lazyItemRepository = new Lazy<IItemRepository>(() => new ItemRepository(context));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }
        public ICategoryRepository CategoryRepository => _lazyCartRepository.Value;
        public IItemRepository ItemRepository => _lazyItemRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
