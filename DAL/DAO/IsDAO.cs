using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
namespace DAL.DAO
{
    public class IsDAO : PersonelDataContext
    {
        public static List<IsDurum_Tablo> DurumGetir()
        {
            return db.IsDurum_Tablos.ToList();
        }
        public static void IsEkle(IS_Tablo iss)
        {
            try
            {
                db.IS_Tablos.InsertOnSubmit(iss);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<IsDetayDTO> IsGetir()
        {
            List<IsDetayDTO> liste = new List<IsDetayDTO>();
            var list = (from i in db.IS_Tablos
                        join p in db.Personel_Tablos on i.CalisanID equals p.ID
                        join d in db.Departman_Tablos on p.DepartmanID equals d.ID
                        join pz in db.Pozisyon_Tablos on p.PozisyonID equals pz.ID
                        join durum in db.IsDurum_Tablos on i.IsDurumID equals durum.ID
                        select new
                        {
                            isID = i.ID,
                            baslik = i.Baslik,
                            icerik = i.Icerik,
                            baslamaTarihi = i.IsBaslamaTarihi,
                            bitisTarihi = i.IsBitisTarihi,
                            kullaniciNo = p.KullaniciNo,
                            ad = p.Ad,
                            soyad = p.Soyad,
                            departman = d.DepartmanAD,
                            pozisyon = pz.PozisyonAd,
                            departmanID = p.DepartmanID,
                            pozisyonID = p.PozisyonID,
                            isDurumu = durum.IsDurumAd,
                            isDurumID = i.IsDurumID,
                            personelID = i.CalisanID
                        }
                        ).OrderBy(x => x.baslamaTarihi).ToList();
            foreach (var item in list)
            {
                IsDetayDTO dto = new IsDetayDTO();
                dto.IsID = item.isID;
                dto.Baslik = item.baslik;
                dto.Icerik = item.icerik;
                dto.IsBaslamaTarihi = item.baslamaTarihi;
                dto.IsBitisTarihi = item.bitisTarihi;
                dto.KullaniciNo = item.kullaniciNo;
                dto.Ad = item.ad;
                dto.Soyad = item.soyad;
                dto.DepartmanAd = item.departman;
                dto.PozisyonAd = item.pozisyon;
                dto.DepartmanID = item.departmanID;
                dto.PozisyonID = item.pozisyonID;
                dto.IsDurumAd = item.isDurumu;
                dto.IsDurumID = item.isDurumID;
                dto.PersonelID = item.personelID;
                liste.Add(dto);
            }
            return liste;
        }

        public static void IsGuncelle(int isID)
        {
            IS_Tablo isss = db.IS_Tablos.First(x=> x.ID == isID);
            if (UserStatic.isAdmin)
            {
                isss.IsDurumID = OnayStatik.Onaylandi;
            }
            else
            {
                isss.IsDurumID = OnayStatik.Tamamlandi;
            }
            db.SubmitChanges();
        }

        public static void IsSil(int isID)
        {
            try
            {
                IS_Tablo iss = db.IS_Tablos.First(x=> x.ID == isID);
                db.IS_Tablos.DeleteOnSubmit(iss);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void IsGuncelle(IsDetayDTO dto)
        {
            try
            {
                IS_Tablo iss = db.IS_Tablos.First(x => x.ID == dto.IsID);
                iss.Baslik = dto.Baslik;
                iss.Icerik = dto.Icerik;
                iss.CalisanID = dto.PersonelID;
                iss.IsDurumID = dto.IsDurumID;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
