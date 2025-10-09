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
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonu;Integrated Security=True;");

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From Users Where UserName=@username and UserPassword=@userpassword", con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@userpassword", textBox2.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Hoş geldiniz," + " " + textBox1.Text + " " + "Başarılı bir şekilde giriş yaptınız. İşlemler sayfasına yönlendiriliyorsunuz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                islem.Show();
            }
            else
            {
                MessageBox.Show("Hatalı giriş, şifreniz ya da kullanıcı isminiz hatalı olabilir. Kontrol edin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kayıt paneline yönlendiriliyorsunuz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            kayıtPanel.Show();
        }
    }
}
