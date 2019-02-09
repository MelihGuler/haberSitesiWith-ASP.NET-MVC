using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebProje.DAL;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class TakimBransController : Controller
    {
        // GET: TakimBrans
        VeriContext db = new VeriContext();
        public ActionResult Index(int? SayfaNo,Takim takim,Kategoriler brans)
        {
            int _sayfaNo = SayfaNo ?? 1;
            
            
                var haberler = db.Haberler.OrderByDescending(x => x.HaberID).Where(x => (x.Takim == takim && x.Kategori == brans)).ToPagedList<Haber>(_sayfaNo,9);
                return View(haberler);
            
            
        }
    }
}