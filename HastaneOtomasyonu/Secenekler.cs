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
    public partial class KayıtPanel : Form
    {
        public KayıtPanel()
        {
            InitializeComponent();
        }
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonu;Integrated Security=True;");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox3.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }
            else if (radioButton1.Checked == false)
            {
                textBox3.UseSystemPasswordChar = true;
                textBox4.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null && textBox2.Text == null && textBox3.Text == null && textBox4.Text == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Şifreler eşleşmiyor. Lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                con.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE UserName = @username", con);
                checkCmd.Parameters.AddWithValue("@username", textBox1.Text);
                int userExists = (int)checkCmd.ExecuteScalar();

                if (userExists > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten kullanılmaktadır. Lütfen farklı bir kullanıcı adı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Users (UserName, UserPassword, UserRole, UserRegisterDate, UserMailAdress) VALUES (@username, @userpassword, @userrole, @userregisterdate, @usermail)", con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@userpassword", textBox3.Text);
                cmd.Parameters.AddWithValue("@userrole", "User");
                cmd.Parameters.AddWithValue("@userregisterdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@usermail", textBox2.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Başarıyla kayıt gerçekleştirdiniz. Giriş sayfasına yönlendiriliyorsunuz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form1 giris = new Form1();
                    giris.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void KayıtPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
