using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DAL.DAO;
using DAL.DTO;
namespace PersonelTakipSistemiAPP
{
    public partial class FrmIzinListesi : Form
    {
        public FrmIzinListesi()
        {
            InitializeComponent();
        }
        IzinDTO dto = new IzinDTO();
        private bool comboFull;

        private void FrmIzinListesi_Load(object sender, EventArgs e)
        {
            doldur();
            if (!UserStatic.isAdmin)
            {
                dto.Izinler = dto.Izinler.Where(x => x.PersonelID == UserStatic.PersonelID).ToList() ;
                pnlForAdmin.Visible = false;
                btnOnayla.Visible = false;
                btnReddet.Visible = false;
                dataGridView1.DataSource = dto.Izinler;
            }
        }
        void doldur()
        {
            dto = IzinBLL.GetAll();
            dataGridView1.DataSource = dto.Izinler;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Kullanıcı No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Başlama Tarihi";
            dataGridView1.Columns[9].HeaderText = "Bitiş Tarihi";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].HeaderText = "Izin Durumu";
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
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
            cmbDurum.DataSource = dto.IzinDurumlar;
            cmbDurum.DisplayMember = "IzinDurumAd";
            cmbDurum.ValueMember = "ID";
            cmbDurum.SelectedIndex = -1;
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmIzinBilgileri frm = new FrmIzinBilgileri();
            this.Hide();
            frm.isUpdate = false;
            frm.ShowDialog();
            this.Visible = true; 
            comboFull = false;
            doldur();
            Temizle();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (detay.IzinID == 0)
            {
                MessageBox.Show("Lütfen izin seçiniz...");
            }
            else if (detay.IzinDurumID == ComboStatic.Onayladı || detay.IzinDurumID ==ComboStatic.Reddedildi)
            {
                MessageBox.Show("Onaylanmış veya reddedilmiş izinler güncellenemez...");
            }
            else
            {
                FrmIzinBilgileri frm = new FrmIzinBilgileri();
                this.Hide();
                frm.isUpdate = true;
                frm.detay = detay;
                frm.ShowDialog();
                this.Visible = true;
                comboFull = false;
                doldur();
                Temizle();
            }    
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
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
        List<IzinDetayDTO> listt = new List<IzinDetayDTO>();
        private void btnAra_Click(object sender, EventArgs e)
        {
            listt = dto.Izinler;
            if (txtKullaniciNo.Text.Trim() != "")
            {
                listt = listt.Where(x => x.KullaniciNo == Convert.ToInt32(txtKullaniciNo.Text)).ToList();
            }
            if (txtAd.Text.Trim() != "")
            {
                listt = listt.Where(x => x.Ad.Contains(txtAd.Text)).ToList();
            }
            if (txtSoyad.Text.Trim() != "")
            {
                listt = listt.Where(x => x.Soyad.Contains(txtSoyad.Text)).ToList();
            }
            if (cmbDepartman.SelectedIndex != -1)
            {
                listt = listt.Where(x => x.DepartmanID == Convert.ToInt32(cmbDepartman.SelectedValue)).ToList();
            }
            if (cmbPozisyon.SelectedIndex != -1)
            {
                listt = listt.Where(x => x.PozisyonID == Convert.ToInt32(cmbPozisyon.SelectedValue)).ToList();
            }
            if (rbBaslamaTarihi.Checked)
            {
                listt = listt.Where(x=> x.BaslamaTarihi >= Convert.ToDateTime(dpBaslama.Value) && x.BaslamaTarihi <= Convert.ToDateTime(dpBitis.Value)).ToList();
            }
            if (rbBitisTarihi.Checked)
            {
                listt = listt.Where(x => x.BitisTarihi >= Convert.ToDateTime(dpBaslama.Value) && x.BitisTarihi <= Convert.ToDateTime(dpBitis.Value)).ToList();
            }
            if (cmbDurum.SelectedIndex != -1)
            {
                listt = listt.Where(x => x.IzinDurumID == Convert.ToInt32(cmbDurum.SelectedValue)).ToList();
            }
            if (txtIzinSuresi.Text.Trim() != "")
            {
                listt = listt.Where(x => x.Sure == Convert.ToInt32(txtIzinSuresi.Text)).ToList();
            }
            dataGridView1.DataSource = listt;
        }
        void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtKullaniciNo.Clear();
            cmbDepartman.SelectedIndex = -1;
            cmbPozisyon.DataSource = dto.Pozisyonlar;
            cmbPozisyon.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Izinler;
            rbBaslamaTarihi.Checked = false;
            rbBitisTarihi.Checked = false;
            txtIzinSuresi.Clear();
            cmbDurum.SelectedIndex = -1;
            dpBaslama.Value = DateTime.Today;
            dpBitis.Value = DateTime.Today;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        IzinDetayDTO detay = new IzinDetayDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.IzinID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[14].Value);
            detay.BaslamaTarihi = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detay.BitisTarihi = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            detay.KullaniciNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detay.Sure = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
            detay.Aciklama = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            detay.IzinDurumID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
        }
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (detay.IzinID == 0)
            {
                MessageBox.Show("Lütfen izin seçiniz.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                IzinBLL.IzinGuncelle(detay.IzinID,ComboStatic.Onayladı);
                MessageBox.Show("Onaylandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                doldur();
            }
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            if (detay.IzinID == 0)
            {
                MessageBox.Show("Lütfen izin seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                IzinBLL.IzinGuncelle(detay.IzinID, ComboStatic.Reddedildi);
                MessageBox.Show("Reddedildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                doldur();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Emin misiniz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (detay.IzinDurumID == ComboStatic.Onayladı || detay.IzinDurumID == ComboStatic.Reddedildi)
                {
                    MessageBox.Show("Onaylanmış veya reddedilmiş izinleri silemezsiniz!","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    IzinBLL.IzinSil(detay.IzinID);
                    MessageBox.Show("Silindi","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    comboFull = false;
                    doldur();
                    Temizle();
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelExport.ExportExcel(dataGridView1);
        }
    }
}
