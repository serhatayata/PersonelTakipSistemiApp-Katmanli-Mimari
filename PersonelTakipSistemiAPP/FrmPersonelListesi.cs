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
using System.IO;
namespace PersonelTakipSistemiAPP
{
    public partial class FrmPersonelListesi : Form
    {
        public FrmPersonelListesi()
        {
            InitializeComponent();
        }
        PersonelDTO dto = new PersonelDTO();
        PersonelDetayDTO detay = new PersonelDetayDTO();
        bool comboFull = false;
        private void FrmPersonelListesi_Load(object sender, EventArgs e)
        {
            doldur();
        }
        void doldur()
        {
            dto = PersonelBLL.GetAll();
            dataGridView1.DataSource = dto.Personeller;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Kullanıcı No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].HeaderText = "Departman";
            dataGridView1.Columns[5].HeaderText = "Pozisyon";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Maaş";
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
        }
        private void txtKullaniciNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmPersonelBilgileri frm = new FrmPersonelBilgileri();
            frm.isUpdate = false;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            comboFull = false;
            Temizle();
            doldur();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmPersonelBilgileri frm = new FrmPersonelBilgileri();
            frm.isUpdate = true;
            frm.detay = detay;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            comboFull = false;
            Temizle();
            doldur();

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
        List<PersonelDetayDTO> listt = new List<PersonelDetayDTO>();
        private void btnAra_Click(object sender, EventArgs e)
        {
            listt = dto.Personeller;
            if (txtKullaniciNo.Text.Trim() != "")
            {
                listt = listt.Where(x => x.KullaniciNo  == Convert.ToInt32(txtKullaniciNo.Text)).ToList();
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
            dataGridView1.DataSource = dto.Personeller;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.PersonelID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detay.Ad = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detay.Soyad = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detay.KullaniciNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detay.DepartmanID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            detay.PozisyonID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detay.Maas = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detay.Sifre = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            detay.isAdmin = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            detay.Resim = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
            detay.Adres = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            detay.DogumTarihi = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
    }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Emin misiniz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PersonelBLL.PersonelSil(detay.PersonelID);
                string resimYol = Application.StartupPath + "\\resimler\\"+detay.Resim;
                File.Delete(resimYol);
                MessageBox.Show("Personel Silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboFull = false;
                Temizle();
                doldur();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelExport.ExportExcel(dataGridView1);
        }
    }
}
