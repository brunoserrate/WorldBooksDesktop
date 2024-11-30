using System;
using DotNetEnv;
using MySql.Data.MySqlClient;
using WorldBooksDesktop.Utils;
using WorldBooksDesktop.Models;
using System.Collections.Generic;

namespace WorldBooksDesktop.Repository
{
    internal class SalesItemRepository : IRepository
    {
        public SalesItemRepository()
        {
            string connectionString = EnvHolder.Instance.ConnectionString;

            DatabaseConnector.Instance(connectionString);

            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand(@"CREATE TABLE IF NOT EXISTS sale_items (
                    id int NOT NULL AUTO_INCREMENT,
                    sale_id int NOT NULL,
                    product_id int NOT NULL,
                    quantity int NOT NULL,
                    discount_amount decimal(5,2) NOT NULL,
                    unit_price decimal(10,2) NOT NULL,
                    total_price decimal(10,2) NOT NULL,
                    PRIMARY KEY (id),
                    FOREIGN KEY (sale_id) REFERENCES sales(id),
                    FOREIGN KEY (product_id) REFERENCES products(id)
                )", connection);

            cmd.ExecuteNonQuery();

            DatabaseConnector.Instance("").CloseConnection(connection);
        }

        public Response Create(object obj)
        {
            SalesItem salesItem = (SalesItem)obj;

            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("INSERT INTO sale_items (sale_id, product_id, quantity, discount_amount, unit_price, total_price) VALUES (@sale_id, @product_id, @quantity, @discount_amount, @unit_price, @total_price)", connection);
            cmd.Parameters.AddWithValue("@sale_id", salesItem.SaleId);
            cmd.Parameters.AddWithValue("@product_id", salesItem.ProductId);
            cmd.Parameters.AddWithValue("@quantity", salesItem.Quantity);
            cmd.Parameters.AddWithValue("@discount_amount", Math.Round(salesItem.Discount, 2));
            cmd.Parameters.AddWithValue("@unit_price", Math.Round(salesItem.UnitPrice, 2));
            cmd.Parameters.AddWithValue("@total_price", Math.Round(salesItem.TotalPrice, 2));

            cmd.ExecuteNonQuery();

            salesItem.Id = (int)cmd.LastInsertedId;

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Item de venda criado com sucesso", salesItem);
        }

        public Response Delete(int id)
        {
            return new Response(true, "Itens de venda não podem ser deletados!", null);
        }

        public Response Get()
        {
            throw new NotImplementedException();
        }

        public Response GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Response GetBySalesId(int salesId)
        {
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();
            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sale_items WHERE sale_id = @sale_id", connection);
            cmd.Parameters.AddWithValue("@sale_id", salesId);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<SalesItem> salesItems = new List<SalesItem>();

            while (dataReader.Read())
            {
                SalesItem salesItem = new SalesItem
                {
                    Id = dataReader.GetInt32("id"),
                    SaleId = dataReader.GetInt32("sale_id"),
                    ProductId = dataReader.GetInt32("product_id"),
                    Quantity = dataReader.GetInt32("quantity"),
                    Discount = dataReader.GetInt32("discount_amount"),
                    UnitPrice = dataReader.GetDecimal("unit_price"),
                    TotalPrice = dataReader.GetDecimal("total_price")
                };

                salesItems.Add(salesItem);
            }

            DatabaseConnector.Instance("").CloseConnection(connection);

            return new Response(true, "Itens de venda retornados com sucesso", salesItems);
        }

        public Response Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
