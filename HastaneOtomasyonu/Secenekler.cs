using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HastaneOtomasyonu
{
    public partial class KayıtPanel : Form
    {
        public KayıtPanel()
        {
            InitializeComponent();
            TasarimUygula();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonuDB;Integrated Security=True;");

        private void TasarimUygula()
        {
            this.Text = "Yeni Kullanıcı Kaydı";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow; // Sadece kapatma tuşu olsun

            // Kayıt Ol Butonu (Varsayalım button1)
            // Form tasarımında butonun adını kontrol et, buttonKayitOl ise onu kullan
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    Button btn = (Button)c;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = Color.FromArgb(52, 152, 219); // Açık Mavi
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;
                }
                if (c is TextBox)
                {
                    ((TextBox)c).Font = new Font("Segoe UI", 10);
                }
            }
        }

        // Form tasarımındaki butona bu olayı bağla (Events -> Click)
        public void buttonKayitOl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                baglanti.Open();

                // Kullanıcı kontrolü
                SqlCommand kontrol = new SqlCommand("SELECT Count(*) FROM Kullanicilar WHERE KullaniciAdi=@p1", baglanti);
                kontrol.Parameters.AddWithValue("@p1", textBox1.Text);
                if (Convert.ToInt32(kontrol.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten alınmış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Kayıt Ekleme
                    SqlCommand ekle = new SqlCommand("INSERT INTO Kullanicilar (KullaniciAdi, Sifre) VALUES (@p1, @p2)", baglanti);
                    ekle.Parameters.AddWithValue("@p1", textBox1.Text);
                    ekle.Parameters.AddWithValue("@p2", Sifrele(textBox3.Text));
                    ekle.ExecuteNonQuery();

                    MessageBox.Show("Kayıt Başarılı! Giriş yapabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GirisPanel frm = new GirisPanel();
                    frm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bool gizle = !radioButton1.Checked;
            textBox3.UseSystemPasswordChar = gizle;
            if (textBox4 != null) textBox4.UseSystemPasswordChar = gizle;
        }

        private string Sifrele(string veri)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(veri));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}