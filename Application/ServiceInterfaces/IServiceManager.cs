namespace Application.ServiceInterfaces
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        IItemService ItemService { get; }
    }
}