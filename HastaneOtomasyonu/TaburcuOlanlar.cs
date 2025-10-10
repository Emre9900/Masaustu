using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonu
{
    public partial class TaburcuOlanlar : Form
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonu;Integrated Security=True;");
        public TaburcuOlanlar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();

            hasta_guncelle();

            timer1.Start();
        }

        private void TaburcuOlanlar_Load(object sender, EventArgs e)
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
                SqlDataAdapter da = new SqlDataAdapter("Select * From HospitalPatients Where PatientStatus = 'Sevk' and PatientStatus = 'Nakil'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label2.Text = "Son Güncelleme:" + DateTime.Now.ToString();
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
    }
}
