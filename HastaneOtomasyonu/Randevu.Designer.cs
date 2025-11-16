namespace HastaneOtomasyonu
{
    partial class Randevu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saat = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(284, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Branş Listesi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(284, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Muayne Olmak İstediğiniz Hastane:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Muayne Olmak İstediğiniz Doktor:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "- Bursa Şehir Hastanesi",
            "- SBÜ Bursa Yüksek İhtisas Eğitim ve Araştırma Hastanesi",
            "- Çekirge Devlet Hastanesi",
            "- İlker Çelikcan Fizik Tedavi ve Rehabilitasyon Hastanesi",
            "- Ali Osman Sönmez Onkoloji Hastanesi",
            "- Dörtçelik Çocuk Hastalıkları Hastanesi",
            "- Gürsu Cüneyt Yıldız Devlet Hastanesi",
            "- Kestel Devlet Hastanesi",
            "- Dr. Ayten Bozkaya Spastik Çocuklar Hastanesi",
            "- İnegöl Devlet Hastanesi",
            "- Karacabey Devlet Hastanesi",
            "- Mustafakemalpaşa Devlet Hastanesi",
            "- Gemlik Devlet Hastanesi",
            "- İznik Devlet Hastanesi",
            "- Mudanya Devlet Hastanesi",
            "- Harmancık İlçe Devlet Hastanesi",
            "- Büyükorhan İlçe Devlet Hastanesi"});
            this.comboBox1.Location = new System.Drawing.Point(475, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Muayne Olmak İstediğiniz Polikinlik:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "- Kardiyoloji",
            "- Nöroloji",
            "- Göz Hastalıkları",
            "- Genel Cerrahi",
            "- Ortopedi ve Travmatoloji",
            "- Dahiliye (İç Hastalıkları)",
            "- Kadın Hastalıkları ve Doğum",
            "- Çocuk Sağlığı ve Hastalıkları",
            "- Üroloji",
            "- Enfeksiyon Hastalıkları",
            "- Dermatoloji (Cildiye)",
            "- Göğüs Hastalıkları",
            "- Fizik Tedavi ve Rehabilitasyon"});
            this.comboBox2.Location = new System.Drawing.Point(475, 99);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(167, 21);
            this.comboBox2.TabIndex = 8;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(475, 126);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(167, 21);
            this.comboBox3.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(369, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Kayıt Oluştur.";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // saat
            // 
            this.saat.AutoSize = true;
            this.saat.Location = new System.Drawing.Point(284, 159);
            this.saat.Name = "saat";
            this.saat.Size = new System.Drawing.Size(75, 13);
            this.saat.TabIndex = 11;
            this.saat.Text = "Muayne Saati:";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "12:00"});
            this.comboBox4.Location = new System.Drawing.Point(475, 159);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(167, 21);
            this.comboBox4.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(624, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Ana Sayfaya Dön";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Randevu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 379);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.saat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "Randevu";
            this.Text = "Randevu";
            this.Load += new System.EventHandler(this.Randevu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label saat;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button2;
    }
}