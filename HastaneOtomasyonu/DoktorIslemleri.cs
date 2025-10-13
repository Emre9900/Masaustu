using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonu
{
    public partial class DoktorIslemleri : Form
    {
        public DoktorIslemleri()
        {
            InitializeComponent();

        }
        SqlConnection con = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonu;Integrated Security=True;");
        private void DoktorIslemleri_Load(object sender, EventArgs e)
        {
            tarih_label.Text = DateTime.Now.ToLongDateString();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From HospitalPatients", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            timer1.Interval = 300000;
            timer1.Tick += timer1_Tick;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();


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
                tarih_label.Text = "Günün Tarihi: "+DateTime.Now.ToString()+" "+"Tablonun Son Güncellenme Zamanı:" + DateTime.Now.ToString();
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
