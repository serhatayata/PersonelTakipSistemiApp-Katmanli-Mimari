using System.Collections.Generic;

namespace DAL.DTO
{
    public class IzinDTO
    {
        public List<Departman_Tablo> Departmanlar { get; set; }
        public List<PozisyonDTO> Pozisyonlar { get; set; }
        public List<IzinDurum_Tablo> IzinDurumlar { get; set; }
        public List<IzinDetayDTO> Izinler { get; set; }

    }
}
