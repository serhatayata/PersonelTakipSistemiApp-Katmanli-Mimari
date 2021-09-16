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
    public class IsBLL : PersonelDataContext
    {
        public static IsDTO GetAll()
        {
            IsDTO dto = new IsDTO();
            dto.Departmanlar = DepartmanDAO.DepartmanGetir();
            dto.Pozisyonlar = PozisyonDAO.PozisyonGetir();
            dto.Personeller = PozisyonDAO.PersonelGetir();
            dto.Durumlar = IsDAO.DurumGetir();
            dto.Isler = IsDAO.IsGetir();
            return dto;
        }

        public static void IsEkle(IS_Tablo iss)
        {
            IsDAO.IsEkle(iss);
        }

        public static void IsGuncelle(IsDetayDTO dto)
        {
            IsDAO.IsGuncelle(dto);
        }

        public static void IsSil(int isID)
        {
            IsDAO.IsSil(isID);
        }

        public static void IsGuncelle(int isID)
        {
            IsDAO.IsGuncelle(isID);
        }
    }
}
