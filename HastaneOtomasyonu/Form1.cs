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

        public Form1()
        {
            InitializeComponent();
        }
        KayıtPanel kayit = new KayıtPanel();
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
                    con.Close();

                }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı, lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kayıt paneline yönlendiriliyorsunuz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            var kayit = new KayıtPanel();
            kayit.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
