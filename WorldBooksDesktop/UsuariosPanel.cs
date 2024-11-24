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
    public partial class UsuariosPanel : Form
    {
        public UsuariosPanel()
        {
            InitializeComponent();
        }

        #region Eventos

        private void UsuariosPanel_Load(object sender, EventArgs e)
        {
            CriarColunasDataGrid();
            CarregarDados();

            operacoesGroup.Visible = false;
            operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
            operacaoLabel.Text = "Operações";
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Id = 0,
                Name = nomeTxtBox.Text,
                Username = usuarioTxtBox.Text,
                Email = emailTxtBox.Text,
                Password = senhaTxtBox.Text
            };

            if (operacaoLabel.Text.Contains("Incluir"))
            {
                UserService userService = new UserService();
                var response = userService.Create(user);

                if (!response.Success)
                {
                    MessageBox.Show("Erro ao criar usuário: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(response.Message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (operacaoLabel.Text.Contains("Editar"))
            {
                user.Id = int.Parse(idTxtBox.Text);

                UserService userService = new UserService();
                var response = userService.UpdateUser(user);
                if (!response.Success)
                {
                    MessageBox.Show("Erro ao atualizar usuário: " + response.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            operacoesGroup.Visible = true;
            operacaoLabel.Text = "Editar";
            operacaoLabel.BackColor = ProjectColors.ConfirmBackground;

            HabilitarCamposEditaveis();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTxtBox.Text))
            {
                MessageBox.Show("Selecione um usuário para deletar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            operacaoLabel.Text = "Deletar";
            operacaoLabel.BackColor = ProjectColors.CancelBackground;

            User user = new User()
            {
                Id = int.Parse(idTxtBox.Text),
                Name = nomeTxtBox.Text,
                Username = usuarioTxtBox.Text,
                Email = emailTxtBox.Text,
                Password = senhaTxtBox.Text
            };

            var response = MessageBox.Show("Deseja realmente deletar o usuário: " + user.Id + " - " + user.Name, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.No)
            {
                operacaoLabel.BackColor = ProjectColors.PrimaryBackground;
                operacaoLabel.Text = "Operações";
                return;
            }

            UserService userService = new UserService();
            var userResponse = userService.DeleteUser(int.Parse(idTxtBox.Text));

            if (!userResponse.Success)
            {
                MessageBox.Show("Erro ao deletar usuário: " + userResponse.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            idTxtBox.Text = usuariosDataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString();
            nomeTxtBox.Text = usuariosDataGridView.Rows[e.RowIndex].Cells[1].Value?.ToString();
            usuarioTxtBox.Text = usuariosDataGridView.Rows[e.RowIndex].Cells[2].Value?.ToString();
            emailTxtBox.Text = usuariosDataGridView.Rows[e.RowIndex].Cells[3].Value?.ToString();

            DesabilitarCamposEditaveis();
        }
        #endregion

        #region Internals

        private void CriarColunasDataGrid()
        {
            usuariosDataGridView.Columns.Clear();
            usuariosDataGridView.Columns.Add("Id", "Id");
            usuariosDataGridView.Columns.Add("Name", "Nome");
            usuariosDataGridView.Columns.Add("Username", "Usuário");
            usuariosDataGridView.Columns.Add("Email", "Email");
            usuariosDataGridView.Columns.Add("IsActivated", "Ativo");
            usuariosDataGridView.Columns.Add("CreatedAt", "Criado em");
            usuariosDataGridView.Columns.Add("UpdatedAt", "Atualizado em");
            usuariosDataGridView.Columns.Add("DeletedAt", "Deletado em");
        }

        private void CarregarDados()
        {
            UserService userService = new UserService();
            var response = userService.GetUsers();
            if (response.Success)
            {
                var users = (List<User>)response.Data;
                usuariosDataGridView.Rows.Clear();
                foreach (var user in users)
                {
                    DataGridViewRow row = (DataGridViewRow)usuariosDataGridView.Rows[0].Clone();
                    row.Cells[0].Value = user.Id;
                    row.Cells[1].Value = user.Name;
                    row.Cells[2].Value = user.Username;
                    row.Cells[3].Value = user.Email;
                    row.Cells[4].Value = user.IsActivated ? "Sim" : "Não";
                    row.Cells[5].Value = user.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");
                    row.Cells[6].Value = user.UpdatedAt.ToString("dd/MM/yyyy HH:mm:ss");
                    row.Cells[7].Value = user.DeletedAt != null ? user.DeletedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : "";

                    usuariosDataGridView.Rows.Add(row);
                }
            }
        }

        private void LimparCampos()
        {
            idTxtBox.Text = "";
            nomeTxtBox.Text = "";
            usuarioTxtBox.Text = "";
            emailTxtBox.Text = "";
            senhaTxtBox.Text = "";
        }

        private void HabilitarCamposEditaveis()
        {
            nomeTxtBox.Enabled = true;
            usuarioTxtBox.Enabled = true;
            emailTxtBox.Enabled = true;
            senhaTxtBox.Enabled = true;
        }

        private void DesabilitarCamposEditaveis()
        {
            nomeTxtBox.Enabled = false;
            usuarioTxtBox.Enabled = false;
            emailTxtBox.Enabled = false;
            senhaTxtBox.Enabled = false;
        }
        #endregion
    }
}
