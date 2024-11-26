using System;
using DotNetEnv;
using MySql.Data.MySqlClient;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;
using System.Collections.Generic;

namespace WorldBooksDesktop.Repository
{
    public class ClientRepository : IRepository
    {

        public ClientRepository()
        {
            string connectionString = EnvHolder.Instance.ConnectionString;

            DatabaseConnector.Instance(connectionString);

            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand(@"CREATE TABLE IF NOT EXISTS clients (
                    id int NOT NULL AUTO_INCREMENT,
                    name text NOT NULL,
                    email text NOT NULL,
                    phone varchar(15) NOT NULL,
                    address text NOT NULL,
                    is_activated int DEFAULT '1',
                    created_at timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                    updated_at timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                    deleted_at timestamp NULL DEFAULT NULL, PRIMARY KEY (id)
                )", connection);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);
        }

        public Response Create(object obj)
        {
            Client client = (Client)obj;
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("INSERT INTO clients (name, email, phone, address) VALUES (@name, @email, @phone, @address)", connection);
            cmd.Parameters.AddWithValue("@name", client.Name);
            cmd.Parameters.AddWithValue("@email", client.Email);
            cmd.Parameters.AddWithValue("@phone", client.Phone);
            cmd.Parameters.AddWithValue("@address", client.Address);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Cliente Criado com sucesso", client);
        }

        public Response Update(object obj)
        {
            Client client = (Client)obj;
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            var response = GetById(client.Id);

            if (response.Success == false || response.Data == null)
            {
                DatabaseConnector.Instance("").CloseConnection(connection);
                return response;
            }

            Client oldClient = (Client)response.Data;

            if (client.Name == null || client.Name == "")
            {
                client.Name = oldClient.Name;
            }

            if (client.Email == null || client.Email == "")
            {
                client.Email = oldClient.Email;
            }

            if (client.Phone == null || client.Phone == "")
            {
                client.Phone = oldClient.Phone;
            }

            if (client.Address == null || client.Address == "")
            {
                client.Address = oldClient.Address;
            }

            MySqlCommand cmd = new MySqlCommand("UPDATE clients SET name = @name, email = @email, phone = @phone, address = @address WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@name", client.Name);
            cmd.Parameters.AddWithValue("@email", client.Email);
            cmd.Parameters.AddWithValue("@phone", client.Phone);
            cmd.Parameters.AddWithValue("@address", client.Address);
            cmd.Parameters.AddWithValue("@id", client.Id);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Cliente atualizado com sucesso", client);
        }

        public Response Delete(int id)
        {
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            var response = GetById(id);

            if (response.Success == false || response.Data == null)
            {
                DatabaseConnector.Instance("").CloseConnection(connection);
                return response;
            }

            Client client = (Client)response.Data;

            if (client.DeletedAt != null && !client.IsActivated)
            {
                DatabaseConnector.Instance("").CloseConnection(connection);
                return new Response(false, "Cliente já deletado", null);
            }

            MySqlCommand cmd = new MySqlCommand("UPDATE clients SET is_activated = 0, deleted_at = CURRENT_TIMESTAMP WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Cliente deletado com sucesso", null);
        }

        public Response Get()
        {
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM clients", connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Client> clients = new List<Client>();

            while (reader.Read())
            {
                Client client = new Client
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Email = reader.GetString("email"),
                    Phone = reader.GetString("phone"),
                    Address = reader.GetString("address"),
                    IsActivated = reader.GetBoolean("is_activated"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.GetDateTime("updated_at"),
                    DeletedAt = reader.IsDBNull(reader.GetOrdinal("deleted_at")) ? (DateTime?)null : reader.GetDateTime("deleted_at")
                };

                clients.Add(client);
            }

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Clientes listados com sucesso", clients);

        }

        public Response GetById(int id)
        {
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM clients WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                DatabaseConnector.Instance("").CloseConnection(connection);
                return new Response(false, "Cliente não encontrado", null);
            }

            Client client = new Client
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("name"),
                Email = reader.GetString("email"),
                Phone = reader.GetString("phone"),
                Address = reader.GetString("address"),
                IsActivated = reader.GetBoolean("is_activated"),
                CreatedAt = reader.GetDateTime("created_at"),
                UpdatedAt = reader.GetDateTime("updated_at"),
                DeletedAt = reader.IsDBNull(reader.GetOrdinal("deleted_at")) ? (DateTime?)null : reader.GetDateTime("deleted_at")
            };

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Cliente encontrado com sucesso", client);
        }


    }
}
