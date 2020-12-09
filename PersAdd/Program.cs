using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersAdd
{
    static class Program
    {
        public static MySqlConnection conn = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connetStr = "server=;port=3306;user=demo;password=;database=demo;";
            conn = new MySqlConnection(connetStr);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
