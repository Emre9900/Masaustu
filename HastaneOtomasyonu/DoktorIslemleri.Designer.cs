namespace HastaneOtomasyonu
{
    partial class DoktorIslemleri
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
            this.components = new System.ComponentModel.Container();
            this.tarih_label = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.randevu_listesi_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tarih_label
            // 
            this.tarih_label.AutoSize = true;
            this.tarih_label.Location = new System.Drawing.Point(12, 9);
            this.tarih_label.Name = "tarih_label";
            this.tarih_label.Size = new System.Drawing.Size(70, 13);
            this.tarih_label.TabIndex = 0;
            this.tarih_label.Text = "Tarih / Saat :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(390, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // randevu_listesi_label
            // 
            this.randevu_listesi_label.AutoSize = true;
            this.randevu_listesi_label.Location = new System.Drawing.Point(168, 43);
            this.randevu_listesi_label.Name = "randevu_listesi_label";
            this.randevu_listesi_label.Size = new System.Drawing.Size(83, 13);
            this.randevu_listesi_label.TabIndex = 2;
            this.randevu_listesi_label.Text = "Randevu Listesi";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DoktorIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 450);
            this.Controls.Add(this.randevu_listesi_label);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tarih_label);
            this.Name = "DoktorIslemleri";
            this.Text = "DoktorIslemleri";
            this.Load += new System.EventHandler(this.DoktorIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tarih_label;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label randevu_listesi_label;
        private System.Windows.Forms.Timer timer1;
    }
}