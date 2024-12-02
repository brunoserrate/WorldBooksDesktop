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
    public partial class ClientesPanel : Form
    {
        public ClientesPanel()
        {
            InitializeComponent();
        }

        #region Eventos

        private void ClientesPanel_Load(object sender, EventArgs e)
        {
            CriarColunasDataGrid();
            CarregarDados();

            operacoesGroup.Visible = false;
            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacaoLabel.Text = "Operações";
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Client client = new Client()
            {
                Id = 0,
                Name = nomeTxtBox.Text,
                Phone = telefoneTxtBox.Text,
                Email = emailTxtBox.Text,
                Address = enderecoTxtBox.Text
            };

            if (operacaoLabel.Text.Contains("Incluir"))
            {
                ClientService clientService = new ClientService();
                var response = clientService.Create(client);

                if (!response.Success)
                {
                    MessageBox.Show("Erro ao criar cliente: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(response.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (operacaoLabel.Text.Contains("Editar"))
            {
                client.Id = int.Parse(idTxtBox.Text);

                ClientService clientService = new ClientService();
                var response = clientService.UpdateClient(client);
                if (!response.Success)
                {
                    MessageBox.Show("Erro ao atualizar cliente: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Selecione um cliente para editar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClientService clientService = new ClientService();

            var response = clientService.GetClient(int.Parse(idTxtBox.Text));

            if (!response.Success)
            {
                MessageBox.Show("Erro ao buscar cliente: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = (User)response.Data;

            if (!user.IsActivated) {
                MessageBox.Show("Cliente desativado, não é possível editar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Selecione um cliente para deletar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClientService clientService = new ClientService();

            var responseCheck = clientService.GetClient(int.Parse(idTxtBox.Text));

            if (!responseCheck.Success)
            {
                MessageBox.Show("Erro ao buscar cliente: " + responseCheck.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Client client = (Client)responseCheck.Data;

            if (!client.IsActivated) {
                MessageBox.Show("Cliente já esta desativado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            operacaoLabel.Text = "Deletar";
            operacaoLabel.BackColor = ProjectColors.CancelBackground;

            var response = MessageBox.Show("Deseja realmente deletar o cliente: " + client.Id + " - " + client.Name, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.No)
            {
                operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
                operacaoLabel.Text = "Operações";
                return;
            }

            var userResponse = clientService.DeleteClient(int.Parse(idTxtBox.Text));

            if (!userResponse.Success)
            {
                MessageBox.Show("Erro ao deletar cliente: " + userResponse.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
                operacaoLabel.Text = "Operações";
                return;
            }

            MessageBox.Show(userResponse.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void usuariosDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (operacaoLabel.Text.Contains("Incluir") || operacaoLabel.Text.Contains("Editar") )
            {
                return;
            }

            if (e.RowIndex < 0)
            {
                return;
            }

            operacaoLabel.Text = "Visualizar";
            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacoesGroup.Visible = false;

            idTxtBox.Text = clientesDataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString();
            nomeTxtBox.Text = clientesDataGridView.Rows[e.RowIndex].Cells[1].Value?.ToString();
            telefoneTxtBox.Text = clientesDataGridView.Rows[e.RowIndex].Cells[2].Value?.ToString();
            emailTxtBox.Text = clientesDataGridView.Rows[e.RowIndex].Cells[3].Value?.ToString();
            enderecoTxtBox.Text = clientesDataGridView.Rows[e.RowIndex].Cells[4].Value?.ToString();

            DesabilitarCamposEditaveis();
        }
        #endregion

        #region Internals

        private void CriarColunasDataGrid()
        {
            clientesDataGridView.Columns.Clear();
            clientesDataGridView.Columns.Add("Id", "Id");
            clientesDataGridView.Columns.Add("Name", "Nome");
            clientesDataGridView.Columns.Add("Phone", "Telefone");
            clientesDataGridView.Columns.Add("Email", "Email");
            clientesDataGridView.Columns.Add("Address", "End. Principal");
            clientesDataGridView.Columns.Add("IsActivated", "Ativo");
            clientesDataGridView.Columns.Add("CreatedAt", "Criado em");
            clientesDataGridView.Columns.Add("UpdatedAt", "Atualizado em");
            clientesDataGridView.Columns.Add("DeletedAt", "Deletado em");
        }

        private void CarregarDados()
        {
            ClientService clientService = new ClientService();
            var response = clientService.GetClients();

            if (response.Success)
            {
                List<Client> clients = (List<Client>)response.Data;
                clientesDataGridView.Rows.Clear();
                foreach (Client client in clients)
                {
                    DataGridViewRow row = (DataGridViewRow)clientesDataGridView.Rows[0].Clone();
                    row.Cells[0].Value = client.Id;
                    row.Cells[1].Value = client.Name;
                    row.Cells[2].Value = client.Phone;
                    row.Cells[3].Value = client.Email;
                    row.Cells[4].Value = client.Address;
                    row.Cells[5].Value = client.IsActivated ? "Sim" : "Não";
                    row.Cells[6].Value = client.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");
                    row.Cells[7].Value = client.UpdatedAt.ToString("dd/MM/yyyy HH:mm:ss");
                    row.Cells[8].Value = client.DeletedAt != null ? client.DeletedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : "";

                    clientesDataGridView.Rows.Add(row);
                }
            }
        }

        private void LimparCampos()
        {
            idTxtBox.Text = "";
            nomeTxtBox.Text = "";
            telefoneTxtBox.Text = "";
            emailTxtBox.Text = "";
            enderecoTxtBox.Text = "";
        }

        private void HabilitarCamposEditaveis()
        {
            nomeTxtBox.Enabled = true;
            telefoneTxtBox.Enabled = true;
            emailTxtBox.Enabled = true;
            enderecoTxtBox.Enabled = true;
        }

        private void DesabilitarCamposEditaveis()
        {
            nomeTxtBox.Enabled = false;
            telefoneTxtBox.Enabled = false;
            emailTxtBox.Enabled = false;
            enderecoTxtBox.Enabled = false;
        }
        #endregion
    }
}
