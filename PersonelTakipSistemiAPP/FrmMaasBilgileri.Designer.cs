
namespace PersonelTakipSistemiAPP
{
    partial class FrmMaasBilgileri
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPozisyon = new System.Windows.Forms.Label();
            this.cmbDepartman = new System.Windows.Forms.ComboBox();
            this.cmbPozisyon = new System.Windows.Forms.ComboBox();
            this.lblDepartmanAdi = new System.Windows.Forms.Label();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.txtKullaniciNo = new System.Windows.Forms.TextBox();
            this.lblKullaniciNo = new System.Windows.Forms.Label();
            this.txtMaas = new System.Windows.Forms.TextBox();
            this.lblMaas = new System.Windows.Forms.Label();
            this.txtMaasYil = new System.Windows.Forms.TextBox();
            this.lblMaasYil = new System.Windows.Forms.Label();
            this.lblMaasAy = new System.Windows.Forms.Label();
            this.cmbMaasAy = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(517, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 429);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 273);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblPozisyon);
            this.panel2.Controls.Add(this.cmbDepartman);
            this.panel2.Controls.Add(this.cmbPozisyon);
            this.panel2.Controls.Add(this.lblDepartmanAdi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 156);
            this.panel2.TabIndex = 0;
            // 
            // lblPozisyon
            // 
            this.lblPozisyon.AutoSize = true;
            this.lblPozisyon.Location = new System.Drawing.Point(86, 79);
            this.lblPozisyon.Name = "lblPozisyon";
            this.lblPozisyon.Size = new System.Drawing.Size(80, 20);
            this.lblPozisyon.TabIndex = 29;
            this.lblPozisyon.Text = "Pozisyon";
            // 
            // cmbDepartman
            // 
            this.cmbDepartman.FormattingEnabled = true;
            this.cmbDepartman.Location = new System.Drawing.Point(30, 42);
            this.cmbDepartman.Name = "cmbDepartman";
            this.cmbDepartman.Size = new System.Drawing.Size(186, 28);
            this.cmbDepartman.TabIndex = 0;
            this.cmbDepartman.SelectedIndexChanged += new System.EventHandler(this.cmbDepartman_SelectedIndexChanged);
            // 
            // cmbPozisyon
            // 
            this.cmbPozisyon.FormattingEnabled = true;
            this.cmbPozisyon.Location = new System.Drawing.Point(30, 107);
            this.cmbPozisyon.Name = "cmbPozisyon";
            this.cmbPozisyon.Size = new System.Drawing.Size(186, 28);
            this.cmbPozisyon.TabIndex = 1;
            // 
            // lblDepartmanAdi
            // 
            this.lblDepartmanAdi.AutoSize = true;
            this.lblDepartmanAdi.Location = new System.Drawing.Point(74, 12);
            this.lblDepartmanAdi.Name = "lblDepartmanAdi";
            this.lblDepartmanAdi.Size = new System.Drawing.Size(98, 20);
            this.lblDepartmanAdi.TabIndex = 28;
            this.lblDepartmanAdi.Text = "Departman";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(173, 105);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.ReadOnly = true;
            this.txtSoyad.Size = new System.Drawing.Size(185, 26);
            this.txtSoyad.TabIndex = 22;
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Location = new System.Drawing.Point(23, 103);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(69, 20);
            this.lblSoyad.TabIndex = 25;
            this.lblSoyad.Text = "Soyad :";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(173, 66);
            this.txtAd.Name = "txtAd";
            this.txtAd.ReadOnly = true;
            this.txtAd.Size = new System.Drawing.Size(185, 26);
            this.txtAd.TabIndex = 21;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(23, 69);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(41, 20);
            this.lblAd.TabIndex = 24;
            this.lblAd.Text = "Ad :";
            // 
            // txtKullaniciNo
            // 
            this.txtKullaniciNo.Location = new System.Drawing.Point(173, 27);
            this.txtKullaniciNo.Name = "txtKullaniciNo";
            this.txtKullaniciNo.ReadOnly = true;
            this.txtKullaniciNo.Size = new System.Drawing.Size(185, 26);
            this.txtKullaniciNo.TabIndex = 20;
            // 
            // lblKullaniciNo
            // 
            this.lblKullaniciNo.AutoSize = true;
            this.lblKullaniciNo.Location = new System.Drawing.Point(23, 30);
            this.lblKullaniciNo.Name = "lblKullaniciNo";
            this.lblKullaniciNo.Size = new System.Drawing.Size(112, 20);
            this.lblKullaniciNo.TabIndex = 23;
            this.lblKullaniciNo.Text = "Kullanıcı No :";
            // 
            // txtMaas
            // 
            this.txtMaas.Location = new System.Drawing.Point(173, 146);
            this.txtMaas.Name = "txtMaas";
            this.txtMaas.Size = new System.Drawing.Size(185, 26);
            this.txtMaas.TabIndex = 0;
            // 
            // lblMaas
            // 
            this.lblMaas.AutoSize = true;
            this.lblMaas.Location = new System.Drawing.Point(23, 149);
            this.lblMaas.Name = "lblMaas";
            this.lblMaas.Size = new System.Drawing.Size(62, 20);
            this.lblMaas.TabIndex = 27;
            this.lblMaas.Text = "Maaş :";
            // 
            // txtMaasYil
            // 
            this.txtMaasYil.Location = new System.Drawing.Point(173, 190);
            this.txtMaasYil.Name = "txtMaasYil";
            this.txtMaasYil.Size = new System.Drawing.Size(185, 26);
            this.txtMaasYil.TabIndex = 1;
            // 
            // lblMaasYil
            // 
            this.lblMaasYil.AutoSize = true;
            this.lblMaasYil.Location = new System.Drawing.Point(23, 193);
            this.lblMaasYil.Name = "lblMaasYil";
            this.lblMaasYil.Size = new System.Drawing.Size(87, 20);
            this.lblMaasYil.TabIndex = 29;
            this.lblMaasYil.Text = "Maaş Yıl :";
            // 
            // lblMaasAy
            // 
            this.lblMaasAy.AutoSize = true;
            this.lblMaasAy.Location = new System.Drawing.Point(23, 238);
            this.lblMaasAy.Name = "lblMaasAy";
            this.lblMaasAy.Size = new System.Drawing.Size(87, 20);
            this.lblMaasAy.TabIndex = 31;
            this.lblMaasAy.Text = "Maaş Ay :";
            // 
            // cmbMaasAy
            // 
            this.cmbMaasAy.FormattingEnabled = true;
            this.cmbMaasAy.Location = new System.Drawing.Point(173, 235);
            this.cmbMaasAy.Name = "cmbMaasAy";
            this.cmbMaasAy.Size = new System.Drawing.Size(185, 28);
            this.cmbMaasAy.TabIndex = 2;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(55, 324);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(138, 51);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(220, 324);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(138, 51);
            this.btnKapat.TabIndex = 4;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // FrmMaasBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 429);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblMaasAy);
            this.Controls.Add(this.cmbMaasAy);
            this.Controls.Add(this.txtMaasYil);
            this.Controls.Add(this.lblMaasYil);
            this.Controls.Add(this.txtMaas);
            this.Controls.Add(this.lblMaas);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.lblSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.txtKullaniciNo);
            this.Controls.Add(this.lblKullaniciNo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmMaasBilgileri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maaş Bilgileri";
            this.Load += new System.EventHandler(this.FrmMaasBilgileri_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.TextBox txtKullaniciNo;
        private System.Windows.Forms.Label lblKullaniciNo;
        private System.Windows.Forms.Label lblPozisyon;
        private System.Windows.Forms.ComboBox cmbDepartman;
        private System.Windows.Forms.ComboBox cmbPozisyon;
        private System.Windows.Forms.Label lblDepartmanAdi;
        private System.Windows.Forms.TextBox txtMaas;
        private System.Windows.Forms.Label lblMaas;
        private System.Windows.Forms.TextBox txtMaasYil;
        private System.Windows.Forms.Label lblMaasYil;
        private System.Windows.Forms.Label lblMaasAy;
        private System.Windows.Forms.ComboBox cmbMaasAy;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnKapat;
    }
}