using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProje.DAL;
using WebProje.Models;
using PagedList;
using PagedList.Mvc;

namespace WebProje.Controllers
{
    [Authorize]
    public class UyeController : Controller
    {

        private VeriContext db = new VeriContext();

        // GET: Uye
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page/*int? SayfaNo*/)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.AdSortParm = String.IsNullOrEmpty(sortOrder) ? "AzalanAd" : "";
            ViewBag.SoyadSortParm = sortOrder == "Soyad" ? "AzalanSoyad" : "Soyad";
            ViewBag.KulAdiSortParm = sortOrder == "KulAdi" ? "AzalanKulAdi" : "KulAdi";
            ViewBag.EPostaSortParm = sortOrder == "EPosta" ? "AzalanEPosta" : "EPosta";
            ViewBag.SifreSortParm = sortOrder == "Sifre" ? "AzalanSifre" : "Sifre";
            ViewBag.UyelikTarihiSortParm = sortOrder == "UyelikTarihi" ? "AzalanUyelikTarihi" : "UyelikTarihi";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var uyeler = from s in db.Uyeler
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                uyeler = uyeler.Where(s => s.Ad.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Soyad":
                    uyeler = uyeler.OrderBy(s => s.Soyad);
                    break;
                case "AzalanSoyad":
                    uyeler = uyeler.OrderByDescending(s => s.Soyad);
                    break;
                case "KulAdi":
                    uyeler = uyeler.OrderBy(s => s.KulAdi);
                    break;
                case "AzalanKulAdi":
                    uyeler = uyeler.OrderByDescending(s => s.KulAdi);
                    break;
                case "EPosta":
                    uyeler = uyeler.OrderBy(s => s.EPosta);
                    break;
                case "AzalanEPosta":
                    uyeler = uyeler.OrderByDescending(s => s.EPosta);
                    break;
                case "Sifre":
                    uyeler = uyeler.OrderBy(s => s.Sifre);
                    break;
                case "AzalanSifre":
                    uyeler = uyeler.OrderByDescending(s => s.Sifre);
                    break;
                case "AzalanAd":
                    uyeler = uyeler.OrderByDescending(s => s.Ad);
                    break;
                case "UyelikTarihi":
                    uyeler = uyeler.OrderBy(s => s.UyelikTarihi);
                    break;
                case "AzalanUyelikTarihi":
                    uyeler = uyeler.OrderByDescending(s => s.UyelikTarihi);
                    break;
                default:  // Name ascending 
                    uyeler = uyeler.OrderBy(s => s.Ad);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(uyeler.ToPagedList(pageNumber, pageSize));
            /* int _sayfaNo = SayfaNo ?? 1;
             var uyeler = db.Uyeler.OrderByDescending(x => x.UyeID).ToPagedList<Uye>(_sayfaNo, 10);
             return View(uyeler);*/
        }

        // GET: Uye/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uyeler.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // GET: Uye/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uye/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UyeID,Ad,Soyad,KulAdi,EPosta,Sifre,SifremiHatirla,GirisYapildiMi,UyelikTarihi")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                db.Uyeler.Add(uye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uye);
        }

        // GET: Uye/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uyeler.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // POST: Uye/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UyeID,Ad,Soyad,KulAdi,EPosta,Sifre,SifremiHatirla,GirisYapildiMi,UyelikTarihi")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye);
        }

        // GET: Uye/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uyeler.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // POST: Uye/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uye uye = db.Uyeler.Find(id);
            db.Uyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
