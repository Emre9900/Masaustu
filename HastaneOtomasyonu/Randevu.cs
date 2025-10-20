using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace HastaneOtomasyonu
{
    public partial class Randevu : Form
    {

        SqlConnection con = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonu;Integrated Security=True;");
        İslemler ana_sayfa = new İslemler();
        public Randevu()
        {
            InitializeComponent();
        }
        private void Randevu_Load(object sender, EventArgs e)
        {
            guncelleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Seçim yapmadan kayıt oluşturulamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var mesaj = $"İlgili olarak, {monthCalendar1.SelectionStart:yyyy-MM-dd} tarihinde, {comboBox1.Text} Hastanesinde, {comboBox2.Text} Bölümünde, {comboBox3.Text} Doktoruna randevunuz oluşturulacaktır. Onaylıyor musunuz?";
                var kayıt_onay = MessageBox.Show(mesaj, "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (kayıt_onay == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        using (SqlCommand komut = new SqlCommand("INSERT INTO Randevu (Randevu_Hastane, Randevu_Polikinlik, Randevu_Doktor, Randevu_Tarih, Randevu_Saat) VALUES (@hastane, @polikinlik, @doktor, @tarih, @saat)", con))
                        {
                            komut.Parameters.AddWithValue("@hastane", comboBox1.Text);
                            komut.Parameters.AddWithValue("@polikinlik", comboBox2.Text);
                            komut.Parameters.AddWithValue("@doktor", comboBox3.Text);
                            komut.Parameters.AddWithValue("@tarih", monthCalendar1.SelectionStart.ToString("yyyy-MM-dd"));
                            komut.Parameters.AddWithValue("@saat", comboBox4.Text);
                            komut.ExecuteNonQuery();
                        }
                        MessageBox.Show("Randevunuz oluşturulmuştur. Sağlıklı günler dileriz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }
        public void guncelleme()
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT DoktorIsım FROM Doctors", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close(); 

                comboBox3.DataSource = null; 
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "DoktorIsım";
                comboBox3.ValueMember = "DoktorIsım";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktor listesi yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ana_sayfa.Show();
            this.Hide();
        }
    }
}
