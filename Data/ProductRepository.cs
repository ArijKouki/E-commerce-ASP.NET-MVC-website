using project.Models;
using System.Linq;
using System.Xml.Linq;

namespace project.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ProjectContext context;
        public ProductRepository(ProjectContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProductByGenre(string genre)
        {
            return context.Product.Where(s => s.genre == genre).ToList();

        }

        public Product getProductById(int id)
        {
            return context.Product.Find(id);
        }

        public IEnumerable<Product> GetAlbumByPrice(float price)
        {
            return context.Product.Where(s => s.price <= price).Where(a => a.type == "album").ToList();
        }

        public IEnumerable<Product> getAllProducts()
        {
            return context.Product.ToList();
        }


        public IEnumerable<Product> GetProductByPrice(float price)
        {
            return context.Product.Where(s => s.price <= price).ToList();
        }

        public IEnumerable<Product> GetProductByRelease_Date(string release_date)
        {
            return context.Product.Where(s => s.release_date == release_date).ToList();
        }


     
        public IEnumerable<Product> GetProductByType(string type)
        {
            return context.Product.Where(s => s.type == type).ToList();
        }

        /*public IEnumerable<Product> GetSingleByGenre(string genre)
        {
            return context.Product.Where(a => a.type == "single").Where(s => s.genre == genre).ToList();
        }*/

        public IEnumerable<Product> GetSingleByPrice(float price)
        {
            return context.Product.Where(s => s.price <= price).Where(a => a.type == "single").ToList();
        }

        public IEnumerable<Product> GetProductBySinger(string singer)
        {
            return context.Product.Where(s => s.singer.ToLower()==singer).ToList();
        }
        public IEnumerable<Product> GetProductByName(string name)
        {
            return context.Product.Where(s => s.name.ToLower()== name).ToList();
        }

        public IEnumerable<Product> SearchByNameSinger(string searchTerm)
        {
            return context.Product.Where(s => s.singer.ToLower().Contains(searchTerm.ToLower())
            || s.name.ToLower().Contains(searchTerm.ToLower())
            ).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = context.Product.FirstOrDefault(p => p.Product_Id == product.Product_Id);
            if (existingProduct != null)
            {
                existingProduct.name = product.name;
                existingProduct.release_date = product.release_date;
                existingProduct.description = product.description;
                existingProduct.type = product.type;
                existingProduct.price = product.price;
                existingProduct.singer = product.singer;
                existingProduct.img = product.img;
                existingProduct.genre = product.genre;
                existingProduct.nb_exemplaires = product.nb_exemplaires;
            }
        }
    }
}
