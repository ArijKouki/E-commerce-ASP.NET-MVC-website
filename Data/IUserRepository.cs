using project.Models;

namespace project.Data
{
    public interface IUserRepository : IRepository<User>
    {
        public List<User> GetAllUsers();
        public Task<List<User>> GetAllUsersAsync();
        public User GetUserByLogin(string email, string password);
        public void AddUser(string first_name, string last_name, string email, string password, string birth_date, string address);
        public void UpdateUser(string first_name, string last_name, string email, string password, string birth_date, string address);

    }
}