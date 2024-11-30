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

        public Response Create(Product client)
        {
            if (!IsProductValid(client, true))
            {
                return new Response(false, "Campos obrigatórios não preenchidos", null);
            }

            return _repository.Create(client);
        }

        public Response UpdateProduct(Product client)
        {
            if (!IsProductValid(client, false))
            {
                return new Response(false, "Campos obrigatórios não preenchidos", null);
            }

            return _repository.Update(client);
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

        private bool IsProductValid(Product client, bool newProduct)
        {
            return !string.IsNullOrEmpty(client.Name) &&
                !string.IsNullOrEmpty(client.Description) &&
                client.Price > 0;
        }
    }
}
