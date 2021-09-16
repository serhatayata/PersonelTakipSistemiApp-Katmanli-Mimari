using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.DTO;
using BLL;
using DAL.DAO;
namespace PersonelTakipSistemiAPP
{
    public partial class FrmIsListesi : Form
    {
        public FrmIsListesi()
        {
            InitializeComponent();
        }
        IsDTO dto = new IsDTO();
        private bool comboFull = false;
        IsDetayDTO detay = new IsDetayDTO();
        private void FrmIsListesi_Load(object sender, EventArgs e)
        {
            Doldur();
            if (!UserStatic.isAdmin)
            {
                btnEkle.Visible = false;
                btnGuncelle.Visible = false;
                btnSil.Visible = false;
                btnOnayla.Location = new Point(302, 27);
                btnKapat.Location = new Point(489, 27);
                pnlForAdmin.Visible = false;
                dto.Isler = dto.Isler.Where(x=> x.PersonelID == UserStatic.PersonelID).ToList();
                btnOnayla.Text = "Tamamla";
                dataGridView1.DataSource = dto.Isler;
            }
        }
        private void Doldur()
        {
            dto = IsBLL.GetAll();
            dataGridView1.DataSource = dto.Isler;
            dataGridView1.Columns[0].HeaderText = "Başlık";
            dataGridView1.Columns[1].HeaderText = "Kullanıcı No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].HeaderText = "Departman";
            dataGridView1.Columns[5].HeaderText = "Pozisyon";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].HeaderText = "Durum";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
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
            //Is durumu ComboBox
            cmbIsDurum.DataSource = dto.Durumlar;
            cmbIsDurum.DisplayMember = "DurumAd";
            cmbIsDurum.ValueMember = "ID";
            cmbIsDurum.SelectedIndex = -1;
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
        List<IsDetayDTO> listt = new List<IsDetayDTO>();
        private void btnAra_Click(object sender, EventArgs e)
        {
            listt = dto.Isler;
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
            if (cmbIsDurum.SelectedIndex != -1)
            {
                listt = listt.Where(x => x.IsDurumID == Convert.ToInt32(cmbIsDurum.SelectedValue)).ToList();
            }
            if (rbBaslamaTarihi.Checked)
            {
                listt = listt.Where(x => x.IsBaslamaTarihi >= Convert.ToDateTime(dpBaslama.Value) && x.IsBaslamaTarihi<Convert.ToDateTime(dpBitis.Value)).ToList();
            }
            if (rbTeslimTarihi.Checked)
            {
                listt = listt.Where(x => x.IsBitisTarihi >= Convert.ToDateTime(dpBaslama.Value) && x.IsBitisTarihi < Convert.ToDateTime(dpBitis.Value)).ToList();
            }
            dataGridView1.DataSource = listt;
        }
        private void txtKullaniciNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmIsBilgileri frm = new FrmIsBilgileri();
            this.Hide();
            frm.isUpdate = false;
            frm.ShowDialog();
            this.Visible = true;
            comboFull = false;
            Doldur();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmIsBilgileri frm = new FrmIsBilgileri();
            this.Hide();
            frm.isUpdate = true;
            frm.detay = detay;
            frm.ShowDialog();
            this.Visible = true;
            comboFull = false;
            Doldur();
            Temizle();
        }
        void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtKullaniciNo.Clear();
            cmbDepartman.SelectedIndex = -1;
            cmbPozisyon.DataSource = dto.Pozisyonlar;
            cmbIsDurum.SelectedIndex = -1;
            cmbPozisyon.SelectedIndex = -1;
            dpBaslama.Value = DateTime.Today;
            dpBitis.Value = DateTime.Today;
            dataGridView1.DataSource = dto.Isler;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();  
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.IsID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            detay.KullaniciNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detay.PersonelID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[14].Value);
            detay.IsDurumID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
            detay.Baslik = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detay.Icerik = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            detay.Ad = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detay.Soyad = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detay.IsBitisTarihi = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            detay.IsBaslamaTarihi = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[11].Value); 
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                IsBLL.IsSil(detay.IsID);
                MessageBox.Show("Silme işlemi gerçekleşti.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboFull = false;
                Doldur();
                Temizle();
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (UserStatic.isAdmin && detay.IsDurumID == OnayStatik.Onaylandi)
            {
                MessageBox.Show("Bu iş onaylandı.","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (UserStatic.isAdmin && detay.IsDurumID == OnayStatik.Personelde && detay.PersonelID != UserStatic.PersonelID)
            {
                MessageBox.Show("Bu iş tamamlanmayı bekliyor.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!UserStatic.isAdmin && detay.IsDurumID == OnayStatik.Tamamlandi)
            {
                MessageBox.Show("Bu iş tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                IsBLL.IsGuncelle(detay.IsID);
                MessageBox.Show("Onaylandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboFull = false;
                Doldur();
                Temizle();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelExport.ExportExcel(dataGridView1);
        }
    }
} 

