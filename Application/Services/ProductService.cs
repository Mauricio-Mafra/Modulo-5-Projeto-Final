using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public interface IProductService
    {
        List<Product> List();
        Product? GetById(int id);
        Product Create(Product product);
        Product Update(Product product, int id);
        void Delete(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product Create(Product product)
        {
            return _repository.Create(product);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Product? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Product> List()
        {
            return _repository.GetAll();
        }

        public Product Update(Product product, int id)
        {
            return _repository.Update(product, id);
        }
    }
}
