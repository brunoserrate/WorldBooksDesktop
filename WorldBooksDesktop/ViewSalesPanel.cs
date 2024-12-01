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
    public partial class ViewSalesPanel : Form
    {
        private readonly SaleService _saleService = new SaleService();
        private readonly ClientService _clientService = new ClientService();
        private readonly UserService _userService = new UserService();

        public ViewSalesPanel()
        {
            InitializeComponent();
        }

        #region Eventos

        private void ViewSalesPanel_Load(object sender, EventArgs e)
        {
            CriarColunasDataGrid();
            MostrarItensGrid();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pesquisarBtn_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = dtInicioPicker.Value;
            DateTime dataFim = dtFimPicker.Value;

            if (dataInicio > dataFim)
            {
                MessageBox.Show("Data de início não pode ser maior que a data final", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vendasDataGridView.Rows.Clear();

            var response = _saleService.FilterSales(dataInicio, dataFim);

            if (!response.Success)
            {
                MessageBox.Show(response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CriarColunasDataGrid();
            MostrarItensGrid((List<Sale>)response.Data);
        }

        private void vendasDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= vendasDataGridView.Rows.Count - 1)
            {
                return;
            }

            int saleId = (int)vendasDataGridView.Rows[e.RowIndex].Cells[0].Value;

            Sale sale = _saleService.GetSale(saleId).Data as Sale;

            if (sale == null)
            {
                MessageBox.Show("Venda não encontrada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Client client = _clientService.GetClient(sale.ClientId).Data as Client;

            if (client == null)
            {
                MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = _userService.GetUser(sale.UserId).Data as User;

            if (user == null)
            {
                MessageBox.Show("Usuário não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            idTxtBox.Text = sale.Id.ToString();
            clienteTxtBox.Text = client.Name;
            usuarioTxtBox.Text = user.Name;
            dtVendaTxtBox.Text = sale.SaleDate.ToString("dd/MM/yyyy HH:mm:ss");
            vlrTotalTxtBox.Text = "R$ " + sale.TotalAmount.ToString();
        }

        private void visualizarItensBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTxtBox.Text))
            {
                MessageBox.Show("Selecione uma venda", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int saleId = int.Parse(idTxtBox.Text);

            Sale sale = _saleService.GetSale(saleId).Data as Sale;

            if (sale == null)
            {
                MessageBox.Show("Venda não encontrada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ViewSaleItemsPanel viewSaleItemsPanel = new ViewSaleItemsPanel();
            viewSaleItemsPanel.SetSale(sale);
            viewSaleItemsPanel.ShowDialog();
        }
        #endregion

        #region Internals
        private void CriarColunasDataGrid()
        {
            vendasDataGridView.Columns.Clear();
            vendasDataGridView.Columns.Add("Id", "ID");
            vendasDataGridView.Columns.Add("Cliente", "Cliente");
            vendasDataGridView.Columns.Add("Data", "Dt. Venda");
            vendasDataGridView.Columns.Add("Total", "Total");
        }

        private void MostrarItensGrid(List<Sale> sales = null)
        {
            vendasDataGridView.Rows.Clear();
            int index = 1;

            List<Sale> salesIntern = null;

            if (sales == null)
            {
                var response = _saleService.GetSales();

                if (!response.Success)
                {
                    MessageBox.Show(response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                salesIntern = new List<Sale>((List<Sale>)response.Data);
            }
            else {
                salesIntern = new List<Sale>(sales);
            }

            foreach (Sale sale in salesIntern)
            {
                Client client = _clientService.GetClient(sale.ClientId).Data as Client;

                vendasDataGridView.Rows.Add(
                    sale.Id,
                    client.Name,
                    sale.SaleDate.ToString("dd/MM/yyyy"),
                    "R$ " + sale.TotalAmount.ToString()
                );

                index++;
            }


        }
        #endregion
    }
}
