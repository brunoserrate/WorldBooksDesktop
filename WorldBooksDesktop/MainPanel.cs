using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldBooksDesktop
{
    public partial class MainPanel : Form
    {
        public MainPanel()
        {
            InitializeComponent();
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosPanel usuariosPanel = new UsuariosPanel
            {
                MdiParent = this
            };
            usuariosPanel.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientesPanel clientesPanel = new ClientesPanel
            {
                MdiParent = this
            };
            clientesPanel.Show();
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdutosPanel produtosPanel = new ProdutosPanel
            {
                MdiParent = this
            };
            produtosPanel.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesPanel salesPanel = new SalesPanel
            {
                MdiParent = this
            };
            salesPanel.Show();
        }

        private void consultarVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSalesPanel viewSalesPanel = new ViewSalesPanel
            {
                MdiParent = this
            };
            viewSalesPanel.Show();
        }
    }
}
