using System.ComponentModel.DataAnnotations;
namespace project.Models
{
    public class User
    {
        public User(int User_Id, string first_name, string last_name, string email, string password, string birth_date, string address)
        {
            this.User_Id = User_Id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.password = password;
            this.birth_date = birth_date;
            this.address = address;
        }
        public static int id_generator = 100;

        [Key]  public int User_Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set;}
        public string email { get; set; }
        public string password { get; set; }
        public string birth_date { get; set; }
        public string address { get; set; }
    }
}
