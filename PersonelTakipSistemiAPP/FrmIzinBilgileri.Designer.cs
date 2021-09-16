
namespace PersonelTakipSistemiAPP
{
    partial class FrmIzinBilgileri
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
            this.txtKullaniciNo = new System.Windows.Forms.TextBox();
            this.lblKullaniciNo = new System.Windows.Forms.Label();
            this.lblIzinBaslamaTarihi = new System.Windows.Forms.Label();
            this.lblIzinBitisTarihi = new System.Windows.Forms.Label();
            this.dpBaslama = new System.Windows.Forms.DateTimePicker();
            this.dpBitis = new System.Windows.Forms.DateTimePicker();
            this.txtIzinSuresi = new System.Windows.Forms.TextBox();
            this.lblIzinSuresi = new System.Windows.Forms.Label();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKullaniciNo
            // 
            this.txtKullaniciNo.Location = new System.Drawing.Point(218, 31);
            this.txtKullaniciNo.Name = "txtKullaniciNo";
            this.txtKullaniciNo.ReadOnly = true;
            this.txtKullaniciNo.Size = new System.Drawing.Size(218, 26);
            this.txtKullaniciNo.TabIndex = 12;
            // 
            // lblKullaniciNo
            // 
            this.lblKullaniciNo.AutoSize = true;
            this.lblKullaniciNo.Location = new System.Drawing.Point(22, 34);
            this.lblKullaniciNo.Name = "lblKullaniciNo";
            this.lblKullaniciNo.Size = new System.Drawing.Size(112, 20);
            this.lblKullaniciNo.TabIndex = 13;
            this.lblKullaniciNo.Text = "Kullanıcı No :";
            // 
            // lblIzinBaslamaTarihi
            // 
            this.lblIzinBaslamaTarihi.AutoSize = true;
            this.lblIzinBaslamaTarihi.Location = new System.Drawing.Point(22, 98);
            this.lblIzinBaslamaTarihi.Name = "lblIzinBaslamaTarihi";
            this.lblIzinBaslamaTarihi.Size = new System.Drawing.Size(171, 20);
            this.lblIzinBaslamaTarihi.TabIndex = 14;
            this.lblIzinBaslamaTarihi.Text = "İzin Başlama Tarihi :";
            // 
            // lblIzinBitisTarihi
            // 
            this.lblIzinBitisTarihi.AutoSize = true;
            this.lblIzinBitisTarihi.Location = new System.Drawing.Point(22, 159);
            this.lblIzinBitisTarihi.Name = "lblIzinBitisTarihi";
            this.lblIzinBitisTarihi.Size = new System.Drawing.Size(137, 20);
            this.lblIzinBitisTarihi.TabIndex = 15;
            this.lblIzinBitisTarihi.Text = "İzin Bitiş Tarihi :";
            // 
            // dpBaslama
            // 
            this.dpBaslama.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dpBaslama.Location = new System.Drawing.Point(218, 94);
            this.dpBaslama.Name = "dpBaslama";
            this.dpBaslama.Size = new System.Drawing.Size(218, 24);
            this.dpBaslama.TabIndex = 0;
            this.dpBaslama.ValueChanged += new System.EventHandler(this.dpBaslama_ValueChanged);
            // 
            // dpBitis
            // 
            this.dpBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dpBitis.Location = new System.Drawing.Point(218, 155);
            this.dpBitis.Name = "dpBitis";
            this.dpBitis.Size = new System.Drawing.Size(218, 24);
            this.dpBitis.TabIndex = 1;
            this.dpBitis.ValueChanged += new System.EventHandler(this.dpBitis_ValueChanged);
            // 
            // txtIzinSuresi
            // 
            this.txtIzinSuresi.Location = new System.Drawing.Point(218, 216);
            this.txtIzinSuresi.Name = "txtIzinSuresi";
            this.txtIzinSuresi.ReadOnly = true;
            this.txtIzinSuresi.Size = new System.Drawing.Size(218, 26);
            this.txtIzinSuresi.TabIndex = 18;
            // 
            // lblIzinSuresi
            // 
            this.lblIzinSuresi.AutoSize = true;
            this.lblIzinSuresi.Location = new System.Drawing.Point(22, 219);
            this.lblIzinSuresi.Name = "lblIzinSuresi";
            this.lblIzinSuresi.Size = new System.Drawing.Size(104, 20);
            this.lblIzinSuresi.TabIndex = 19;
            this.lblIzinSuresi.Text = "İzin Süresi :";
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(22, 278);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(91, 20);
            this.lblAciklama.TabIndex = 20;
            this.lblAciklama.Text = "Açıklama :";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(218, 275);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(218, 128);
            this.txtAciklama.TabIndex = 2;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(218, 420);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(97, 44);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(339, 420);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(97, 44);
            this.btnKapat.TabIndex = 4;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // FrmIzinBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 485);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.txtIzinSuresi);
            this.Controls.Add(this.lblIzinSuresi);
            this.Controls.Add(this.dpBitis);
            this.Controls.Add(this.dpBaslama);
            this.Controls.Add(this.lblIzinBitisTarihi);
            this.Controls.Add(this.lblIzinBaslamaTarihi);
            this.Controls.Add(this.txtKullaniciNo);
            this.Controls.Add(this.lblKullaniciNo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmIzinBilgileri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İzin Bilgileri";
            this.Load += new System.EventHandler(this.FrmIzinBilgileri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKullaniciNo;
        private System.Windows.Forms.Label lblKullaniciNo;
        private System.Windows.Forms.Label lblIzinBaslamaTarihi;
        private System.Windows.Forms.Label lblIzinBitisTarihi;
        private System.Windows.Forms.DateTimePicker dpBaslama;
        private System.Windows.Forms.DateTimePicker dpBitis;
        private System.Windows.Forms.TextBox txtIzinSuresi;
        private System.Windows.Forms.Label lblIzinSuresi;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnKapat;
    }
}