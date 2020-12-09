using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PersAdd
{
    public partial class Delect : Form
    {
        public Delect()
        {
            InitializeComponent();
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                MessageBox.Show("请输入姓名");
            }
            else
            {
                Program.conn.Open();
                DataSet dsMydata = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Program.conn;
                cmd.CommandText = "select 姓名 from Pers where 姓名 ='" + name.Text + "'";

                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("用户不存在");
                    name.Clear();
                    Program.conn.Close();
                   
                }
                else
                {
                    cmd.CommandText = "delete from Pers where 姓名='" + name.Text + "'";
                    cmd.ExecuteNonQuery();
                    Program.conn.Close();
                    MessageBox.Show("删除成功");
                    name.Clear();
                }
            }
        }

        private void Delect_Load(object sender, EventArgs e)
        {

        }
    }
}
