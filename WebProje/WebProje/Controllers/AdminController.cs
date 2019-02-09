using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.DAL;
using WebProje.Models;
using WebProje.Models.ViewModels;

namespace WebProje.Controllers
{
    public class AdminController : Controller
    {
        VeriContext db = new VeriContext();
        // GET: Admin
        [Authorize]
        public ActionResult AdminIndex()
        {
            var model = new AdminViewModel()
            {
                Haber = db.Haberler.ToList(),
                Uye = db.Uyeler.ToList(),
                Admin = db.Adminler.ToList(),
                Yorum = db.Yorumlar.ToList()   
            };
           
            return View(model);
        }
    }
}