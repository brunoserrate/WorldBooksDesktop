using WorldBooksDesktop.Repository;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;

namespace WorldBooksDesktop.Service
{
    internal class ClientService
    {
        private readonly IRepository _repository;

        public ClientService()
        {
            _repository = new ClientRepository();
        }

        public Response Create(Client client)
        {
            if (!IsClientValid(client, true))
            {
                return new Response(false, "Campos obrigatórios não preenchidos", null);
            }

            return _repository.Create(client);
        }

        public Response UpdateClient(Client client)
        {
            if (!IsClientValid(client, false))
            {
                return new Response(false, "Campos obrigatórios não preenchidos", null);
            }

            return _repository.Update(client);
        }

        public Response GetClient(int id)
        {
            return _repository.GetById(id);
        }

        public Response GetClients()
        {
            return _repository.Get();
        }

        public Response DeleteClient(int id)
        {
            return _repository.Delete(id);
        }

        private bool IsClientValid(Client client, bool newClient)
        {
            return !string.IsNullOrEmpty(client.Name) &&
                !string.IsNullOrEmpty(client.Email) &&
                !string.IsNullOrEmpty(client.Address) &&
                !string.IsNullOrEmpty(client.Phone);
        }
    }
}
