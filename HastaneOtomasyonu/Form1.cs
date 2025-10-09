using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneOtomasyonu
{
    public partial class Form1 : Form
    {
        KayıtPanel kayıtPanel = new KayıtPanel();
        public Form1()
        {
            InitializeComponent();
        }
        İslemler islem = new İslemler();
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Emre" && Convert.ToInt16(textBox2.Text) == 1234)
            {
                MessageBox.Show("Giriş başarılı, işlemler sayfasına yönlendiriliyorsunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                islem.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş, şifreniz ya da kullanıcı isminiz hatalı olabilir. Kontrol edin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            kayıtPanel.Show();
            
        }
    }
}
