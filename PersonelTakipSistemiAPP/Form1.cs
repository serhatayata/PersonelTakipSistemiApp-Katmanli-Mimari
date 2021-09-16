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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void txtKullaniciAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciNo.Text.Trim() == "")
            {
                MessageBox.Show("Kullanıcı no boş.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (txtSifre.Text.Trim() == "")
            {
                MessageBox.Show("Şifre alanı boş.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<Personel_Tablo> list = PersonelBLL.PersonelGetir(Convert.ToInt32(txtKullaniciNo.Text),txtSifre.Text);
                if (list.Count <= 0)
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Personel_Tablo per = list.First();
                    UserStatic.PersonelID = per.ID;
                    UserStatic.isAdmin = per.isAdmin;
                    UserStatic.KullaniciNo = per.KullaniciNo;
                    FrmMain frm = new FrmMain();
                    this.Hide();
                    frm.ShowDialog();
                }
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
