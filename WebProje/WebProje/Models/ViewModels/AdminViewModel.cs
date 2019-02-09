using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.Models.ViewModels
{
    public class AdminViewModel
    {
        public List<Haber> Haber { get; set; }
        public List<Uye> Uye { get; set; }
        public List<Admin> Admin { get; set; }
        public List<Yorum> Yorum { get; set; }

    }
}