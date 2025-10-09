using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonu
{
    public partial class KayıtPanel : Form
    {
        public KayıtPanel()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox3.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }
            else if (radioButton1.Checked == false)
            {
                textBox3.UseSystemPasswordChar = true;
                textBox4.UseSystemPasswordChar = true;
            }
        }
    }
}
