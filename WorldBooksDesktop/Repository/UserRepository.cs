using System;
using DotNetEnv;
using MySql.Data.MySqlClient;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;
using System.Collections.Generic;

namespace WorldBooksDesktop.Repository
{
    public class UserRepository : IRepository
    {
        public UserRepository()
        {
            string connectionString = EnvHolder.Instance.ConnectionString;

            DatabaseConnector.Instance(connectionString);

            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand(@"CREATE TABLE IF NOT EXISTS users (
                    id int NOT NULL AUTO_INCREMENT,
                    name text NOT NULL,
                    username text NOT NULL,
                    email text NOT NULL,
                    password text NOT NULL,
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
            User user = (User) obj;
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("INSERT INTO users (name, username, email, password) VALUES (@name, @username, @email, @password)", connection);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Usuário Criado com sucesso", user);
        }

        public Response Update(object obj)
        {
            User user = (User) obj;
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            string query = "UPDATE users SET name = @name, username = @username, email = @email, password = @password, updated_at = CURRENT_TIMESTAMP WHERE id = @id";

            if (string.IsNullOrEmpty(user.Password))
            {
                query = query.Replace("password = @password,", "");
            }

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@email", user.Email);

            if (!string.IsNullOrEmpty(user.Password))
            {
                cmd.Parameters.AddWithValue("@password", user.Password);
            }

            cmd.Parameters.AddWithValue("@id", user.Id);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Usuário Atualizado com sucesso", user);
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

            if (((User)response.Data).DeletedAt != null)
            {
                DatabaseConnector.Instance("").CloseConnection(connection);
                return new Response(false, "Usuário já deletado", null);
            }

            MySqlCommand cmd = new MySqlCommand("UPDATE users SET deleted_at = CURRENT_TIMESTAMP, is_activated = 0 WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Usuário Deletado com sucesso", null);
        }

        public Response Get()
        {
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users", connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                User user = new User
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Username = reader.GetString("username"),
                    Email = reader.GetString("email"),
                    Password = reader.GetString("password"),
                    IsActivated = reader.GetBoolean("is_activated"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.GetDateTime("updated_at"),
                    DeletedAt = reader.IsDBNull(reader.GetOrdinal("deleted_at")) ? (DateTime?)null : reader.GetDateTime("deleted_at")
                };

                users.Add(user);
            }

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Usuários listados com sucesso", users);
        }

        public Response GetById(int id)
        {
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE id = @id", connection);

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            User user = new User();

            while (reader.Read())
            {
                user = new User
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Username = reader.GetString("username"),
                    Email = reader.GetString("email"),
                    Password = reader.GetString("password"),
                    IsActivated = reader.GetBoolean("is_activated"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.GetDateTime("updated_at"),
                    DeletedAt = reader.GetDateTime("deleted_at")
                };
            }

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Usuário listado com sucesso", user);
        }

    }
}
