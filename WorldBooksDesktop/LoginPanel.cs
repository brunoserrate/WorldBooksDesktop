using System;
using System.Windows.Forms;
using DotNetEnv;
using MySql.Data.MySqlClient;
using WorldBooksDesktop.Models;
using WorldBooksDesktop.Utils;

namespace WorldBooksDesktop
{
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();
        }

        private void LoginPanel_Load(object sender, EventArgs e)
        {
            string connectionString = EnvHolder.Instance.ConnectionString;

            DatabaseConnector.Instance(connectionString);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LogUser();
        }

        private void passwordTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                LogUser();
            }
        }

        private void LogUser()
        {
            string username = loginTxtBox.Text;
            string password = passwordTxtBox.Text;

            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                password = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            MySqlConnection connection = DatabaseConnector.Instance("").GetConnection();
            DatabaseConnector.Instance("").OpenConnection(connection);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE username = @username AND password = @password", connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                MessageBox.Show("Usuário ou senha inválidos!");
                return;
            }

            User user = new User();

            while (reader.Read())
            {
                user.Id = reader.GetInt32("id");
                user.Username = reader.GetString("username");
                user.Password = reader.GetString("password");
                user.Name = reader.GetString("name");
                user.Email = reader.GetString("email");
            }

            Program.SetLoggedUser(user);

            DatabaseConnector.Instance("").CloseConnection(connection);

            this.Hide();

            MainPanel mainPanel = new MainPanel();
            mainPanel.ShowDialog();

            this.Close();
        }

    }
}
