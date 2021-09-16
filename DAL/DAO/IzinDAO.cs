using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class IzinDAO : PersonelDataContext
    {
        public static void IzinEkle(Izin_Tablo iz)
        {
            try
            {
                db.Izin_Tablos.InsertOnSubmit(iz);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<IzinDurum_Tablo> DurumGetir()
        {
            return db.IzinDurum_Tablos.ToList();
        }

        public static List<IzinDetayDTO> IzinGetir()
        {
            List<IzinDetayDTO> liste = new List<IzinDetayDTO>();
            var list = (from i in db.Izin_Tablos
                        join p in db.Personel_Tablos on i.CalisanID equals p.ID
                        join d in db.IzinDurum_Tablos on i.IzinDurumID equals d.ID
                        select new
                        {
                            kullaniciNo = p.KullaniciNo,
                            ad = p.Ad,
                            soyad = p.Soyad,
                            durumAd = d.IzinDurumAd,
                            durumID = i.IzinDurumID,
                            baslamaTarihi = i.IzinBaslangicTarihi,
                            bitisTarihi = i.IzinBitisTarihi,
                            personelID = i.CalisanID,
                            izinID = i.ID,
                            aciklama = i.Aciklama,
                            sure = i.Sure,
                            departmanID = p.DepartmanID,
                            pozisyonID=p.PozisyonID
                        }
                ).OrderBy(x=> x.baslamaTarihi).ToList();
            foreach (var item in list)
            {
                IzinDetayDTO dto = new IzinDetayDTO();
                dto.PersonelID = item.personelID;
                dto.BaslamaTarihi = item.baslamaTarihi;
                dto.KullaniciNo = item.kullaniciNo;
                dto.Ad = item.ad;
                dto.Soyad = item.soyad;
                dto.BitisTarihi = item.bitisTarihi;
                dto.Aciklama = item.aciklama;
                dto.IzinDurumAd = item.durumAd;
                dto.IzinDurumID = item.durumID;
                dto.IzinID = item.izinID;
                dto.Sure = item.sure;
                dto.DepartmanID = item.departmanID;
                dto.PozisyonID = item.pozisyonID;
                liste.Add(dto);
            }
            return liste;
        }

        public static void IzinSil(int izinID)
        {
            try
            {
                Izin_Tablo iz = db.Izin_Tablos.First(x=> x.ID == izinID);
                db.Izin_Tablos.DeleteOnSubmit(iz);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void IzinGuncelle(int IzinID, int onayladi)
        {
            try
            {
                Izin_Tablo iz = db.Izin_Tablos.First(x => x.ID == IzinID);
                iz.IzinDurumID = onayladi;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void IzinGuncelle(IzinDetayDTO detayDTO)
        {
            try
            {
                Izin_Tablo iz = db.Izin_Tablos.First(x => x.ID == detayDTO.IzinID); // Gelen ilk satırı aldık. Zaten bize tek satır lazım güncellemek için.
                iz.Aciklama = detayDTO.Aciklama;
                iz.IzinBaslangicTarihi = detayDTO.BaslamaTarihi;
                iz.IzinBitisTarihi = detayDTO.BitisTarihi;
                iz.Sure = detayDTO.Sure;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
