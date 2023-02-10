using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class CartItem 
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Item_Id { get; set; }

        [ForeignKey("User_Id")]
        public int User_Id { get; set; }

        [ForeignKey("Produt_Id")]
        public int Product_Id { get; set; }

        [ForeignKey("Order_Id")]
        public int? Order_Id { get; set; } = null;

        public string Product_Name { get; set; }
        public string Product_Img { get; set; }

        public int Quantity { get; set; }
        public float Sum { get; set; }

        public CartItem(int User_Id,int Product_Id, string Product_Name, string Product_Img, int Quantity,float Sum) {
            this.User_Id = User_Id;
            this.Product_Id = Product_Id;
            this.Product_Name = Product_Name;  
            this.Product_Img = Product_Img;
            this.Quantity = Quantity;
            this.Sum = Sum;
        }

    }
}
