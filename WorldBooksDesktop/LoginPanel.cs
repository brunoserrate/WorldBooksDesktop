using System;
using System.Windows.Forms;
using DotNetEnv;
using MySql.Data.MySqlClient;
using WorldBooksDesktop.Utils;

namespace WorldBooksDesktop
{
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainPanel form2 = new MainPanel();
            form2.ShowDialog();

            this.Close();
        }

        private void LoginPanel_Load(object sender, EventArgs e)
        {
            string connectionString = "";
            try
            {
                Env.Load();

                string host = Environment.GetEnvironmentVariable("DB_HOST");
                string database = Environment.GetEnvironmentVariable("DB_DATABASE");
                string user = Environment.GetEnvironmentVariable("DB_USERNAME");
                string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

                connectionString = $"Server={host};Database={database};User Id={user};Password={password};";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o arquivo .env: {ex.Message}");
            }

            DatabaseConnector.Instance(connectionString);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = loginTxtBox.Text;
            string password = passwordTxtBox.Text;

            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();
            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE username = @username AND password = @password", connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                MessageBox.Show("Login efetuado com sucesso!");
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!");
            }

            DatabaseConnector.Instance("").CloseConnection(connection);

            this.Hide();

            MainPanel form2 = new MainPanel();
            form2.ShowDialog();

            this.Close();
        }
    }
}
