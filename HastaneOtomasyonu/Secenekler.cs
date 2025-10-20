using System;
using System.Data;
using System.Data.SqlClient;
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
        }

        SqlConnection con = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=HastaneOtomasyonu;Integrated Security=True;");

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bool showPassword = radioButton1.Checked;
            textBox3.UseSystemPasswordChar = !showPassword;
            textBox4.UseSystemPasswordChar = !showPassword;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
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

                    using (SqlCommand checkCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE UserName = @username OR UserMailAdress = @usermail", con))
                    {
                        checkCmd.Parameters.AddWithValue("@username", textBox1.Text);
                        checkCmd.Parameters.AddWithValue("@usermail", textBox2.Text);
                        int userExists = (int)checkCmd.ExecuteScalar();
                        if (userExists > 0)
                        {
                            MessageBox.Show("Bu kullanıcı adı veya mail adresi zaten kullanılmaktadır. Lütfen farklı bir kullanıcı adı ve mail adresi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string hashedPassword;
                    using (SHA1 sha = new SHA1CryptoServiceProvider())
                    {
                        byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(textBox3.Text));
                        hashedPassword = Convert.ToBase64String(hashBytes);
                    }

                    // Kullanıcıyı ekle
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (UserName, UserPassword, UserRole, UserRegisterDate, UserMailAdress) VALUES (@username, @userpassword, @userrole, @userregisterdate, @usermail)", con))
                    {
                        cmd.Parameters.AddWithValue("@username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@userpassword", hashedPassword);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void KayıtPanel_Load(object sender, EventArgs e) { }
    }
}
