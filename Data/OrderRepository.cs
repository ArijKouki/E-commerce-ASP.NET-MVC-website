using project.Models;

namespace project.Data
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ProjectContext context;

        public OrderRepository(ProjectContext context) : base(context)
        {
            this.context = context;
        }
        public Order GetOrder(int orderId)
        {
            return context.Order.FirstOrDefault(o => o.Order_Id==orderId);
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return context.Order.ToList();
        }
        public IEnumerable<Order> GetAllOrdersByUser(int User_Id)
        {
            return context.Order.Where(o=> o.User_Id==User_Id).ToList();    
        }
        
        public IEnumerable<Order> GetAllOrdersByDate(string Date)
        {
            return context.Order.Where(o => o.Date == Date).ToList();
        }
        public void AddOrder(Order order)
        {
            context.Order.Add(order);
        }
        public void RemoveOrder(int orderId)
        {
            context.Order.Remove(GetEntity(orderId));
        }
        public void UpdateOrder(Order order)
        {
            var existingOrder = context.Order.FirstOrDefault(o => o.Order_Id == order.Order_Id);
            if (existingOrder != null)
            {
                existingOrder.Date = order.Date;
                existingOrder.Total = order.Total;
            }
        }
    }
}
