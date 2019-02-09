using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.Models
{
    public class HomeIndexViewModel
    {
        public List<Haber> Haber { get; set; }
        public Uye Uye { get; set; }
    }
}