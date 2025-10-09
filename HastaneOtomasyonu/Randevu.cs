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
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }

        private void Randevu_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongDateString();
        }
    }
}
