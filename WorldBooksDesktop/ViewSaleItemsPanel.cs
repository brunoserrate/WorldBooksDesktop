using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldBooksDesktop.Service;
using WorldBooksDesktop.Models;
using WorldBooksDesktop.Utils;

namespace WorldBooksDesktop
{
    public partial class ViewSaleItemsPanel : Form
    {
        public ViewSaleItemsPanel()
        {
            InitializeComponent();
            CriarColunasDataGrid();
        }

        public void CriarColunasDataGrid()
        {
            saleItensDataGridView.Columns.Clear();
            saleItensDataGridView.Columns.Add("Id", "ID");
            saleItensDataGridView.Columns.Add("SaleId", "ID Venda");
            saleItensDataGridView.Columns.Add("Produto", "Produto");
            saleItensDataGridView.Columns.Add("Quantidade", "Quantidade");
            saleItensDataGridView.Columns.Add("Desconto", "Desconto aplicado (%)");
            saleItensDataGridView.Columns.Add("Preço Unitário", "Preço Unitário");
            saleItensDataGridView.Columns.Add("Preço Total", "Preço Total");
        }

        public void SetSale(Sale sale)
        {
            ClientService clientService = new ClientService();
            Response clientResponse = clientService.GetClient(sale.ClientId);

            if (clientResponse.Success)
            {
                Client client = (Client)clientResponse.Data;
            }

            UserService userService = new UserService();
            Response userResponse = userService.GetUser(sale.UserId);

            if (userResponse.Success)
            {
                User user = (User)userResponse.Data;
            }

            SalesItemService salesItemService = new SalesItemService();
            Response salesItemResponse = salesItemService.GetSalesItemsBySaleId(sale.Id);

            if (!salesItemResponse.Success)
            {
                return;
            }

            List<SalesItem> salesItems = (List<SalesItem>)salesItemResponse.Data;

            ProductService productService = new ProductService();

            foreach (SalesItem salesItem in salesItems)
            {
                Product product = productService.GetProduct(salesItem.ProductId).Data as Product;

                saleItensDataGridView.Rows.Add(
                    salesItem.Id,
                    salesItem.SaleId,
                    product.Id.ToString() + " - " + product.Name.ToString(),
                    salesItem.Quantity,
                    Math.Round(salesItem.Discount, 2).ToString() + " %",
                    "R$ " + Math.Round(salesItem.UnitPrice, 2).ToString(),
                    "R$ " + Math.Round(salesItem.TotalPrice, 2).ToString()
                );

            }
        }
    }
}
