
namespace PersonelTakipSistemiAPP
{
    partial class FrmPozisyonBilgileri
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
            this.txtPozisyonAdi = new System.Windows.Forms.TextBox();
            this.lblPozisyonAdi = new System.Windows.Forms.Label();
            this.cmbDepartman = new System.Windows.Forms.ComboBox();
            this.lblDepartmanAdi = new System.Windows.Forms.Label();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPozisyonAdi
            // 
            this.txtPozisyonAdi.Location = new System.Drawing.Point(184, 26);
            this.txtPozisyonAdi.Name = "txtPozisyonAdi";
            this.txtPozisyonAdi.Size = new System.Drawing.Size(176, 26);
            this.txtPozisyonAdi.TabIndex = 0;
            // 
            // lblPozisyonAdi
            // 
            this.lblPozisyonAdi.AutoSize = true;
            this.lblPozisyonAdi.Location = new System.Drawing.Point(27, 29);
            this.lblPozisyonAdi.Name = "lblPozisyonAdi";
            this.lblPozisyonAdi.Size = new System.Drawing.Size(126, 20);
            this.lblPozisyonAdi.TabIndex = 1;
            this.lblPozisyonAdi.Text = "Pozisyon Adı : ";
            // 
            // cmbDepartman
            // 
            this.cmbDepartman.FormattingEnabled = true;
            this.cmbDepartman.Location = new System.Drawing.Point(184, 71);
            this.cmbDepartman.Name = "cmbDepartman";
            this.cmbDepartman.Size = new System.Drawing.Size(176, 28);
            this.cmbDepartman.TabIndex = 1;
            // 
            // lblDepartmanAdi
            // 
            this.lblDepartmanAdi.AutoSize = true;
            this.lblDepartmanAdi.Location = new System.Drawing.Point(27, 74);
            this.lblDepartmanAdi.Name = "lblDepartmanAdi";
            this.lblDepartmanAdi.Size = new System.Drawing.Size(139, 20);
            this.lblDepartmanAdi.TabIndex = 3;
            this.lblDepartmanAdi.Text = "Departman Adı :";
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(215, 145);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(146, 48);
            this.btnKapat.TabIndex = 3;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(45, 145);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(146, 48);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // FrmPozisyonBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 229);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblDepartmanAdi);
            this.Controls.Add(this.cmbDepartman);
            this.Controls.Add(this.lblPozisyonAdi);
            this.Controls.Add(this.txtPozisyonAdi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmPozisyonBilgileri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pozisyon Bilgileri";
            this.Load += new System.EventHandler(this.FrmPozisyonBilgileri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPozisyonAdi;
        private System.Windows.Forms.Label lblPozisyonAdi;
        private System.Windows.Forms.ComboBox cmbDepartman;
        private System.Windows.Forms.Label lblDepartmanAdi;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnKaydet;
    }
}