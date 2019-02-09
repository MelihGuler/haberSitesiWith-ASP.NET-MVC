using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.DAL;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class HaberYonlendirController : Controller
    {
        // GET: HaberYonlendir
       private VeriContext db = new VeriContext();
        public ActionResult Index(Haber haber)
        {
            db.Haberler.Find(haber.HaberID).OkunmaSayisi += 1;
            db.SaveChanges();
            return View(db.Haberler.Find(haber.HaberID));
        }
    }
}