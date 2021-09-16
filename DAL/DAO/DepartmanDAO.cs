using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class DepartmanDAO : PersonelDataContext
    {
        public static void DepartmanEkle(Departman_Tablo dpt)
        {
            try
            {
                db.Departman_Tablos.InsertOnSubmit(dpt);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Departman_Tablo> DepartmanGetir()
        {
            try
            {
                return db.Departman_Tablos.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DepartmanSil(int id)
        {
            try
            {
                Departman_Tablo dp = db.Departman_Tablos.First(x=> x.ID == id);
                db.Departman_Tablos.DeleteOnSubmit(dp);
                db.SubmitChanges();
                #region SQL Trigger Acıklaması
                //Departman silindiğinde silinmesi gereken Pozisyonlar var bunları trigger ile sileceğiz.
                //Burada departman silindiğinde trigger ile pozisyon silinecek,
                //Pozisyonun silinmesi ile birlikte personel silinecek,
                //Personelin silinmesiyle tetiklenen trigger ile maaş,iş ve izin de silinecektir.
                #endregion
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void DepartmanGuncelle(Departman_Tablo dpt)
        {
            try
            {
                Departman_Tablo dp = db.Departman_Tablos.First(x=> x.ID == dpt.ID);
                dp.DepartmanAD = dpt.DepartmanAD;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
