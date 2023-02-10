using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_Id { get; set; }

        [ForeignKey("User_Id")]
        public int User_Id { get; set; }


        public string Date { get; set; }
        public float Total { get; set; }

        public Order(int User_Id, float Total) {

            this.User_Id = User_Id;
            this.Total = Total;
            DateTime currentDate = DateTime.Now;
            this.Date = currentDate.ToString("yyyy-MM-dd HH:mm:ss");

        }
    }
}
