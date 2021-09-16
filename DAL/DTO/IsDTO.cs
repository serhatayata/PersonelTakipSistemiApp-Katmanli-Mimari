using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.DTO
{
    public class IsDTO
    {
        public List<Departman_Tablo> Departmanlar { get; set; }
        public List<PozisyonDTO> Pozisyonlar { get; set; }
        public List<PersonelDetayDTO> Personeller { get; set; }
        public List<IsDurum_Tablo> Durumlar { get; set; }
        public List<IsDetayDTO> Isler { get; set; }
    }
}
