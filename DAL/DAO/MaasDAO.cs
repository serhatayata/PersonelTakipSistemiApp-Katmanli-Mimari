using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class MaasDAO : PersonelDataContext
    {
        public static List<Aylar_Tablo> AylarGetir()
        {
            return db.Aylar_Tablos.ToList();
        }

        public static void MaasEkle(Maas_Tablo maass)
        {
            try
            {
                db.Maas_Tablos.InsertOnSubmit(maass);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<MaasDetayDTO> MaasGetir()
        {
            List<MaasDetayDTO> liste = new List<MaasDetayDTO>();
            var list = (from m in db.Maas_Tablos
                        join p in db.Personel_Tablos on m.CalisanID equals p.ID
                        join ay in db.Aylar_Tablos on m.AY equals ay.ID
                        select new
                        {
                            kullaniciNo = p.KullaniciNo,
                            ad = p.Ad,
                            soyad = p.Soyad,
                            maasMiktar = m.Tutar,
                            maasYil = m.YIL,
                            maasAy = ay.Ay,
                            eskiMaas = m.Tutar,
                            maasID = m.ID,
                            personelID = p.ID,
                            departmanID = p.DepartmanID,
                            pozisyonID = p.PozisyonID,
                            maasAyID = m.AY
                        }
                        ).OrderBy(x => x.maasYil).ToList();
            foreach (var item in list)
            {
                MaasDetayDTO dto = new MaasDetayDTO();
                dto.KullaniciNo = item.kullaniciNo;
                dto.Ad = item.ad;
                dto.Soyad = item.soyad;
                dto.MaasMiktar = item.maasMiktar;
                dto.MaasYil = item.maasYil;
                dto.MaasAy = item.maasAy;
                dto.MaasID = item.maasID;
                dto.PersonelID = item.personelID;
                dto.DepartmanID = item.departmanID;
                dto.PozisyonID = item.pozisyonID;
                dto.MaasAyID = item.maasAyID;
                liste.Add(dto);
            }
            return liste;
        }

        public static void MaasSil(int maasID)
        {
            try
            {
                Maas_Tablo maas = db.Maas_Tablos.First(x=> x.ID == maasID);
                db.Maas_Tablos.DeleteOnSubmit(maas);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void MaasGuncelle(MaasDetayDTO maas, bool control)
        {
            try
            {
                Maas_Tablo m = db.Maas_Tablos.First(x => x.ID == maas.MaasID);
                m.AY = maas.MaasAyID;
                m.Tutar = maas.MaasMiktar;
                m.YIL = maas.MaasYil;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
