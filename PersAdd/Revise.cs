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
    public partial class Revise : Form
    {

        string demo = "";
        public Revise()
        {
            InitializeComponent();
        }

        private void btnRevise_Click(object sender, EventArgs e)
        {
            if ((name.Text.Trim() == string.Empty) || (company.Text.Trim() == string.Empty) || (telphone.Text.Trim() == string.Empty) || (mobphone.Text.Trim() == string.Empty) | (email.Text.Trim() == string.Empty) || (qq.Text.Trim() == string.Empty) || (demo.Trim() == string.Empty))
            {
                MessageBox.Show("请检查信息是否填写完成");
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
                DataSet dsMydata= new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Program.conn;
                cmd.CommandText = "select *from Pers where [姓名]='" + name.Text + "'";
                cmd.ExecuteNonQuery();
                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("用户不存在");
                    name.Clear();
                    company.Clear();
                    telphone.Clear();
                    mobphone.Clear();
                    email.Clear();
                    qq.Clear();
                    Program.conn.Close();
                    return;
                }
                else
                {
                    cmd.CommandText = "update Pers set 姓名='" + name.Text + "'," + "单位='" + company.Text + "'," + "固定电话='" + telphone.Text + "'," + "手机='" + mobphone.Text + "'," + "EMAIL='" + email.Text + "'," + "QQ='" + qq.Text + "'," + "分类='" + demo + "'where 姓名='" + name.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功");     
                    Program.conn.Close();
                    name.Clear();
                    company.Clear();
                    telphone.Clear();
                    mobphone.Clear();
                    email.Clear();
                    qq.Clear();
                }
            }
        }

        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                demo = chk.Text;
            }
                
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            name.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["姓名"].Value.ToString();
            company.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["单位"].Value.ToString();
            telphone.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["固定电话"].Value.ToString();
            mobphone.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["手机"].Value.ToString();
            email.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["EMAIL"].Value.ToString();
            qq.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["QQ"].Value.ToString();
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            Program.conn.Open();
            string search = "select*from Pers where 姓名='" + name.Text + "'";
            MySqlDataAdapter daSelect = new MySqlDataAdapter(search, Program.conn);
            DataTable dt = new DataTable();
            daSelect.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            this.dataGridView1.RowHeadersVisible = true;
            Program.conn.Close();
            
        }
     }
 }

