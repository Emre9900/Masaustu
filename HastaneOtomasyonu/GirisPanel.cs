using System;
using System.Data.SqlClient;
using System.Drawing; // Tasarım için gerekli
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HastaneOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TasarimUygula(); // Özel tasarımı uygula
        }

        // Senin verdiğin yeni bağlantı adresi
        SqlConnection baglanti = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonuDB;Integrated Security=True;");

        private void TasarimUygula()
        {
            this.Text = "Hastane Giriş Sistemi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White; // Arka plan beyaz

            // Buton 1 (Giriş) Tasarımı
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.FromArgb(41, 128, 185); // Koyu Mavi
            button1.ForeColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button1.Text = "GİRİŞ YAP";
            button1.Cursor = Cursors.Hand;

            // Buton 2 (Kayıt) Tasarımı
            button2.FlatStyle = FlatStyle.Flat;
            button2.BackColor = Color.FromArgb(39, 174, 96); // Yeşil
            button2.ForeColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button2.Text = "KAYIT OL";
            button2.Cursor = Cursors.Hand;

            // TextBox Tasarımları
            textBox1.Font = new Font("Segoe UI", 11);
            textBox2.Font = new Font("Segoe UI", 11);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi=@p1 AND Sifre=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", Sifrele(textBox2.Text));

                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    İslemler islem = new İslemler();
                    islem.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı Hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayıtPanel kpanel = new KayıtPanel();
            kpanel.Show();
            this.Hide();
        }

        private string Sifrele(string veri)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(veri));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes) builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}