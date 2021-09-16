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


namespace PersonelTakipSistemiAPP
{
    public partial class FrmDepartmanBilgileri : Form
    {
        public FrmDepartmanBilgileri()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtDepartmanAdi.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen Departman Adını Giriniz...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Departman_Tablo dpt = new Departman_Tablo();
                if (isUpdate)
                {
                    DialogResult result = MessageBox.Show("Emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dpt.DepartmanAD = txtDepartmanAdi.Text;
                        dpt.ID = detay.ID;
                        DepartmanBLL.DepartmanGuncelle(dpt);
                        MessageBox.Show("Güncelleme işlemi tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    dpt.DepartmanAD = txtDepartmanAdi.Text;
                    DepartmanBLL.DepartmanEkle(dpt);
                    MessageBox.Show("Ekleme İşlemi Tamamlandı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDepartmanAdi.Clear();
                    this.Close();
                }
            }
        }
        public bool isUpdate = false;
        public Departman_Tablo detay = new Departman_Tablo();
        private void FrmDepartmanBilgileri_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                txtDepartmanAdi.Text = detay.DepartmanAD;
            }
        }
    }
}
