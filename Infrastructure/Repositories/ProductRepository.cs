using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
        Product Create(Product newProduct);
        Product Update(Product updatedProduct, int id);
        void Delete(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new List<Product>();

        public Product Create(Product newProduct)
        {
            newProduct.Id = _products.Count + 1;

            _products.Add(newProduct);

            return newProduct;
        }
        public Product? GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                throw new Exception("Product not found!");
            }
            return product;
        }
        public void Delete(int id)
        {
            var product = GetById(id);

            _products.Remove(product!);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product Update(Product updatedProduct, int id)
        {
            var product = GetById(id);
            _products.Remove(product!);

            product!.Name = updatedProduct.Name;
            product!.Description = updatedProduct.Description;

            _products.Add(product);
            return product;
        }
    }
}
