using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace HastaneOtomasyonu
{
    public partial class KalanHastalar : Form
    {
        public KalanHastalar()
        {
            InitializeComponent();
        }

        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonu;Integrated Security=True;");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void KalanHastalar_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From HospitalPatients", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            hasta_guncelle();

            timer1.Interval = 300000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        public void hasta_guncelle()
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * From HospitalPatients Where PatientStatus = 'Yatış'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label2.Text = "Son Güncelleme:"+ DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler güncellenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();

            hasta_guncelle();

            timer1.Start();
        }
    }
}
