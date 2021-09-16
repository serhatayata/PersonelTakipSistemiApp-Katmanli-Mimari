using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;

namespace BLL
{
    public class PersonelBLL
    {
        public static PersonelDTO GetAll()
        {
            PersonelDTO dto = new PersonelDTO();
            dto.Departmanlar = DepartmanDAO.DepartmanGetir();
            dto.Pozisyonlar = PozisyonDAO.PozisyonGetir();
            dto.Personeller = PozisyonDAO.PersonelGetir();
            return dto;
        }

        public static void PersonelEkle(Personel_Tablo pr)
        {
            PersonelDAO.PersonelEkle(pr);
        }

        public static bool isUnique(int v)
        {
            List<Personel_Tablo> list = PersonelDAO.PersonelGetir(v);
            if (list.Count>0)
            {
                return true;
            }
            return false;
        }

        public static List<Personel_Tablo> PersonelGetir(int v, string text)
        {
            return PersonelDAO.PersonelGetir(v, text);
        }

        public static void PersonelGuncelle(PersonelDetayDTO pr)
        {
            PersonelDAO.PersonelGuncelle(pr);
        }

        public static void PersonelSil(int personelID)
        {
            PersonelDAO.PersonelSil(personelID);
        }
    }
}
