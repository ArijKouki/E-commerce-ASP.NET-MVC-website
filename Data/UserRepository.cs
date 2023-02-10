using project.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace project.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ProjectContext context;

        public UserRepository(ProjectContext context) : base(context)
        {
            this.context = context;
        }
        public static User currentUser { get; set; }
        public List<User> GetAllUsers()
        {
            if (context.User == null) { return new List<User>(); }
            return context.User.ToList();
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return context.User.ToListAsync();
        }
        /*public User GetUserByID(int id)
        {
            return context.User.Find(id);
        }*/


        public User GetUserByLogin(string email, string password)
        {

            var users = context.User.ToList();
            User u = null;
            foreach (var user in users)
            {
                if (user.email == email && user.password == password) { u = user; }
            }
            return u;
        }

        public void AddUser(string first_name, string last_name, string email, string password, string birth_date, string address)
        {

            
            User u = new User( first_name, last_name, email, password, birth_date, address);
            context.User.Add(u);
        }

        public void UpdateUser(string first_name, string last_name, string email, string password, string birth_date, string address)
        {

            //User u = context.User.Find(UserRepository.currentUser.Id);
            currentUser.first_name = first_name;
            currentUser.last_name = last_name;
            currentUser.email = email;
            currentUser.password = password;
            currentUser.birth_date = birth_date;
            currentUser.address = address;
            //context.SaveChanges();
        }

    }
}