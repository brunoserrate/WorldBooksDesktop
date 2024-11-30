using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorldBooksDesktop.Service;
using WorldBooksDesktop.Models;
using WorldBooksDesktop.Utils;

namespace WorldBooksDesktop
{
    public partial class ProdutosPanel : Form
    {
        public ProdutosPanel()
        {
            InitializeComponent();
        }

        #region Eventos

        private void ProdutosPanel_Load(object sender, EventArgs e)
        {
            CriarColunasDataGrid();
            CarregarDados();

            operacoesGroup.Visible = false;
            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacaoLabel.Text = "Operações";
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Id = 0,
                Name = nomeTxtBox.Text,
                Description = descricaoTxtBox.Text,
                Price = precoNumeric.Value,
                QuantityStock = (int) qtdEstoqueNumeric.Value
            };

            if (operacaoLabel.Text.Contains("Incluir"))
            {
                ProductService productService = new ProductService();
                var response = productService.Create(product);

                if (!response.Success)
                {
                    MessageBox.Show("Erro ao criar produto: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(response.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (operacaoLabel.Text.Contains("Editar"))
            {
                product.Id = int.Parse(idTxtBox.Text);

                ProductService productService = new ProductService();
                var response = productService.UpdateProduct(product);
                if (!response.Success)
                {
                    MessageBox.Show("Erro ao atualizar produto: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(response.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            operacoesGroup.Visible = false;
            LimparCampos();
            CriarColunasDataGrid();
            CarregarDados();

            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacaoLabel.Text = "Operações";
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            operacoesGroup.Visible = false;
            LimparCampos();
            CriarColunasDataGrid();
            CarregarDados();

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
        }

        private void editarBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(idTxtBox.Text))
            {
                MessageBox.Show("Selecione um produto para editar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProductService productService = new ProductService();

            var response = productService.GetProduct(int.Parse(idTxtBox.Text));

            if (!response.Success)
            {
                MessageBox.Show("Erro ao buscar produto: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product product = (Product)response.Data;

            if (!product.IsActivated) {
                MessageBox.Show("Produto desativado, não é possível editar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            operacoesGroup.Visible = true;
            operacaoLabel.Text = "Editar";
            operacaoLabel.BackColor = ProjectColors.ConfirmBackground;

            HabilitarCamposEditaveis();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTxtBox.Text))
            {
                MessageBox.Show("Selecione um produto para deletar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProductService productService = new ProductService();

            var responseCheck = productService.GetProduct(int.Parse(idTxtBox.Text));

            if (!responseCheck.Success)
            {
                MessageBox.Show("Erro ao buscar produto: " + responseCheck.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product produto = (Product) responseCheck.Data;

            if (!produto.IsActivated) {
                MessageBox.Show("Produto já esta desativado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            operacaoLabel.Text = "Deletar";
            operacaoLabel.BackColor = ProjectColors.CancelBackground;

            var response = MessageBox.Show("Deseja realmente deletar o produto: " + produto.Id + " - " + produto.Name, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.No)
            {
                operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
                operacaoLabel.Text = "Operações";
                return;
            }

            var produtoResponse = productService.DeleteProduct(int.Parse(idTxtBox.Text));

            if (!produtoResponse.Success)
            {
                MessageBox.Show("Erro ao deletar produto: " + produtoResponse.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
                operacaoLabel.Text = "Operações";
                return;
            }

            MessageBox.Show(produtoResponse.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            operacoesGroup.Visible = false;
            LimparCampos();
            CriarColunasDataGrid();
            CarregarDados();

            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacaoLabel.Text = "Operações";

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void produtosDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (operacaoLabel.Text.Contains("Incluir") || operacaoLabel.Text.Contains("Editar") )
            {
                return;
            }

            if (e.RowIndex < 0)
            {
                return;
            }

            var id = produtosDataGridView.Rows[e.RowIndex].Cells[0].Value;

            if (id == null)
            {
                return;
            }

            operacaoLabel.Text = "Visualizar";
            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacoesGroup.Visible = false;

            ProductService productService = new ProductService();

            var response = productService.GetProduct(int.Parse(produtosDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()));
            if (!response.Success)
            {
                MessageBox.Show("Erro ao buscar produto: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product product = (Product) response.Data;

            idTxtBox.Text = product.Id.ToString();
            nomeTxtBox.Text = product.Name;
            descricaoTxtBox.Text = product.Description;
            precoNumeric.Value = product.Price;
            qtdEstoqueNumeric.Value = product.QuantityStock;

            DesabilitarCamposEditaveis();
        }
        #endregion

        #region Internals

        private void CriarColunasDataGrid()
        {
            produtosDataGridView.Columns.Clear();
            produtosDataGridView.Columns.Add("Id", "Id");
            produtosDataGridView.Columns.Add("Name", "Nome");
            produtosDataGridView.Columns.Add("Price", "Preço");
            produtosDataGridView.Columns.Add("QuantityStock", "Qtd. Estoque");
            produtosDataGridView.Columns.Add("IsActivated", "Ativo");
            produtosDataGridView.Columns.Add("CreatedAt", "Criado em");
            produtosDataGridView.Columns.Add("UpdatedAt", "Atualizado em");
            produtosDataGridView.Columns.Add("DeletedAt", "Deletado em");
        }

        private void CarregarDados()
        {
            ProductService productService = new ProductService();
            var response = productService.GetProducts();

            if (response.Success)
            {
                List<Product> products = (List<Product>)response.Data;
                produtosDataGridView.Rows.Clear();
                foreach (Product product in products)
                {
                    DataGridViewRow row = (DataGridViewRow)produtosDataGridView.Rows[0].Clone();
                    row.Cells[0].Value = product.Id;
                    row.Cells[1].Value = product.Name;
                    row.Cells[2].Value = product.Price;
                    row.Cells[3].Value = product.QuantityStock;
                    row.Cells[4].Value = product.IsActivated ? "Sim" : "Não";
                    row.Cells[5].Value = product.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");
                    row.Cells[6].Value = product.UpdatedAt.ToString("dd/MM/yyyy HH:mm:ss");
                    row.Cells[7].Value = product.DeletedAt != null ? product.DeletedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : "";

                    produtosDataGridView.Rows.Add(row);
                }
            }
        }

        private void LimparCampos()
        {
            idTxtBox.Text = "";
            nomeTxtBox.Text = "";
            descricaoTxtBox.Text = "";
            precoNumeric.Value = 0;
            qtdEstoqueNumeric.Value = 0;
        }

        private void HabilitarCamposEditaveis()
        {
            nomeTxtBox.Enabled = true;
            descricaoTxtBox.Enabled = true;
            precoNumeric.Enabled = true;
            qtdEstoqueNumeric.Enabled = true;
        }

        private void DesabilitarCamposEditaveis()
        {
            nomeTxtBox.Enabled = false;
            descricaoTxtBox.Enabled = false;
            precoNumeric.Enabled = false;
            qtdEstoqueNumeric.Enabled = false;
        }
        #endregion
    }
}
