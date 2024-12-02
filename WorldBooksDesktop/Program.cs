using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldBooksDesktop.Models;

namespace WorldBooksDesktop
{
    internal static class Program
    {
        public static User LoggedUser { get; private set; }
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginPanel());
        }

        public static void SetLoggedUser(User user)
        {
            LoggedUser = user;
        }
    }
}
