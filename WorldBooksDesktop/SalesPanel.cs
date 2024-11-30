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
using System.Diagnostics;

namespace WorldBooksDesktop
{
    public partial class SalesPanel : Form
    {
        private List<SalesItem> salesItems = new List<SalesItem>();
        private List<Product> products = new List<Product>();
        private List<Client> clients = new List<Client>();

        private SaleService saleService = new SaleService();
        private ProductService productService = new ProductService();
        private ClientService clientService = new ClientService();

        private Client client = new Client();

        public SalesPanel()
        {
            InitializeComponent();
        }

        #region Eventos

        private void SalesPanel_Load(object sender, EventArgs e)
        {
            CriarColunasDataGrid();
            CarregarProdutos();
            CarregarClientes();

            operacoesGroup.Visible = false;
            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacaoLabel.Text = "Operações";
            salvarVendaGroupBox.Visible = false;

            DesabilitarCamposEditaveis();
            clientesCombox.Enabled = false;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            decimal unitPrice = (decimal) products.Find(p => p.Id == int.Parse(produtosCombox.SelectedValue.ToString())).Price;
            int quantity = int.Parse(qtdNumeric.Text);
            decimal discount = decimal.Parse(descontoNumeric.Text);
            decimal totalPrice = unitPrice * quantity * (1 - discount/100);

            SalesItem salesItem = new SalesItem()
            {
                Id = 0,
                ProductId = produtosCombox.SelectedValue != null ? int.Parse(produtosCombox.SelectedValue.ToString()) : 0,
                Quantity = int.Parse(qtdNumeric.Text),
                Discount = decimal.Parse(descontoNumeric.Text),
                UnitPrice = unitPrice,
                TotalPrice = totalPrice,
            };

            if (operacaoLabel.Text.Contains("Incluir"))
            {
                salesItems.Add(salesItem);
            }
            else if (operacaoLabel.Text.Contains("Editar"))
            {
                var index = indiceTxtBox.Text;
                var item = salesItems.Find(s => s.Id == int.Parse(index));

                item.ProductId = produtosCombox.SelectedValue != null ? int.Parse(produtosCombox.SelectedValue.ToString()) : 0;
                item.Quantity = int.Parse(qtdNumeric.Text);
                item.Discount = decimal.Parse(descontoNumeric.Text);
                item.UnitPrice = unitPrice;
                item.TotalPrice = totalPrice;
            }

            operacoesGroup.Visible = false;
            LimparCampos();
            CriarColunasDataGrid();
            MostrarItensGrid();

            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacaoLabel.Text = "Operações";
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            operacoesGroup.Visible = false;
            LimparCampos();
            CriarColunasDataGrid();
            MostrarItensGrid();

            operacoesGroup.Visible = false;
            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacaoLabel.Text = "Operações";
        }

        private void incluirBtn_Click(object sender, EventArgs e)
        {
            operacoesGroup.Visible = true;
            LimparCampos();
            operacaoLabel.Text = "Incluir";
            operacaoLabel.BackColor = ProjectColors.ConfirmBackground;

            HabilitarCamposEditaveis();

            if (salesItems.Count <= 0) {
                clientesCombox.SelectedIndex = -1;
                clientesCombox.Enabled = true;
            }
        }

        private void editarBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(indiceTxtBox.Text))
            {
                MessageBox.Show("Selecione um item para editar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var index = int.Parse(indiceTxtBox.Text);
            var item = salesItems.Find(s => s.Id == index);

            produtosCombox.SelectedValue = item.ProductId;
            qtdNumeric.Value = item.Quantity;
            descontoNumeric.Value = item.Discount;

            operacoesGroup.Visible = true;
            operacaoLabel.Text = "Editar";
            operacaoLabel.BackColor = ProjectColors.ConfirmBackground;

            HabilitarCamposEditaveis();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(indiceTxtBox.Text))
            {
                MessageBox.Show("Selecione um item para deletar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var index = int.Parse(indiceTxtBox.Text);

            salesItems.RemoveAll(s => s.Id == index);

            CriarColunasDataGrid();
            MostrarItensGrid();

            operacoesGroup.Visible = false;
            LimparCampos();
            CriarColunasDataGrid();
            MostrarItensGrid();

            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacaoLabel.Text = "Operações";
        }

        private void salesItemDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (operacaoLabel.Text.Contains("Incluir") || operacaoLabel.Text.Contains("Editar") )
            {
                return;
            }

            if (e.RowIndex < 0 || e.RowIndex >= salesItems.Count)
            {
                return;
            }

            indiceTxtBox.Text = salesItems[e.RowIndex].Id.ToString();
            produtosCombox.SelectedValue = salesItems[e.RowIndex].ProductId;
            qtdNumeric.Value = salesItems[e.RowIndex].Quantity;
            string discount = salesItems[e.RowIndex].Discount.ToString().Replace(" %", "");

            descontoNumeric.Value = decimal.Parse(discount);

            operacoesGroup.Visible = true;
            DesabilitarCamposEditaveis();
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientesCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clientesCombox.SelectedIndex < 0 || clientesCombox.SelectedValue == null)
            {
                return;
            }

            if (int.TryParse(clientesCombox.SelectedValue.ToString(), out int clientId))
            {
                client = clients.Find(c => c.Id == clientId);
            }
            else
            {
                return;
            }

            clientesCombox.Enabled = false;
        }

        private void salvarVendaBtn_Click(object sender, EventArgs e)
        {
            if (produtosDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("Adicione produtos a venda", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Sale sale = new Sale()
            {
                Id = 0,
                UserId = Program.LoggedUser.Id,
                ClientId = client.Id,
                TotalAmount = salesItems.Sum(s => s.TotalPrice),
                SaleDate = DateTime.Now,
            };

            var response = saleService.CreateSale(sale, salesItems);

            if (!response.Success)
            {
                MessageBox.Show("Erro ao salvar venda: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Venda salva com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            salesItems.Clear();
            CriarColunasDataGrid();
            MostrarItensGrid();
            salvarVendaGroupBox.Visible = false;
            clientesCombox.Enabled = true;
            clientesCombox.SelectedIndex = -1;
        }
        #endregion

        #region Internals

        private void CarregarProdutos()
        {
            var response = productService.GetActiveProducts();

            if (!response.Success)
            {
                MessageBox.Show("Erro ao buscar produtos: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            products = (List<Product>)response.Data;

            produtosCombox.DataSource = products;
            produtosCombox.DisplayMember = "Name";
            produtosCombox.ValueMember = "Id";

            produtosCombox.SelectedIndex = -1;
        }

        private void CarregarClientes()
        {
            var response = clientService.GetClients();

            if (!response.Success)
            {
                MessageBox.Show("Erro ao buscar clientes: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clients = (List<Client>)response.Data;

            clientesCombox.DataSource = clients;
            clientesCombox.DisplayMember = "Name";
            clientesCombox.ValueMember = "Id";

            clientesCombox.SelectedIndex = -1;
        }

        private void CriarColunasDataGrid()
        {
            produtosDataGridView.Columns.Clear();
            produtosDataGridView.Columns.Add("Indice", "Indice");
            produtosDataGridView.Columns.Add("Produto", "Produto");
            produtosDataGridView.Columns.Add("Quantidade", "Quantidade");
            produtosDataGridView.Columns.Add("Desconto", "Desconto");
            produtosDataGridView.Columns.Add("Preço Unitário", "Preço Unitário");
            produtosDataGridView.Columns.Add("Preço Total", "Preço Total");
        }

        private void MostrarItensGrid()
        {
            produtosDataGridView.Rows.Clear();
            int index = 1;

            foreach (var item in salesItems)
            {
                produtosDataGridView.Rows.Add(
                    index++,
                    products.Find(p => p.Id == item.ProductId).Name,
                    item.Quantity,
                    item.Discount.ToString() + " %",
                    "R$ " + Math.Round(item.UnitPrice, 2).ToString(),
                    "R$ " + Math.Round(item.TotalPrice, 2).ToString()
                );
            }

            if (produtosDataGridView.Rows.Count > 0)
            {
                salvarVendaGroupBox.Visible = true;
            }
            else {
                salvarVendaGroupBox.Visible = false;
                clientesCombox.Enabled = true;
            }
        }

        private void LimparCampos()
        {
            indiceTxtBox.Text = "";
            produtosCombox.SelectedIndex = -1;
            qtdNumeric.Value = 0;
            descontoNumeric.Value = 0;
        }

        private void HabilitarCamposEditaveis()
        {
            produtosCombox.Enabled = true;
            qtdNumeric.Enabled = true;
            descontoNumeric.Enabled = true;
        }

        private void DesabilitarCamposEditaveis()
        {
            produtosCombox.Enabled = false;
            qtdNumeric.Enabled = false;
            descontoNumeric.Enabled = false;
        }
        #endregion
    }
}
