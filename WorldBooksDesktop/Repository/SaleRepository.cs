using System;
using DotNetEnv;
using MySql.Data.MySqlClient;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;
using System.Collections.Generic;

namespace WorldBooksDesktop.Repository
{
    internal class SaleRepository : IRepository
    {
        public SaleRepository()
        {
            string connectionString = EnvHolder.Instance.ConnectionString;

            DatabaseConnector.Instance(connectionString);

            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand(@"CREATE TABLE IF NOT EXISTS sales (
                    id int NOT NULL AUTO_INCREMENT,
                    client_id int NOT NULL,
                    user_id int NOT NULL,
                    sale_date timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    total_amount decimal(10,2) NOT NULL,
                    created_at timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                    updated_at timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                    PRIMARY KEY (id),
                    FOREIGN KEY (client_id) REFERENCES clients(id),
                    FOREIGN KEY (user_id) REFERENCES users(id)
                )", connection);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);
        }

        public Response Create(object obj)
        {
            Sale sale = (Sale)obj;
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("INSERT INTO sales (client_id, user_id, total_amount) VALUES (@client_id, @user_id, @total_amount)", connection);
            cmd.Parameters.AddWithValue("@client_id", sale.ClientId);
            cmd.Parameters.AddWithValue("@user_id", sale.UserId);
            cmd.Parameters.AddWithValue("@total_amount", sale.TotalAmount);

            cmd.ExecuteNonQuery();

            sale.Id = (int)cmd.LastInsertedId;

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Venda Criada com sucesso", sale);
        }

        public Response Delete(int id)
        {
            return new Response(true, "Vendas não podem ser deletadas!", null);
        }

        public Response Get()
        {
            throw new NotImplementedException();
        }

        public Response GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Response Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
