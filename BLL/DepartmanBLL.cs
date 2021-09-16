using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
namespace BLL
{
    public class DepartmanBLL
    {
        public static void DepartmanEkle(Departman_Tablo dpt)
        {
            DAL.DAO.DepartmanDAO.DepartmanEkle(dpt); //Using DAL.DAO yazarsak burada yazmaya gerek yok.
        }

        public static List<Departman_Tablo> DepartmanGetir()
        {
            return DepartmanDAO.DepartmanGetir();
        }

        public static void DepartmanGuncelle(Departman_Tablo dpt)
        {
            DepartmanDAO.DepartmanGuncelle(dpt);
        }

        public static void DepartmanSil(int id)
        {
            DepartmanDAO.DepartmanSil(id);
        }
    }
}
