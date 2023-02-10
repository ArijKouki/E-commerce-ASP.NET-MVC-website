using System;


namespace project.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext context;
        public IUserRepository Users { get; set; }
        public IProductRepository Products { get; set; }
        public ICartRepository CartItems { get; set; }
        public IOrderRepository Orders { get; set; }


        public UnitOfWork(ProjectContext context)
        {
            this.context = context;
            Users = new UserRepository(context);
            Products = new ProductRepository(context);
            CartItems= new CartRepository(context);
            Orders = new OrderRepository(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}