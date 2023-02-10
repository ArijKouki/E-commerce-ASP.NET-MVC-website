using project.Models;

namespace project.Data
{
    public interface IOrderRepository: IRepository<Order>
    {
        Order GetOrder(int orderId);
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetAllOrdersByUser(int User_Id);
        IEnumerable<Order> GetAllOrdersByDate(string Date);
        void AddOrder(Order order);
        void RemoveOrder(int orderId);
        void UpdateOrder(Order order);
    }
}
