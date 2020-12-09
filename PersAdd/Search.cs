using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersAdd
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
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
                cmd.CommandText = "select 姓名 from Pers where 姓名='" + name.Text + "'";
                cmd.ExecuteNonQuery();
                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("用户不存在");
                    name.Clear();
                    Program.conn.Close();
                    return;
                }
                else
                {
                    string search= "select*from Pers where 姓名='" + name.Text + "'";
                    MySqlDataAdapter daSelect = new MySqlDataAdapter(search, Program.conn);
                    DataTable dt = new DataTable();
                    daSelect.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;
                    this.dataGridView1.RowHeadersVisible = true;
                    Program.conn.Close();
                    name.Clear();
                }
            }
        }
        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            company.Clear();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            name.Clear();
        }

        private void btnSearchByCompany_Click(object sender, EventArgs e)
        {
            if (company.Text == "")
            {
                MessageBox.Show("请输入单位名称");
            }
            else
            {
                Program.conn.Open();
                DataSet dsMydata = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Program.conn;
                cmd.CommandText = "select * from Pers where 单位='" + company.Text + "'";
                cmd.ExecuteNonQuery();
                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("用户不存在");
                    name.Clear();
                    Program.conn.Close();
                    return;
                }
                else
                {
                    string search = "select*from Pers where 单位='" + company.Text + "'";
                    MySqlDataAdapter daSelect = new MySqlDataAdapter(search, Program.conn);
                    DataTable dt = new DataTable();
                    daSelect.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;
                    this.dataGridView1.RowHeadersVisible = true;
                    Program.conn.Close();
                    company.Clear();
                }
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
    }
}
