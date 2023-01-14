/*using project.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace project.Data
{
    public class CommandRepository : Repository<Command>, ICommandRepository
    {
        private readonly ProjectContext context;
        public CommandRepository(ProjectContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return context.Command.ToList();
        }
    }
}*/