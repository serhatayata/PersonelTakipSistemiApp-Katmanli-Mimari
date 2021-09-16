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
using DAL.DTO;
using DAL.DAO;
using System.IO;
namespace PersonelTakipSistemiAPP
{
    public partial class FrmPersonelBilgileri : Form
    {
        public FrmPersonelBilgileri()
        {
            InitializeComponent();
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtMaas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtKullaniciNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        PersonelDTO dto = new PersonelDTO();
        public PersonelDetayDTO detay = new PersonelDetayDTO();
        public bool isUpdate;
        string resim2;
        private void FrmPersonelBilgileri_Load(object sender, EventArgs e)
        {
            dto = PersonelBLL.GetAll();
            cmbDepartman.DataSource = dto.Departmanlar;
            cmbDepartman.DisplayMember = "DepartmanAD";
            cmbDepartman.ValueMember = "ID";
            cmbDepartman.SelectedIndex = -1;
            cmbPozisyon.DataSource = dto.Pozisyonlar;
            cmbPozisyon.DisplayMember = "PozisyonAd";
            cmbPozisyon.ValueMember = "ID";
            cmbPozisyon.SelectedIndex = -1;
            if (dto.Departmanlar.Count > 0)
            {
                comboFull = true;
            }
            if (isUpdate)
            {
                txtAd.Text = detay.Ad;
                txtSoyad.Text = detay.Soyad;
                txtAdres.Text = detay.Adres;
                txtMaas.Text = detay.Maas.ToString();
                txtSifre.Text = detay.Sifre;
                txtKullaniciNo.Text = detay.KullaniciNo.ToString();
                chIsAdmin.Checked = detay.isAdmin;
                cmbDepartman.SelectedValue = detay.DepartmanID;
                cmbPozisyon.SelectedValue = detay.PozisyonID;
                resim2 = Application.StartupPath + "\\resimler\\" + detay.Resim;
                txtResim.Text = resim2;
                pictureBox1.Load(resim2);
                if (!UserStatic.isAdmin)
                {
                    txtAd.Enabled = false;
                    txtSoyad.Enabled = false;
                    txtMaas.Enabled = false;
                    txtKullaniciNo.Enabled = false;
                    chIsAdmin.Enabled = false;
                    cmbDepartman.Enabled = false;
                    cmbPozisyon.Enabled = false;
                    dateTimePicker1.Enabled = false;
                }
            }

        }
        bool comboFull = false;
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
        private void btnGozat_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                txtResim.Text = openFileDialog1.FileName;
                resimAd = Guid.NewGuid().ToString();
                resimAd += openFileDialog1.SafeFileName; 
            }
        }
        string resimAd = "";
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKullaniciNo.Text.Trim() == "")
            {
                MessageBox.Show("Kullanıcı No Boş...");
            }
            else if (PersonelBLL.isUnique(Convert.ToInt32(txtKullaniciNo.Text)))
            {
                MessageBox.Show("Kullanıcı adı kullanılmaktadır. Lütfen farklı bir değer giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAd.Text.Trim() == "")
            {
                MessageBox.Show("Ad Boş...");
            }
            else if (txtSoyad.Text.Trim() == "")
            {
                MessageBox.Show("Soyad Boş...");
            }
            else if (txtMaas.Text.Trim() == "")
            {
                MessageBox.Show("Maaş Boş...");
            }
            else if (txtSifre.Text.Trim() == "")
            {
                MessageBox.Show("Şifre Boş...");
            }
            else if (txtResim.Text.Trim() == "")
            {
                MessageBox.Show("Resim Boş...");
            }
            else if (cmbDepartman.Text.Trim() == "")
            {
                MessageBox.Show("Departman Seçimi Boş...");
            }
            else if (cmbPozisyon.Text.Trim() == "")
            {
                MessageBox.Show("Poziyon Seçimi Boş...");
            }
            else
            {
                if (isUpdate)
                {
                    DialogResult result = MessageBox.Show("Emin misin ??","Dikkat",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        PersonelDetayDTO pr = new PersonelDetayDTO();
                        pr.PersonelID = detay.PersonelID;
                        pr.KullaniciNo = Convert.ToInt32(txtKullaniciNo.Text);
                        pr.Ad = txtAd.Text;
                        pr.Soyad = txtSoyad.Text;
                        pr.isAdmin = chIsAdmin.Checked;
                        pr.Maas = Convert.ToInt32(txtMaas.Text);
                        pr.Sifre = txtSifre.Text;
                        pr.PozisyonID = Convert.ToInt32(cmbPozisyon.SelectedValue);
                        pr.DepartmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                        pr.DogumTarihi = dateTimePicker1.Value;
                        pr.Adres = txtAdres.Text;

                        if (resim2 != txtResim.Text)
                        {
                            pr.Resim = resimAd;
                            if (File.Exists(resim2))
                            {
                                File.Delete(resim2);
                                File.Copy(txtResim.Text, @"resimler\\" + resimAd);
                            }
                        }
                        else
                        {
                            pr.Resim = detay.Resim;
                            PersonelBLL.PersonelGuncelle(pr);
                            MessageBox.Show("Güncellendi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                else
                {
                    Personel_Tablo pr = new Personel_Tablo();
                    pr.KullaniciNo = Convert.ToInt32(txtKullaniciNo.Text);
                    pr.Ad = txtAd.Text;
                    pr.Soyad = txtSoyad.Text;
                    pr.isAdmin = chIsAdmin.Checked;
                    pr.Maas = Convert.ToInt32(txtMaas.Text);
                    pr.Sifre = txtSifre.Text;
                    pr.PozisyonID = Convert.ToInt32(cmbPozisyon.SelectedValue);
                    pr.DepartmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                    pr.DogumGunu = dateTimePicker1.Value;
                    pr.Adres = txtAdres.Text;
                    pr.Resim = resimAd;
                    PersonelBLL.PersonelEkle(pr);
                    File.Copy(txtResim.Text, @"resimler\\" + resimAd);
                    MessageBox.Show("Personel Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKullaniciNo.Clear();
                    txtAd.Clear();
                    txtSoyad.Clear();
                    txtMaas.Clear();
                    chIsAdmin.Checked = false;
                    txtSifre.Clear();
                    cmbDepartman.SelectedIndex = -1;
                    cmbPozisyon.DataSource = dto.Pozisyonlar;
                    cmbPozisyon.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Today;
                    txtAdres.Clear();
                    txtResim.Clear();
                    resimAd = "";
                }
            }
        }
        private void btnKontrolEt_Click(object sender, EventArgs e)
        {
            if (txtKullaniciNo.Text.Trim() == "")
            {
                MessageBox.Show("Kullanıcı adı boş.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (PersonelBLL.isUnique(Convert.ToInt32(txtKullaniciNo.Text)))
            {
                MessageBox.Show("Kullanıcı adı kullanılmaktadır. Lütfen farklı bir değer giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Kullanıcı adı kullanılabilir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
