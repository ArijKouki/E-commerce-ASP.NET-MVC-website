using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class Product
    {
        public Product(int Product_Id, string name, string release_date, string description, string type, float price, string singer, string img, string genre,int nb_exemplaires)
        {
            this.Product_Id = Product_Id;
            this.name = name;
            this.release_date = release_date;
            this.description = description;
            this.type = type;
            this.price = price;
            this.singer = singer;
            this.img = img;
            this.genre = genre;
            this.nb_exemplaires = nb_exemplaires;
        }
        

        [Key]  public int Product_Id { get; set; }
        
        public string name { get; set; }
        public string release_date { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public float price { get; set; }
        public string singer { get; set; }
        public string img { get; set; }
        public string genre { get; set; }
        public int nb_exemplaires { get; set; }
    }
}