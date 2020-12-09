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
    public partial class Add : Form
    {

        string demo = "";
        public Add()
        {
            InitializeComponent();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((name.Text.Trim() == string.Empty) || (company.Text.Trim() == string.Empty) || (telphone.Text.Trim() == string.Empty) || (mobphone.Text.Trim() == string.Empty) | (email.Text.Trim() == string.Empty) || (qq.Text.Trim() == string.Empty) || (demo.Trim() == string.Empty))
            {
                MessageBox.Show("请检查信息是否添加完成");
                name.Clear();
                company.Clear();
                telphone.Clear();
                mobphone.Clear();
                email.Clear();
                qq.Clear();
            }
            else
            {
                Program.conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Program.conn;
                cmd.CommandText = "Insert into Pers (姓名,单位,固定电话,手机,EMAIL,QQ,分类)Values('" + name.Text + "','" + company.Text + "','" + telphone.Text + "','" + mobphone.Text + "','" + email.Text + "','" + qq.Text + "','" + demo + "')";
                cmd.ExecuteNonQuery();
                Program.conn.Close();
                MessageBox.Show("添加成功");

            }
        }

        private void chk_changed(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                demo = chk.Text;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

        

        

        

     
   

