using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                }
            }

        }
    }
}
