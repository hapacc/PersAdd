using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersAdd
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            
            
        }
        private void lblInfo_Click(object sender, EventArgs e)
        {
    
        }
     

        private void About_Load(object sender, EventArgs e)
        {
               timer1.Start();
               
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblInfo.Left -= 3;
            if (this.lblInfo.Right < 0)
            {
                this.lblInfo.Left = this.Width;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
