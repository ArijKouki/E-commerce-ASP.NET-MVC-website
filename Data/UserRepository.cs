using project.Models;
using System.Diagnostics;

namespace project.Data
{
    public class UserRepository
    {
        public static User currentUser { get; set; }
        public List<User> all()
        {
            ProjectContext pc = ProjectContext.Instance;
            var users = pc.User;
            if (users == null) { return new List<User>(); }
            return users.ToList();
        }

        public User getUserByLogin(string email, string password) {
            ProjectContext pc = ProjectContext.Instance;
            var users = pc.User.ToList();
            User u=null;
            foreach(var user in users)
            {
                if(user.email == email && user.password == password) { u = user; }
            }
            return u;
        }

        public void addUser(string first_name, string last_name, string email, string password, string birth_date, string address)
        {
            ProjectContext pc = ProjectContext.Instance;
            User.id_generator++;
            var id = User.id_generator;
            User u = new User(id, first_name, last_name, email, password, birth_date, address);
            pc.User.Add(u);
            pc.SaveChanges();
        }
    }
}
