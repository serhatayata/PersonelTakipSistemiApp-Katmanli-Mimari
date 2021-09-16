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
using BLL;
using DAL.DAO;
using DAL.DTO;
namespace PersonelTakipSistemiAPP
{
    public partial class FrmMaasListesi : Form
    {
        public FrmMaasListesi()
        {
            InitializeComponent();
        }
        MaasDTO dto = new MaasDTO();
        private bool comboFull = false;
        MaasDetayDTO detay = new MaasDetayDTO();
        private void FrmMaasListesi_Load(object sender, EventArgs e)
        {
            doldur();
            if (!UserStatic.isAdmin)
            {
                btnEkle.Visible = false;
                btnGuncelle.Visible = false;
                btnSil.Visible = false;
                pnlForAdmin.Visible = false;
                btnKapat.Location = new Point(358, 26);
                dto.Maaslar = dto.Maaslar.Where(x=>x.PersonelID == UserStatic.PersonelID).ToList();
                dataGridView1.DataSource = dto.Maaslar;
            }
        }
        void doldur()
        {
            dto = MaasBLL.GetAll();
            dataGridView1.DataSource = dto.Maaslar;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Kullanıcı No";
            dataGridView1.Columns[3].HeaderText = "Ad";
            dataGridView1.Columns[4].HeaderText = "Soyad";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].HeaderText = "Yıl";
            dataGridView1.Columns[10].HeaderText = "Ay";
            dataGridView1.Columns[11].HeaderText = "Maaş";
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
            cmbMaasAy.DataSource = dto.Aylar;
            cmbMaasAy.DisplayMember = "Ay";
            cmbMaasAy.ValueMember = "ID";
            cmbMaasAy.SelectedIndex = -1;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmMaasBilgileri frm = new FrmMaasBilgileri();
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
            FrmMaasBilgileri frm = new FrmMaasBilgileri();
            this.Hide();
            frm.isUpdate = true;
            frm.detay = detay;
            frm.ShowDialog();
            this.Visible = true;
            comboFull = false;
            doldur();
            Temizle();
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
        List<MaasDetayDTO> listt = new List<MaasDetayDTO>();
        private void btnAra_Click(object sender, EventArgs e)
        {
            listt = dto.Maaslar;
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
            if (cmbMaasAy.SelectedIndex != -1)
            {
                listt = listt.Where(x => x.MaasAyID == Convert.ToInt32(cmbMaasAy.SelectedValue)).ToList();
            }
            if (txtMaasYil.Text != "")
            {
                listt = listt.Where(x => x.PozisyonID == Convert.ToInt32(txtMaasYil.Text)).ToList();
            }
            if (rbBuyuk.Checked)
            {
                listt = listt.Where(x => x.MaasMiktar > Convert.ToInt32(txtMaas.Text)).ToList();
            }
            else if (rbEsit.Checked)
            {
                listt = listt.Where(x => x.MaasMiktar == Convert.ToInt32(txtMaas.Text)).ToList();
            }
            else if (rbKucuk.Checked)
            {
                listt = listt.Where(x => x.MaasMiktar < Convert.ToInt32(txtMaas.Text)).ToList();
            }
            else
            {

            }
            dataGridView1.DataSource = listt;
        }
        void Temizle()
        {
            dataGridView1.DataSource = dto.Maaslar;
            txtAd.Clear();
            txtSoyad.Clear();
            txtKullaniciNo.Clear();
            txtMaas.Clear();
            txtMaasYil.Clear();
            cmbMaasAy.SelectedIndex = -1;
            cmbDepartman.SelectedIndex = -1;
            cmbPozisyon.DataSource = dto.Pozisyonlar;
            cmbPozisyon.SelectedIndex = -1;
            rbBuyuk.Checked = false;
            rbEsit.Checked = false;
            rbKucuk.Checked = false;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.MaasID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            detay.PersonelID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detay.MaasAyID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
            detay.MaasYil = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            detay.KullaniciNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detay.Ad = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detay.Soyad = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detay.MaasMiktar = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Emin misiniz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MaasBLL.MaasSil(detay.MaasID);
                MessageBox.Show("Silindi.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboFull = false;
                doldur();
                Temizle();
            }
            else
            {

            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelExport.ExportExcel(dataGridView1);
        }
    }
}
