using System;
namespace project.Data
{
    public class UnitOfWork 
    {
        private readonly ProjectContext context;
        public UserRepository userRepository { get; set; }
        public UnitOfWork(ProjectContext context)
        {
            this.context = context;
            userRepository= new UserRepository(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }
        
    }
}
