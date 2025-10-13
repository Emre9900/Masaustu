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
        public Randevu()
        {
            InitializeComponent();
            

        }
        private void Randevu_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonu;Integrated Security=True;");
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT DoktorIsim FROM Doctors", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "DoktorIsim";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktor listesi yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (comboBox1.SelectedIndex == -1 && comboBox2.SelectedIndex == -1 && comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Seçim yapmadan kayıt oluşturulamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                DialogResult kayıt_onay;

                kayıt_onay = MessageBox.Show("İlgili olarak," + monthCalendar1.SelectionStart.ToShortDateString() + " tarihinde,." + " " + comboBox1.Text + " " + "Hastanesinde" + " " + comboBox2.Text + " " + "Bölümünde," + " " + comboBox3.Text + " " + "Doktoruna Randevunuz oluşturulacaktır, onaylıyor musunuz?.", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kayıt_onay == DialogResult.Yes)
                {
                    kayıt_onay = MessageBox.Show("İlgili olarak," + monthCalendar1.SelectionStart.ToShortDateString() + " tarihinde,." + " " + comboBox1.Text + " " + "Hastanesinde" + " " + comboBox2.Text + " " + "Bölümünde," + " " + comboBox3.Text + " " + "Doktoruna Randevunuz oluşturulmuştur. Sağlıklı günler dileriz.?.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SqlCommand komut = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();

                    komut = new SqlCommand("INSERT INTO Randevu (Randevu_Hastane, Randevu_Polikinlik, Randevu_Doktor, Randevu_Tarih, Randevu_Saat) VALUES (@hastane, @polikinlik, @doktor, @tarih, @saat)");
                    komut.Parameters.AddWithValue("@hastane", comboBox1.Text);
                    komut.Parameters.AddWithValue("@polikinlik", comboBox2.Text);
                    komut.Parameters.AddWithValue("@doktor", comboBox3.Text);
                    komut.Parameters.AddWithValue("@tarih", monthCalendar1.SelectionStart.ToShortDateString());
                    komut.Parameters.AddWithValue("@saat", comboBox4.Text);
                }
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
