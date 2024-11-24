using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBooksDesktop.Repository;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;

namespace WorldBooksDesktop.Service
{
    public class UserService
    {
        private readonly IRepository _repository;

        public UserService()
        {
            _repository = new UserRepository();
        }

        public Response Create(User user)
        {
            if (!IsUserValid(user, true))
            {
                return new Response(false, "Campos obrigatórios não preenchidos", null);
            }

            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                user.Password = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            return _repository.Create(user);
        }

        public Response UpdateUser(User user)
        {
            if (!IsUserValid(user, false))
            {
                return new Response(false, "Campos obrigatórios não preenchidos", null);
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                user.Password = null;
            }
            else
            {
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                    user.Password = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }
            }

            return _repository.Update(user);
        }

        public Response GetUser(int id)
        {
            return _repository.GetById(id);
        }

        public Response GetUsers()
        {
            return _repository.Get();
        }

        public Response DeleteUser(int id)
        {
            return _repository.Delete(id);
        }

        private bool IsUserValid(User user, bool newUser)
        {
            if (newUser)
            {
                return !string.IsNullOrEmpty(user.Name) &&
                    !string.IsNullOrEmpty(user.Username) &&
                    !string.IsNullOrEmpty(user.Email) &&
                    !string.IsNullOrEmpty(user.Password);
            }

            return !string.IsNullOrEmpty(user.Name) &&
                !string.IsNullOrEmpty(user.Username) &&
                !string.IsNullOrEmpty(user.Email);
        }

    }
}
