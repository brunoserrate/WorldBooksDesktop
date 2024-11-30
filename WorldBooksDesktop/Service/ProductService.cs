using WorldBooksDesktop.Repository;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;

namespace WorldBooksDesktop.Service
{
    internal class ProductService
    {
        private readonly IRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public Response Create(Product product)
        {
            if (!IsProductValid(product, true))
            {
                return new Response(false, "Campos obrigatórios não preenchidos", null);
            }

            return _repository.Create(product);
        }

        public Response UpdateProduct(Product product)
        {
            if (!IsProductValid(product, false))
            {
                return new Response(false, "Campos obrigatórios não preenchidos", null);
            }

            return _repository.Update(product);
        }

        public Response GetProduct(int id)
        {
            return _repository.GetById(id);
        }

        public Response GetProducts()
        {
            return _repository.Get();
        }

        public Response DeleteProduct(int id)
        {
            return _repository.Delete(id);
        }

        private bool IsProductValid(Product product, bool newProduct)
        {
            return !string.IsNullOrEmpty(product.Name) &&
                !string.IsNullOrEmpty(product.Description) &&
                product.Price > 0;
        }
    }
}
