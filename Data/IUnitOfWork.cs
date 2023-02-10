
namespace project.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        ICartRepository CartItems { get; }
        IOrderRepository Orders { get; }

        void Save();
    }
}