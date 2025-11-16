using System;
using System.Drawing;
using System.Windows.Forms;

namespace HastaneOtomasyonu
{
    public partial class İslemler : Form
    {
        public İslemler()
        {
            InitializeComponent();
        }

        private void İslemler_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Hastane Yönetim Sistemi - Ana Panel";


            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = Color.FromArgb(236, 240, 241); 
                }
            }

            TasarimUygula();
        }

        private void TasarimUygula()
        {

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    Button btn = (Button)c;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = Color.FromArgb(44, 62, 80); // Koyu Lacivert
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    btn.Height = 50; // Butonları biraz büyüt
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Randevu frm = new Randevu();
            frm.Show();
        }

        private void İslemler_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            TaburcuOlanlar taburcu = new TaburcuOlanlar();
            taburcu.Show();
            this.Hide();
        }
    }
}