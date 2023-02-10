using project.Models;
using project.Data;


public class CartRepository : Repository<CartItem>,ICartRepository
{
    private readonly ProjectContext context;

    public CartRepository(ProjectContext context) : base(context)
    {
        this.context = context;
    }
    
    public CartItem GetItem(int itemId)
    {
        return context.CartItem.FirstOrDefault(i => i.Item_Id == itemId);
    }

    public IEnumerable<CartItem> GetAllItems()
    {
        return context.CartItem.ToList();
    }

    public IEnumerable<CartItem> GetAllItemsInCartByUser(int User_Id)
    {
        return context.CartItem.Where(i=> i.User_Id == User_Id && i.Order_Id==null).ToList();
    }
    public void AddItem(CartItem item)
    {
        context.CartItem.Add(item);
    }

    public void RemoveItem(int itemId)
    {
        var item = GetItem(itemId);
        context.CartItem.Remove(item);
    }
   
    public void UpdateItem(CartItem item)
    {
        var existingItem = context.CartItem.FirstOrDefault(i => i.Item_Id == item.Item_Id);
        if (existingItem != null)
        {
            existingItem.Order_Id = item.Order_Id;
            existingItem.Product_Name = item.Product_Name;
            existingItem.Quantity = item.Quantity;
            existingItem.Sum = item.Sum;
        }
    }

    
}
