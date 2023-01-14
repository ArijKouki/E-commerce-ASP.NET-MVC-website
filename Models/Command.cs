/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Command
    {
        [Key]
        public int Cmd_Id { get; set; }

        [ForeignKey("ProductId")]
        List<Product> products_list;
        public int Product_Id { get; set; }

        [ForeignKey("User_Id")]
        public int User_Id { get; set; }
        
        public int quantity { get; set; }
        public float sum { get; set; }
        public Command()
        {
            products_list = new List<Product>();
        }
        public void addProduct(Product product)
        {
            products_list.Add(product);
        }
        public void deleteProduct(Product product)
        {
            products_list.Remove(product);
        }
        public void sommeCommand()
        {
            for (int i = 0; i < products_list.Count; i++)
            {
                this.sum += products_list[i].price;
            }
        }
        
    }
}*/