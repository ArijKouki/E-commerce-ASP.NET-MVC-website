using System;
namespace project.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext context;
        public IUserRepository Users { get; set; }
        //public UserRepository userRepository { get; set; }

        

        public IProductRepository Products { get; set; }

        //public ICommandRepository Commands { get; set; }

        public UnitOfWork(ProjectContext context)
        {
            this.context = context;
            Users = new UserRepository(context);
            Products = new ProductRepository(context);
            //Commands = new CommandRepository(context);
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