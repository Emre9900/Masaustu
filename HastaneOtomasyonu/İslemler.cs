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
    public partial class İslemler : Form
    {
        public İslemler()
        {
            InitializeComponent();
        }
        Randevu randevu = new Randevu();
        KalanHastalar kalanHastalar = new KalanHastalar();
        TaburcuOlanlar taburcuolanlar = new TaburcuOlanlar();
        private void button1_Click(object sender, EventArgs e)
        {
           randevu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kalanHastalar.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            taburcuolanlar.Show();
            this.Hide();
        }
    }
}
