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

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosPanel usuariosPanel = new UsuariosPanel();
            usuariosPanel.MdiParent = this;
            usuariosPanel.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientesPanel clientesPanel = new ClientesPanel();
            clientesPanel.MdiParent = this;
            clientesPanel.Show();
        }
    }
}
