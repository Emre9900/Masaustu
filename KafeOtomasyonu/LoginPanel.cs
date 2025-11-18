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
namespace KafeOtomasyonu
{
    public partial class LoginPanel : Form
    {

        
        DashBoard DashBoard = new DashBoard();
        public LoginPanel()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtKullaniciAdi.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (BackColor == Color.White)
            {
                ForeColor = Color.White;
                BackColor = Color.Black;
                btnGiris.ForeColor = Color.White;
                btnTheme.ForeColor = Color.White;
            }
            else
            {
                ForeColor = Color.Black;
                BackColor = Color.White;
                btnGiris.ForeColor = Color.Black;
                btnTheme.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            string kullanicirole = cmbRoles.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(kullanici) || string.IsNullOrWhiteSpace(sifre) || string.IsNullOrWhiteSpace(kullanicirole))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre alanlarını doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KullaniciDogrula(kullanici, sifre, kullanicirole))
            {
                MessageBox.Show("Giriş başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DashBoard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool KullaniciDogrula(string kullaniciAdi, string sifre, string kullanicirole)
        {
            string connectionString = "Data Source=EMREE\\SQLEXPRESS;Initial Catalog=KafeDataBase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE KullaniciAdi=@adi AND KullaniciSifre=@sifre AND kullanicirole=@role", conn))
            {
                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@role", kullanicirole);
                    cmd.Parameters.AddWithValue("@adi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    int sonuc = (int)cmd.ExecuteScalar();

                    return sonuc > 0;  
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                        "Veritabanı üzerinde işlem yapılırken bir hata oluştu.\n\nDetay: " + ex.Message,
                        "Bağlantı Hatası",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Beklenmeyen bir hata oluştu.\n\nDetay: " + ex.Message,
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }
            }
        }

    }
}

