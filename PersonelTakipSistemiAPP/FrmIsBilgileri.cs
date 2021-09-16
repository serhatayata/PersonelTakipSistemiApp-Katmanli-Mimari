using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DAL.DTO;
using BLL;
namespace PersonelTakipSistemiAPP
{
    public partial class FrmIsBilgileri : Form
    {
        public FrmIsBilgileri()
        {
            InitializeComponent();
        }
        IsDTO dto = new IsDTO();
        bool comboFull = false;
        public bool isUpdate = false;
        public IsDetayDTO detay = new IsDetayDTO();
        private void FrmIsBilgileri_Load(object sender, EventArgs e)
        {
            cmbIsDurum.Visible = false;
            lblIsDurumu.Visible = false;
            dto = IsBLL.GetAll();
            dataGridView1.DataSource = dto.Personeller;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Kullanıcı No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            cmbDepartman.DataSource = dto.Departmanlar;
            cmbDepartman.DisplayMember = "DepartmanAD";
            cmbDepartman.ValueMember = "ID";
            cmbDepartman.SelectedIndex = -1;
            if (dto.Departmanlar.Count > 0)
            {
                comboFull = true;
            }
            cmbPozisyon.DataSource = dto.Pozisyonlar;
            cmbPozisyon.DisplayMember = "PozisyonAd";
            cmbPozisyon.ValueMember = "ID";
            cmbPozisyon.SelectedIndex = -1;
            dataGridView1.Font = new Font("Arial", 8, FontStyle.Regular);
            if (isUpdate)
            {
                cmbIsDurum.Visible = true;
                lblIsDurumu.Visible = true;
                txtAd.Text = detay.Ad;
                txtSoyad.Text = detay.Soyad;
                txtKullaniciNo.Text = detay.KullaniciNo.ToString();
                txtIcerik.Text = detay.Icerik;
                txtBaslik.Text = detay.Baslik;
                cmbIsDurum.DataSource = dto.Durumlar;
                cmbIsDurum.DisplayMember = "IsDurumAd";
                cmbIsDurum.ValueMember = "ID";
                cmbIsDurum.SelectedValue = detay.IsDurumID;

            }
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        IS_Tablo iss = new IS_Tablo();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (iss.CalisanID == 0)
            {
                MessageBox.Show("Personel Seçiniz.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (txtBaslik.Text.Trim() =="")
            {
                MessageBox.Show("Başlık Boş", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(txtIcerik.Text.Trim()  == "")
            {
                MessageBox.Show("İçerik Boş", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (isUpdate)
                {
                    DialogResult result = MessageBox.Show("Emin misiniz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        IsDetayDTO dtoo = new IsDetayDTO();
                        if (Convert.ToInt32(txtKullaniciNo.Text) != detay.KullaniciNo) //Personel değişti demek
                        {
                            dtoo.PersonelID = iss.CalisanID;
                            dtoo.Baslik = txtBaslik.Text;
                            dtoo.Icerik = txtIcerik.Text;
                            dtoo.IsDurumID = Convert.ToInt32(cmbIsDurum.SelectedValue);
                            dtoo.IsID = detay.IsID;
                            IsBLL.IsGuncelle(dtoo);
                            MessageBox.Show("Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            dtoo.PersonelID = detay.PersonelID;
                            dtoo.Baslik = txtBaslik.Text;
                            dtoo.Icerik = txtIcerik.Text;
                            dtoo.IsDurumID = Convert.ToInt32(cmbIsDurum.SelectedValue);
                            dtoo.IsID = detay.IsID;
                            IsBLL.IsGuncelle(dtoo);
                            MessageBox.Show("Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                else
                {
                    iss.Baslik = txtBaslik.Text;
                    iss.Icerik = txtIcerik.Text;
                    iss.IsDurumID = 1;
                    iss.IsBaslamaTarihi = DateTime.Today;
                    IsBLL.IsEkle(iss);
                    MessageBox.Show("İş Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBaslik.Clear();
                    txtIcerik.Clear();
                }
            }
        }
        private void cmbDepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                int departmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                cmbPozisyon.DataSource = dto.Pozisyonlar.Where(x => x.DepartmanID == departmanID).ToList();
            }
            else
            {

            }
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            iss = new IS_Tablo();
            iss.CalisanID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value); 
            txtKullaniciNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
