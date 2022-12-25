using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class ProjectContext: DbContext
    {
        private static ProjectContext? _instance;
        public static ProjectContext Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = Instantiate_ProjectContext();
                }
                return _instance;
            }
        }

        public ProjectContext(DbContextOptions o) : base(o) { }

        public static ProjectContext Instantiate_ProjectContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectContext>();
            var connection = optionsBuilder.UseSqlite("Data Source=C:/Users/MSI/Desktop/project.db");
            return new ProjectContext(optionsBuilder.Options);
        }

        public DbSet<User>? User { get; set; }
    }
}
