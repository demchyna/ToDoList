using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ToDoList
{
    static class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ToDoListConnection"].ConnectionString;
        static SqlConnection connection;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using(connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Application.Run(new ToDoListForm());
            }
        }

        public static SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
