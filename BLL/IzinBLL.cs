using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DAL.DTO;
using DAL;
namespace BLL
{
    public class IzinBLL
    {
        public static void IzinEkle(Izin_Tablo iz)
        {
            IzinDAO.IzinEkle(iz);
        }

        public static IzinDTO GetAll()
        {
            IzinDTO dto = new IzinDTO();
            dto.Departmanlar = DepartmanDAO.DepartmanGetir();
            dto.Pozisyonlar = PozisyonDAO.PozisyonGetir();
            dto.IzinDurumlar = IzinDAO.DurumGetir();
            dto.Izinler = IzinDAO.IzinGetir();
            return dto;

        }

        public static void IzinGuncelle(IzinDetayDTO detayDTO)
        {
            IzinDAO.IzinGuncelle(detayDTO);
        }

        public static void IzinGuncelle(int IzinID, int Onayladi)
        {
            IzinDAO.IzinGuncelle(IzinID,Onayladi);
        }

        public static void IzinSil(int izinID)
        {
            IzinDAO.IzinSil(izinID);
        }
    }
}
