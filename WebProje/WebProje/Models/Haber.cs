using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.Models
{
    public enum Kategoriler
    {
        Futbol,Basketbol,Voleybol,Diger
    }
    public enum Takim { Fenerbahce,Galatasaray,Besiktas,Trabzonspor,Efes,MilliTakim,Diger }
    public class Haber
    {
        public int HaberID { get; set; }
        public int AdminID { get; set; }
        public string Icerik { get; set; }
        public string Foto { get; set; }
        public Kategoriler? Kategori { get; set; }
        public Takim? Takim { get; set; }
        public DateTime? HaberTarihi { get; set; }
        public bool? Onay { get; set; }
        public string Baslik{ get; set; }
        public int OkunmaSayisi { get; set; }
        public virtual ICollection<Yorum> Yorumlar { get; set; }

        public virtual Admin Admin { get; set; }
    }
}