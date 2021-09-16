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
    public partial class FrmIzinBilgileri : Form
    {
        private void FrmIzinBilgileri_Load(object sender, EventArgs e)
        {
            txtKullaniciNo.Text = UserStatic.KullaniciNo.ToString();
            if (isUpdate)
            {
                dpBaslama.Value = detay.BaslamaTarihi;
                dpBitis.Value = detay.BitisTarihi;
                txtIzinSuresi.Text = detay.Sure.ToString();
                txtAciklama.Text = detay.Aciklama;
            }
        }
        TimeSpan sure = new TimeSpan();
        public bool isUpdate = false;
        public IzinDetayDTO detay = new IzinDetayDTO();
        public FrmIzinBilgileri()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dpBaslama_ValueChanged(object sender, EventArgs e)
        {
            sure = dpBitis.Value.Date - dpBaslama.Value.Date;
            txtIzinSuresi.Text = sure.TotalDays.ToString();
        }

        private void dpBitis_ValueChanged(object sender, EventArgs e)
        {
            sure = dpBitis.Value.Date - dpBaslama.Value.Date;
            txtIzinSuresi.Text = sure.TotalDays.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtIzinSuresi.Text == "")
            {
                MessageBox.Show("Süre boş.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (Convert.ToInt32(txtIzinSuresi.Text) <= 0)
            {
                MessageBox.Show("Süre geçersiz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtAciklama.Text.Trim() =="")
            {
                MessageBox.Show("Açıklama boş.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (isUpdate)
                {
                    DialogResult result = MessageBox.Show("Emin misiniz?","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        IzinDetayDTO detayDTO = new IzinDetayDTO();
                        detayDTO.IzinID = detay.IzinID;
                        detayDTO.Aciklama = txtAciklama.Text;
                        detayDTO.Sure = Convert.ToInt32(txtIzinSuresi.Text);
                        detayDTO.BaslamaTarihi = dpBaslama.Value;
                        detayDTO.BitisTarihi = dpBitis.Value;
                        IzinBLL.IzinGuncelle(detayDTO);
                        MessageBox.Show("Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    Izin_Tablo iz = new Izin_Tablo();
                    iz.CalisanID = UserStatic.PersonelID;
                    iz.IzinDurumID = 1;
                    iz.IzinBaslangicTarihi = dpBaslama.Value;
                    iz.IzinBitisTarihi = dpBitis.Value;
                    iz.Sure = Convert.ToInt32(sure.TotalDays);
                    iz.Aciklama = txtAciklama.Text;
                    IzinBLL.IzinEkle(iz);
                    MessageBox.Show("İzin eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dpBaslama.Value = DateTime.Today;
                    dpBaslama.Value = DateTime.Today;
                    txtIzinSuresi.Clear();
                    txtAciklama.Clear();
                }
            }
        }
    }
}
