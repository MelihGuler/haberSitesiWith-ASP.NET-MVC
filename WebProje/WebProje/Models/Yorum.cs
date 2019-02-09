using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.Models
{
    public class Yorum
    {
        public int YorumID { get; set; }
        public int UyeID { get; set; }
        public int HaberID { get; set; }
        public string Icerik { get; set; }
        public DateTime YorumTarihi { get; set; }
        public bool? Onay { get; set; }
        public virtual Uye Uye { get; set; }
        public virtual Haber Haber { get; set; }
    }
}