namespace Application.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        ICategoryRepository CategoryRepository { get; }
        IItemRepository ItemRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}