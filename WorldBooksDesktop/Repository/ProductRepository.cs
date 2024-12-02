using System;
using DotNetEnv;
using MySql.Data.MySqlClient;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;
using System.Collections.Generic;


namespace WorldBooksDesktop.Repository
{
    internal class ProductRepository : IRepository
    {
        public ProductRepository()
        {
            string connectionString = EnvHolder.Instance.ConnectionString;

            DatabaseConnector.Instance(connectionString);

            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand(@"CREATE TABLE IF NOT EXISTS products (
                    id int NOT NULL AUTO_INCREMENT,
                    name text NOT NULL,
                    description text NOT NULL,
                    price decimal(10,2) NOT NULL,
                    quantity_stock int NOT NULL,
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
            Product product = (Product)obj;
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("INSERT INTO products (name, description, price, quantity_stock) VALUES (@name, @description, @price, @quantity_stock)", connection);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@description", product.Description);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@quantity_stock", product.QuantityStock);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Produto Criado com sucesso", product);
        }

        public Response Update(object obj)
        {
            Product product = (Product)obj;
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("UPDATE products SET name = @name, description = @description, price = @price, quantity_stock = @quantity_stock WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@description", product.Description);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@quantity_stock", product.QuantityStock);
            cmd.Parameters.AddWithValue("@id", product.Id);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Produto Atualizado com sucesso", product);
        }

        public Response Delete(int id)
        {
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("UPDATE products SET is_activated = 0, deleted_at = CURRENT_TIMESTAMP WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Produto Deletado com sucesso", null);
        }

        public Response GetById(int id)
        {
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM products WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            Product product = null;

            if (reader.Read())
            {
                product = new Product
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Description = reader.GetString("description"),
                    Price = reader.GetDecimal("price"),
                    QuantityStock = reader.GetInt32("quantity_stock"),
                    IsActivated = reader.GetBoolean("is_activated"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.GetDateTime("updated_at"),
                    DeletedAt = reader.IsDBNull(reader.GetOrdinal("deleted_at")) ? (DateTime?)null : reader.GetDateTime("deleted_at")
                };
            }

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Produto Encontrado", product);
        }

        public Response Get()
        {
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM products", connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Description = reader.GetString("description"),
                    Price = reader.GetDecimal("price"),
                    QuantityStock = reader.GetInt32("quantity_stock"),
                    IsActivated = reader.GetBoolean("is_activated"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.GetDateTime("updated_at"),
                    DeletedAt = reader.IsDBNull(reader.GetOrdinal("deleted_at")) ? (DateTime?)null : reader.GetDateTime("deleted_at")
                };

                products.Add(product);
            }

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Produtos listados com sucesso", products);
        }

        public Response GetActiveProducts()
        {
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM products WHERE is_activated = 1", connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Description = reader.GetString("description"),
                    Price = reader.GetDecimal("price"),
                    QuantityStock = reader.GetInt32("quantity_stock"),
                    IsActivated = reader.GetBoolean("is_activated"),
                    CreatedAt = reader.GetDateTime("created_at"),
                    UpdatedAt = reader.GetDateTime("updated_at"),
                    DeletedAt = reader.IsDBNull(reader.GetOrdinal("deleted_at")) ? (DateTime?)null : reader.GetDateTime("deleted_at")
                };

                products.Add(product);
            }

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Produtos listados com sucesso", products);
        }
    }
}
