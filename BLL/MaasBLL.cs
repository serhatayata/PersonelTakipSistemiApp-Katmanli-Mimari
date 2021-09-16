using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;
using DAL.DTO;
namespace BLL
{
    public class MaasBLL
    {
        public static MaasDTO GetAll()
        {
            MaasDTO dto = new MaasDTO();
            dto.Departmanlar = DepartmanDAO.DepartmanGetir();
            dto.Pozisyonlar = PozisyonDAO.PozisyonGetir();
            dto.Personeller = PozisyonDAO.PersonelGetir();
            dto.Aylar = MaasDAO.AylarGetir();
            dto.Maaslar = MaasDAO.MaasGetir();
            return dto;
        }

        public static void MaasEkle(Maas_Tablo maass, bool control)
        {
            MaasDAO.MaasEkle(maass);
            if (control)
            {
                MaasDetayDTO dto = new MaasDetayDTO();
                dto.PersonelID = maass.CalisanID;
                dto.MaasMiktar = maass.Tutar;
                PersonelDAO.PersonelMaasGuncelle(dto);
            }
        }
        public static void MaasGuncelle(MaasDetayDTO maas, bool control)
        {
            MaasDAO.MaasGuncelle(maas,control);
            if (control)
            {
                PersonelDAO.PersonelMaasGuncelle(maas);
            }
        }

        public static void MaasSil(int maasID)
        {
            MaasDAO.MaasSil(maasID);
        }
    }
}
