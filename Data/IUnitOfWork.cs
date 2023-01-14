namespace project.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        //ICommandRepository Commands { get; }
        void Save();
    }
}