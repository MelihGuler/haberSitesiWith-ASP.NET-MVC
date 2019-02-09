using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.Models
{
    public class Uye
    {
        public int UyeID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KulAdi { get; set; }
        public string EPosta { get; set; }
        public string Sifre { get; set; }
        public bool SifremiHatirla { get; set; }
        public bool GirisYapildiMi { get; set; }
        public DateTime UyelikTarihi { get; set; }
        public virtual ICollection<Yorum> Yorumlar { get; set; }
    }
}