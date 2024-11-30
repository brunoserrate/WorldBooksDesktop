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
        public Response Create(object obj)
        {
            SalesItem salesItem = (SalesItem)obj;
            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();

            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("INSERT INTO sale_items (sale_id, product_id, quantity, discount_amount, unit_price, total_price) VALUES (@sale_id, @product_id, @quantity, @discount_amount, @unit_price, @total_price)", connection);
            cmd.Parameters.AddWithValue("@sale_id", salesItem.SaleId);
            cmd.Parameters.AddWithValue("@product_id", salesItem.ProductId);
            cmd.Parameters.AddWithValue("@quantity", salesItem.Quantity);
            cmd.Parameters.AddWithValue("@discount_amount", salesItem.Discount);
            cmd.Parameters.AddWithValue("@unit_price", salesItem.UnitPrice);
            cmd.Parameters.AddWithValue("@total_price", salesItem.TotalPrice);

            cmd.ExecuteNonQuery();

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
