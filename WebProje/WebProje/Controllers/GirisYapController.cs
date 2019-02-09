using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebProje.DAL;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class GirisYapController : Controller
    {
        VeriContext db = new VeriContext();
        // GET: GirisYap
        [HttpGet]
        public ActionResult UyeGiris()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult UyeGiris(Uye model)
        {
            var kullanici = db.Uyeler.FirstOrDefault(x => x.EPosta == model.EPosta && x.Sifre == model.Sifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.KulAdi, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "EPosta veya Şifre Hatalı";
                return View();
            }
           
        }
        [HttpGet]
        public ActionResult AdminGiris()
        {
            return View();
        }
   
        [HttpPost]
        public ActionResult AdminGiris(Admin model)
        {
            var kullanici = db.Adminler.FirstOrDefault(x=>x.EPosta==model.EPosta && x.Sifre==model.Sifre);
            if (kullanici!=null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.KulAdi,false);
                return RedirectToAction("AdminIndex","Admin");
            }
            else
            {
                ViewBag.Mesaj = "EPosta veya Şifre Hatalı";
                return View();
            }
            
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home",null);
        }
    }
}