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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginPanel form1 = new LoginPanel();
            form1.ShowDialog();

            this.Close();
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
