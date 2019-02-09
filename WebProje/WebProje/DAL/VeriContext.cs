using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebProje.Models;

namespace WebProje.DAL
{
    public class VeriContext:DbContext
    {
        public VeriContext() : base("VeriTabani")
        {
            Database.SetInitializer(new DenemeData());
        }
        //--
        public DbSet<Admin> Adminler { get; set; }
        public DbSet<Haber> Haberler { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
    }
}