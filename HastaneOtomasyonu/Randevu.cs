using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace HastaneOtomasyonu
{
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
            TasarimUygula();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonuDB;Integrated Security=True;");

        private void TasarimUygula()
        {
            this.Text = "Randevu Oluştur";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Eğer formda label'lar varsa fontlarını güzelleştir
            foreach (Control c in this.Controls)
            {

                if (c is Button)
                {
                    Button btn = (Button)c;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = Color.FromArgb(230, 126, 34); // Turuncu
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;
                }
                if (c is ComboBox || c is DateTimePicker || c is TextBox)
                {
                    c.Font = new Font("Segoe UI", 10);
                }
            }
        }

        private void Randevu_Load(object sender, EventArgs e)
        {
            PoliklinikleriGetir();
        }

        void PoliklinikleriGetir()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Poliklinikler", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Tasarımda comboBox1 olduğunu varsayıyorum
                // Eğer ComboBox'ın adını değiştirdiysen burayı güncelle
                Control[] combos = this.Controls.Find("comboBox1", true);
                if (combos.Length > 0)
                {
                    ComboBox cmb = (ComboBox)combos[0];
                    cmb.DisplayMember = "PoliklinikAd";
                    cmb.ValueMember = "PoliklinikID";
                    cmb.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Tablo yoksa veya hata olursa kullanıcıyı korkutma, sadece logla veya geç
                // MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
        }

        // Kaydet butonu click eventi (buttonRandevuKaydet varsayımıyla)
        private void buttonRandevuKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Örnek kontrol
                Control[] combos = this.Controls.Find("comboBox1", true);
                string poliklinikAdi = "";
                if (combos.Length > 0) poliklinikAdi = ((ComboBox)combos[0]).Text;

                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO Randevular (Tarih, Poliklinik, Durum) VALUES (@p1, @p2, 'Aktif')", baglanti);

                // dateTimePicker1 kontrolü var mı?
                Control[] pickers = this.Controls.Find("dateTimePicker1", true);
                if (pickers.Length > 0)
                    komut.Parameters.AddWithValue("@p1", ((DateTimePicker)pickers[0]).Value);
                else
                    komut.Parameters.AddWithValue("@p1", DateTime.Now);

                komut.Parameters.AddWithValue("@p2", poliklinikAdi);

                komut.ExecuteNonQuery();
                MessageBox.Show("Randevunuz başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}