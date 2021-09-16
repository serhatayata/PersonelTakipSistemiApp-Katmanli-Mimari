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
using DAL.DTO;
namespace PersonelTakipSistemiAPP
{
    public partial class FrmPozisyonBilgileri : Form
    {
        public FrmPozisyonBilgileri()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<Departman_Tablo> departmanlar = new List<Departman_Tablo>();
        public bool isUpdate = false;
        public PozisyonDetayDTO detay = new PozisyonDetayDTO();
        private void FrmPozisyonBilgileri_Load(object sender, EventArgs e)
        {
            departmanlar = DAL.DAO.DepartmanDAO.DepartmanGetir();
            cmbDepartman.DataSource = departmanlar;
            cmbDepartman.DisplayMember = "DepartmanAD";
            cmbDepartman.ValueMember = "ID";
            cmbDepartman.SelectedIndex = -1;

            if (isUpdate)
            {
                txtPozisyonAdi.Text = detay.PozisyonAD;
                cmbDepartman.SelectedValue = detay.DepartmanID;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtPozisyonAdi.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen Pozisyon Adı giriniz...","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (cmbDepartman.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen departman giriniz...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (isUpdate)
                {
                    DialogResult result = MessageBox.Show("Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        detay.PozisyonAD = txtPozisyonAdi.Text;
                        detay.DepartmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                        bool control = false;
                        if (detay.EskiDepartmanID == detay.DepartmanID)
                        {
                            control = true;
                            PozisyonBLL.PozisyonGuncelle(detay,control);
                            MessageBox.Show("Güncelleme tamamlandı.","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {

                        }

                    }

                }
                else
                {
                    Pozisyon_Tablo pz = new Pozisyon_Tablo();
                    pz.PozisyonAd = txtPozisyonAdi.Text;
                    pz.DepartmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                    PozisyonBLL.PozisyonEkle(pz);
                    MessageBox.Show("Pozisyon Eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPozisyonAdi.Clear();
                    cmbDepartman.SelectedIndex = -1;
                }
            }
        }
    }
}
