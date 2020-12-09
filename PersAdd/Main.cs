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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"1.jpg");
        }

       

        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Search sea = new Search();
           sea.MdiParent = this;
           sea.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

                 

   
        private void 修改ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Revise rev = new Revise();
            rev.MdiParent = this;
            rev.Show();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.MdiParent = this;
            add.Show();
            
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delect del = new Delect();
            del.MdiParent = this;
            del.Show();
        }

        private void 显示全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Display dis = new Display();
            dis.MdiParent = this;
            dis.Show();
           
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About abo = new About();
            abo.MdiParent = this;
            abo.Show();
           
        }
    }
}
