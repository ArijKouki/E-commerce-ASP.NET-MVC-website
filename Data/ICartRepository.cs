using project.Data;
using project.Models;

public interface ICartRepository : IRepository<CartItem>
{
    CartItem GetItem(int itemId);
    IEnumerable<CartItem> GetAllItems();
    IEnumerable<CartItem> GetAllItemsInCartByUser(int User_Id);
    void AddItem(CartItem item);
    void RemoveItem(int itemId);
    void UpdateItem(CartItem item);
    
}