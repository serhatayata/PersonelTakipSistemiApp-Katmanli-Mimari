using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PersonelDAO : PersonelDataContext
    {
        public static void PersonelEkle(Personel_Tablo pr)
        {
            try
            {
                db.Personel_Tablos.InsertOnSubmit(pr);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Personel_Tablo> PersonelGetir(int v)
        {
            return db.Personel_Tablos.Where(x => x.KullaniciNo == v).ToList();
        }

        public static List<Personel_Tablo> PersonelGetir(int v, string text)
        {
            return db.Personel_Tablos.Where(x => x.KullaniciNo == v && x.Sifre == text).ToList();
        }

        public static void PersonelMaasGuncelle(MaasDetayDTO maas)
        {
            try
            {
                Personel_Tablo pr = db.Personel_Tablos.First(x => x.ID == maas.PersonelID);
                pr.Maas = maas.MaasMiktar;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void PersonelSil(int personelID)
        {
            try
            {
                //Ilk olarak personeli silmeden önce bu personelin bulunduğu tablolardan
                //bu personelin bulunduğu verileri sileriz. 
                //Eger silmezsek ve foreign key varsa programda hataya neden olacaktır.
                //Bunu SQL Trigger ile yapacağız ancak aşağıdaki region kodu ile de yapabiliriz.
                #region SQL trigger olmadan bu şekilde de yapabiliriz...
                //List<Izin_Tablo> iz = db.Izin_Tablos.Where(x => x.CalisanID == personelID).ToList();
                //db.Izin_Tablos.DeleteAllOnSubmit(iz);
                //db.SubmitChanges();
                //List<IS_Tablo> iss = db.IS_Tablos.Where(x=> x.CalisanID ==personelID).ToList();
                //db.IS_Tablos.DeleteAllOnSubmit(iss);
                //db.SubmitChanges();
                //List<Maas_Tablo> maass = db.Maas_Tablos.Where(x=> x.CalisanID == personelID).ToList();
                //db.Maas_Tablos.DeleteAllOnSubmit(maass);
                //db.SubmitChanges();
                #endregion
                Personel_Tablo pr = db.Personel_Tablos.First(x=> x.ID ==personelID);
                db.Personel_Tablos.DeleteOnSubmit(pr);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void PersonelGuncelle(PersonelDetayDTO pr)
        {
            try
            {
                Personel_Tablo per = db.Personel_Tablos.First(x => x.ID == pr.PersonelID);
                per.KullaniciNo = pr.KullaniciNo;
                per.Ad = pr.Ad;
                per.Adres = pr.Adres;
                per.DepartmanID = pr.DepartmanID;
                per.DogumGunu = Convert.ToDateTime(pr.DogumTarihi);
                per.isAdmin = pr.isAdmin;
                per.Maas = pr.Maas;
                per.Sifre = pr.Sifre;
                per.PozisyonID = pr.PozisyonID;
                per.Resim = pr.Resim;
                per.Soyad = pr.Soyad;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void PersonelGuncelle(PozisyonDetayDTO detay)
        {
            List<Personel_Tablo> list = db.Personel_Tablos.Where(x => x.PozisyonID == detay.ID).ToList();
            foreach (var item in list)
            {
                item.DepartmanID = detay.DepartmanID;
            }
            db.SubmitChanges();
        }
    }
}
