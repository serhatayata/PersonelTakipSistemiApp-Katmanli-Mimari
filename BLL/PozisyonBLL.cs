using DAL;
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
    public class PozisyonBLL
    {
        public static void PozisyonEkle(Pozisyon_Tablo pz)
        {
            PozisyonDAO.PozisyonEkle(pz);
        }

        public static List<PozisyonDTO> PozisyonGetir()
        {
            return PozisyonDAO.PozisyonGetir();
        }

        public static void PozisyonGuncelle(PozisyonDetayDTO detay,bool control)
        {
            PozisyonDAO.PozisyonGuncelle(detay);
            if (control)
            {
                PersonelDAO.PersonelGuncelle(detay);
            }
        }

        public static void PozisyonSIL(int id)
        {
            PozisyonDAO.PozisyonSIL(id);
        }
    }
}
