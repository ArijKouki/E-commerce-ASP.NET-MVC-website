using System;
using System.Data.SQLite;
using System.Diagnostics;

namespace project.Models
{
    public class UserInfo
    {
       /* public static User getUserByLogin(string email, string password)
        {
            User u= null;
            SQLiteConnection sqlCo = new SQLiteConnection("Data Source=C:/Users/MSI/Desktop/project.db");
            try
            {
                sqlCo.Open();
                Debug.WriteLine("Connection opened !");
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM User WHERE email=@email AND password=@password", sqlCo);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    Debug.WriteLine("Query succeeded !");

                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string firstName = (string)reader["first_name"];
                        string lastName = (string)reader["last_name"];
                        string birth_date = (string)reader["birth_date"];
                        string address = (string)reader["address"];
                        u = new User(id, firstName, lastName, email, password, birth_date, address);
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                sqlCo.Close();
                Debug.WriteLine("Connection closed !");

            }

            return u;

        }

        public static void addUser(User u) { }*/

    }
}

