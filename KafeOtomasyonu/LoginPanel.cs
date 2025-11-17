using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (txtKullaniciAdi.Text == "Emre" && txtSifre.Text == "1234")
            {
                MessageBox.Show("Giriş Başarılı, Dashboard paneline yönlendiriliyorsunuz. ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DashBoard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı! ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }
    }

