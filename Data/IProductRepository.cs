using project.Models;

namespace project.Data
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> getAllProducts();
        Product getProductById(int id);
        IEnumerable<Product> GetProductByPrice(float price);
        IEnumerable<Product> GetProductByRelease_Date(string date);
        IEnumerable<Product> GetProductByType(string type);
        IEnumerable<Product> GetAlbumByPrice(float price);
        IEnumerable<Product> GetSingleByPrice(float price);
        IEnumerable<Product> GetProductByGenre(string genre);
        IEnumerable<Product> GetProductBySinger(string singer);
        IEnumerable<Product> GetProductByName(string name);
        IEnumerable<Product> SearchByNameSinger(string searchTerm);
        void UpdateProduct(Product product);





    }
}