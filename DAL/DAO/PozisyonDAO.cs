using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PozisyonDAO : PersonelDataContext
    {
        public static void PozisyonEkle(Pozisyon_Tablo pz)
        {
            try
            {
                db.Pozisyon_Tablos.InsertOnSubmit(pz);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PersonelDetayDTO> PersonelGetir()
        {
            List<PersonelDetayDTO> liste = new List<PersonelDetayDTO>();
            var list = (from p in db.Personel_Tablos
                        join d in db.Departman_Tablos on p.DepartmanID equals d.ID
                        join pz in db.Pozisyon_Tablos on p.PozisyonID equals pz.ID
                        select new
                        {
                            PersonelID = p.ID,
                            Ad = p.Ad,
                            Soyad = p.Soyad,
                            Sifre = p.Sifre,
                            Departman = d.DepartmanAD,
                            Pozisyon = pz.PozisyonAd,
                            DepartmanID = d.ID,
                            PozisyonID = pz.ID,
                            isAdmin = p.isAdmin,
                            Maas = p.Maas,
                            Resim = p.Resim,
                            DogumGunu = p.DogumGunu,
                            Adres = p.Adres,
                            KullaniciNo = p.KullaniciNo
                        }
                        ).OrderBy(x => x.PersonelID).ToList();
            foreach (var item in list)
            {
                PersonelDetayDTO dto = new PersonelDetayDTO();
                dto.PersonelID = item.PersonelID;
                dto.Ad = item.Ad;
                dto.Soyad = item.Soyad;
                dto.Sifre = item.Sifre;
                dto.DepartmanAd = item.Departman;
                dto.PozisyonAd = item.Pozisyon;
                dto.DepartmanID = item.DepartmanID;
                dto.PozisyonID = item.PozisyonID;
                dto.isAdmin = item.isAdmin;
                dto.Maas = item.Maas;
                dto.Resim = item.Resim;
                dto.DogumTarihi = item.DogumGunu;
                dto.Adres = item.Adres;
                dto.KullaniciNo = item.KullaniciNo;
                liste.Add(dto);
            }
            return liste;
        }

        public static void PozisyonSIL(int id)
        {
            Pozisyon_Tablo pz = db.Pozisyon_Tablos.First(x=> x.ID == id);
            db.Pozisyon_Tablos.DeleteOnSubmit(pz);
            db.SubmitChanges();
            #region TRIGGER ACIKLAMA
            //Bu kısımda pozisyon tablosundan silme yapılmadan önce diğer tablolarda
            //bulunan sildiğimiz pozisyonu silmeliyiz. Aksi halde foreign key hatası alırız...
            //Burada bir pozisyon sildiğimizde orada bulunan personellerde silinecek. Personel tablosuna
            //bir trigger yazdığımız için onun trigger'ı ile başka tablolarda da veri silinecek ve işlem kolaylığı
            //sağlanmış olacak.
            //Bunun için SQL'de trigger oluştururuz. 
            #endregion
        }

        public static void PozisyonGuncelle(PozisyonDetayDTO detay)
        {
            Pozisyon_Tablo pz = db.Pozisyon_Tablos.First(x => x.ID == detay.ID);
            pz.PozisyonAd = detay.PozisyonAD;
            pz.DepartmanID = detay.DepartmanID;
            db.SubmitChanges();
        }

        public static List<PozisyonDTO> PozisyonGetir()
        {
            try
            {
                var list = (from p in db.Pozisyon_Tablos join d in db.Departman_Tablos on p.DepartmanID equals d.ID
                            select new
                            {
                                PozisyonID = p.ID,
                                PozisyonADI = p.PozisyonAd,
                                DepartmanID=p.DepartmanID,
                                DepartmanADI=d.DepartmanAD
                            }
                            ).OrderBy(x=>x.PozisyonID).ToList();
                List<PozisyonDTO> liste = new List<PozisyonDTO>();
                foreach (var item in list)
                {
                    PozisyonDTO pzt = new PozisyonDTO();
                    pzt.ID = item.PozisyonID;
                    pzt.PozisyonAd = item.PozisyonADI;
                    pzt.DepartmanID = item.DepartmanID;
                    pzt.DepartmanAD = item.DepartmanADI;
                    liste.Add(pzt);
                }
                return liste; 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
