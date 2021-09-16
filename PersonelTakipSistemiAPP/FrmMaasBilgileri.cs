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
    public partial class FrmMaasBilgileri : Form
    {
        public FrmMaasBilgileri()
        {
            InitializeComponent();
        }
        MaasDTO dto = new MaasDTO();
        private bool comboFull = false;
        public bool isUpdate = false;
        public MaasDetayDTO detay = new MaasDetayDTO(); 
        private void FrmMaasBilgileri_Load(object sender, EventArgs e)
        {
            dto = MaasBLL.GetAll();
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
            cmbMaasAy.DataSource = dto.Aylar;
            cmbMaasAy.DisplayMember = "Ay";
            cmbMaasAy.ValueMember = "ID";
            cmbMaasAy.SelectedIndex = -1;
            txtMaasYil.Text = DateTime.Today.Year.ToString();
            dataGridView1.Font = new Font("Arial", 8, FontStyle.Regular);

            if (isUpdate)
            {
                txtAd.Text = detay.Ad;
                txtSoyad.Text = detay.Soyad;
                txtMaas.Text = detay.MaasMiktar.ToString();
                txtMaasYil.Text = detay.MaasYil.ToString();
                txtKullaniciNo.Text = detay.KullaniciNo.ToString();
                cmbMaasAy.SelectedValue = detay.MaasAyID;
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
        Maas_Tablo maas = new Maas_Tablo();
        int tiklanan = 0;
        int maasMiktar = 0;
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            maas.CalisanID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            txtKullaniciNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tiklanan = maas.CalisanID;
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMaas.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            maasMiktar = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (maas.CalisanID == 0)
            {
                MessageBox.Show("Personel Seçiniz...","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (txtMaas.Text.Trim() == "")
            {
                MessageBox.Show("Maaş Giriniz...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (txtMaasYil.Text.Trim() == "")
            {
                MessageBox.Show("Yıl Seçiniz...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbMaasAy.SelectedIndex == -1)
            {
                MessageBox.Show("Ay Seçiniz...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool control = false;

                if (isUpdate)
                {  
                    DialogResult result = MessageBox.Show("Emin misiniz?","Dikkat",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        MaasDetayDTO maas = new MaasDetayDTO();
                        maas.MaasID = detay.MaasID;
                        maas.MaasAyID = Convert.ToInt32(cmbMaasAy.SelectedValue);
                        maas.MaasYil = Convert.ToInt32(txtMaasYil.Text);
                        maas.EskiMaas = detay.MaasMiktar;
                        maas.PersonelID = detay.PersonelID;
                        maas.MaasMiktar = Convert.ToInt32(txtMaas.Text);
                        if (maas.MaasMiktar > maas.EskiMaas)
                        {
                            control = true;
                        }
                        MaasBLL.MaasGuncelle(maas,control);
                        MessageBox.Show("Maaş güncellendi...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                }
                else
                {
                    if (Convert.ToInt32(txtMaas.Text) > maasMiktar)
                    {
                        control = true;
                    }
                    Maas_Tablo maass = new Maas_Tablo();
                    maass.CalisanID = tiklanan;
                    maass.AY = Convert.ToInt32(cmbMaasAy.SelectedValue);
                    maass.Tutar = Convert.ToInt32(txtMaas.Text);
                    maass.YIL = Convert.ToInt32(txtMaasYil.Text);
                    MaasBLL.MaasEkle(maass,control);
                    MessageBox.Show("Maaş Eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaas.Clear();
                }
            }
        }
    }
}
