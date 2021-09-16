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
    public partial class FrmPozisyonListesi : Form
    {
        public FrmPozisyonListesi()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmPozisyonBilgileri frm = new FrmPozisyonBilgileri();
            frm.isUpdate = false;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            liste = PozisyonBLL.PozisyonGetir();
            dataGridView1.DataSource = liste;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmPozisyonBilgileri frm = new FrmPozisyonBilgileri();
            frm.isUpdate = true;
            frm.detay = detay;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            liste = PozisyonBLL.PozisyonGetir();
            dataGridView1.DataSource = liste;
        }
        //Burada DepartmanID'yi numaralandırma ile gösteremeyiz o nedenle kapsüllenmiş class kullanacağız.
        List<PozisyonDTO> liste = new List<PozisyonDTO>();
        PozisyonDetayDTO detay = new PozisyonDetayDTO();
        private void FrmPozisyonListesi_Load(object sender, EventArgs e)
        {
            liste = PozisyonBLL.PozisyonGetir();
            dataGridView1.DataSource = liste;
            dataGridView1.Columns[0].HeaderText = "Departman Adı";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Pozisyon Adı";


        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detay.DepartmanID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detay.EskiDepartmanID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detay.PozisyonAD = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Emin misin?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PozisyonBLL.PozisyonSIL(detay.ID);
                MessageBox.Show("Silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                liste = PozisyonBLL.PozisyonGetir();
                dataGridView1.DataSource = liste;
            }
        }
    }
}
