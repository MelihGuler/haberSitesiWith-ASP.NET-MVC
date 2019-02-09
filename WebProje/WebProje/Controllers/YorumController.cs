using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.DAL;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class YorumController : Controller
    {
        // GET: Yorum
        VeriContext db = new VeriContext();
        public ActionResult YorumEkle(Haber hbr,string yorum)
        {
            
            return RedirectToAction("Index","HaberYonlendir",hbr);
        }
    }
}