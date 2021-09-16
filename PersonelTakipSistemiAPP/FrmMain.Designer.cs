
namespace PersonelTakipSistemiAPP
{
    partial class FrmMain
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
            this.btnPersonelIslemleri = new System.Windows.Forms.Button();
            this.btnIs = new System.Windows.Forms.Button();
            this.btnMaas = new System.Windows.Forms.Button();
            this.btnIzin = new System.Windows.Forms.Button();
            this.btnDepartman = new System.Windows.Forms.Button();
            this.btnPozisyonIslemleri = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPersonelIslemleri
            // 
            this.btnPersonelIslemleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPersonelIslemleri.Image = global::PersonelTakipSistemiAPP.Properties.Resources.MANAGEMENT;
            this.btnPersonelIslemleri.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPersonelIslemleri.Location = new System.Drawing.Point(12, 12);
            this.btnPersonelIslemleri.Name = "btnPersonelIslemleri";
            this.btnPersonelIslemleri.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnPersonelIslemleri.Size = new System.Drawing.Size(127, 124);
            this.btnPersonelIslemleri.TabIndex = 0;
            this.btnPersonelIslemleri.Text = "Personel İşlemleri";
            this.btnPersonelIslemleri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPersonelIslemleri.UseVisualStyleBackColor = false;
            this.btnPersonelIslemleri.Click += new System.EventHandler(this.btnPersonelIslemleri_Click);
            // 
            // btnIs
            // 
            this.btnIs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnIs.Image = global::PersonelTakipSistemiAPP.Properties.Resources.WORKSPACE;
            this.btnIs.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIs.Location = new System.Drawing.Point(158, 12);
            this.btnIs.Name = "btnIs";
            this.btnIs.Padding = new System.Windows.Forms.Padding(0, 10, 0, 15);
            this.btnIs.Size = new System.Drawing.Size(127, 124);
            this.btnIs.TabIndex = 1;
            this.btnIs.Text = "İşler";
            this.btnIs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIs.UseVisualStyleBackColor = false;
            this.btnIs.Click += new System.EventHandler(this.btnIs_Click);
            // 
            // btnMaas
            // 
            this.btnMaas.BackColor = System.Drawing.Color.Lime;
            this.btnMaas.Image = global::PersonelTakipSistemiAPP.Properties.Resources.PAY;
            this.btnMaas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaas.Location = new System.Drawing.Point(310, 12);
            this.btnMaas.Name = "btnMaas";
            this.btnMaas.Padding = new System.Windows.Forms.Padding(0, 10, 0, 15);
            this.btnMaas.Size = new System.Drawing.Size(127, 124);
            this.btnMaas.TabIndex = 2;
            this.btnMaas.Text = "Maaş";
            this.btnMaas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMaas.UseVisualStyleBackColor = false;
            this.btnMaas.Click += new System.EventHandler(this.btnMaas_Click);
            // 
            // btnIzin
            // 
            this.btnIzin.BackColor = System.Drawing.Color.Silver;
            this.btnIzin.Image = global::PersonelTakipSistemiAPP.Properties.Resources.TRAVEL;
            this.btnIzin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIzin.Location = new System.Drawing.Point(12, 160);
            this.btnIzin.Name = "btnIzin";
            this.btnIzin.Padding = new System.Windows.Forms.Padding(0, 10, 0, 15);
            this.btnIzin.Size = new System.Drawing.Size(127, 124);
            this.btnIzin.TabIndex = 3;
            this.btnIzin.Text = "İzin İşlemleri";
            this.btnIzin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIzin.UseVisualStyleBackColor = false;
            this.btnIzin.Click += new System.EventHandler(this.btnIzin_Click);
            // 
            // btnDepartman
            // 
            this.btnDepartman.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnDepartman.Image = global::PersonelTakipSistemiAPP.Properties.Resources.ORGANIZATION;
            this.btnDepartman.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDepartman.Location = new System.Drawing.Point(158, 160);
            this.btnDepartman.Name = "btnDepartman";
            this.btnDepartman.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnDepartman.Size = new System.Drawing.Size(127, 124);
            this.btnDepartman.TabIndex = 4;
            this.btnDepartman.Text = "Departman İşlemleri";
            this.btnDepartman.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDepartman.UseVisualStyleBackColor = false;
            this.btnDepartman.Click += new System.EventHandler(this.btnDepartman_Click);
            // 
            // btnPozisyonIslemleri
            // 
            this.btnPozisyonIslemleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPozisyonIslemleri.Image = global::PersonelTakipSistemiAPP.Properties.Resources.MEDAL1;
            this.btnPozisyonIslemleri.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPozisyonIslemleri.Location = new System.Drawing.Point(310, 160);
            this.btnPozisyonIslemleri.Name = "btnPozisyonIslemleri";
            this.btnPozisyonIslemleri.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnPozisyonIslemleri.Size = new System.Drawing.Size(127, 124);
            this.btnPozisyonIslemleri.TabIndex = 5;
            this.btnPozisyonIslemleri.Text = "Pozisyon İşlemleri";
            this.btnPozisyonIslemleri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPozisyonIslemleri.UseVisualStyleBackColor = false;
            this.btnPozisyonIslemleri.Click += new System.EventHandler(this.btnPozisyonIslemleri_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnCikis.ForeColor = System.Drawing.Color.Black;
            this.btnCikis.Image = global::PersonelTakipSistemiAPP.Properties.Resources.LOGOUT;
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCikis.Location = new System.Drawing.Point(12, 309);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Padding = new System.Windows.Forms.Padding(0, 10, 0, 20);
            this.btnCikis.Size = new System.Drawing.Size(127, 124);
            this.btnCikis.TabIndex = 6;
            this.btnCikis.Text = "Güvenli Çıkış";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Image = global::PersonelTakipSistemiAPP.Properties.Resources.EXIT;
            this.btnExit.Location = new System.Drawing.Point(310, 309);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(0, 10, 0, 20);
            this.btnExit.Size = new System.Drawing.Size(127, 124);
            this.btnExit.TabIndex = 7;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 445);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnPozisyonIslemleri);
            this.Controls.Add(this.btnDepartman);
            this.Controls.Add(this.btnIzin);
            this.Controls.Add(this.btnMaas);
            this.Controls.Add(this.btnIs);
            this.Controls.Add(this.btnPersonelIslemleri);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Takip";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPersonelIslemleri;
        private System.Windows.Forms.Button btnIs;
        private System.Windows.Forms.Button btnMaas;
        private System.Windows.Forms.Button btnIzin;
        private System.Windows.Forms.Button btnDepartman;
        private System.Windows.Forms.Button btnPozisyonIslemleri;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnExit;
    }
}