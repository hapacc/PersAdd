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
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }

        

        private void Display_Load(object sender, EventArgs e)
        {
            Program.conn.Open();
            DataSet dsMyData = new DataSet();
            MySqlDataAdapter daBase= new MySqlDataAdapter("Select *from Pers", Program.conn);
            daBase.Fill(dsMyData, "Inform");
            dataGridView1.DataSource = dsMyData.Tables["Inform"];
            Program.conn.Close();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count - dataGridView1.CurrentCell.RowIndex > 9)
            {
                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.CurrentCell.RowIndex + 9];
            }
            else if (dataGridView1.Rows.Count - dataGridView1.CurrentCell.RowIndex > 1)
            {
                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.Rows.Count - 1];
            }
            else
            {
                MessageBox.Show("当前已是最后一页", "提示");
            }
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex > 8)
            {
                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.CurrentCell.RowIndex - 8];
            }
            else if (dataGridView1.CurrentCell.RowIndex <= 8 && dataGridView1.CurrentCell.RowIndex != 0)
            {
                dataGridView1.CurrentCell = dataGridView1[0, 0];
            }
            else
            {
                MessageBox.Show("当前已是第一页", "提示");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
