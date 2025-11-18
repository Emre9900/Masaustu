using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafeOtomasyonu
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        SiparisAl siparisal = new SiparisAl();
        private void button1_Click(object sender, EventArgs e)
        {
            siparisal.Show();
            this.Hide();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }
        public void kontrol()
        {

        }
    }
}
