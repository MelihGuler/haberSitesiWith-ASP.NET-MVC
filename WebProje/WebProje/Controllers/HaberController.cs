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

namespace WebProje.Controllers
{
    [Authorize]
    public class HaberController : Controller
    {
        private VeriContext db = new VeriContext();

        // GET: Haber
      
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.BaslikSortParm = String.IsNullOrEmpty(sortOrder) ? "AzalanBaslik" : "";
            ViewBag.TarihSortParm = sortOrder == "Tarih" ? "AzalanTarih" : "Tarih";
            ViewBag.OkunmaSortParm = sortOrder == "Okunma" ? "AzalanOkunma" : "Okunma";
            ViewBag.OnaySortParm = sortOrder == "Onay" ? "AzalanOnay" : "Onay";
            ViewBag.KategoriSortParm = sortOrder == "Kategori" ? "AzalanKategori" : "Kategori";
            ViewBag.EkleyenSortParm = sortOrder == "Ekleyen" ? "AzalanEkleyen" : "Ekleyen";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var haberler = from s in db.Haberler
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                haberler = haberler.Where(s => s.Baslik.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Onay":
                    haberler = haberler.OrderBy(s => s.Onay);
                    break;
                case "AzalanOnay":
                    haberler = haberler.OrderByDescending(s => s.Onay);
                    break;
                case "Kategori":
                    haberler = haberler.OrderBy(s => s.Kategori);
                    break;
                case "AzalanKategori":
                    haberler = haberler.OrderByDescending(s => s.Kategori);
                    break;
                case "Ekleyen":
                    haberler = haberler.OrderBy(s => s.Admin.Ad);
                    break;
                case "AzalanEkleyen":
                    haberler = haberler.OrderByDescending(s => s.Admin.Ad);
                    break;
                case "Okunma":
                    haberler = haberler.OrderBy(s => s.OkunmaSayisi);
                    break;
                case "AzalanOkunma":
                    haberler = haberler.OrderByDescending(s => s.OkunmaSayisi);
                    break;
                case "AzalanBaslik":
                    haberler = haberler.OrderByDescending(s => s.Baslik);
                    break;
                case "Tarih":
                    haberler = haberler.OrderBy(s => s.HaberTarihi);
                    break;
                case "AzalanTarih":
                    haberler = haberler.OrderByDescending(s => s.HaberTarihi);
                    break;
                default:  // Name ascending 
                    haberler = haberler.OrderBy(s => s.Baslik);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(haberler.ToPagedList(pageNumber, pageSize));
        }
        /* public ActionResult Index(string currentFilter, string searchString, int? page)
         {
             if (searchString != null)
             {
                 page = 1;
             }
             else
             {
                 searchString = currentFilter;
             }

             ViewBag.CurrentFilter = searchString;

             var haberler = from s in db.Haberler
                            select s;
             if (!String.IsNullOrEmpty(searchString))
             {
                 haberler = haberler.Where(s => s.Baslik.Contains(searchString));
             }
             int pageSize = 3;
             int pageNumber = (page ?? 1);
             return View(haberler.ToPagedList(pageNumber, pageSize));
             //var haberler = db.Haberler.Include(h => h.Admin);
             //return View(haberler.ToList());
         }*/

        // GET: Haber/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haber haber = db.Haberler.Find(id);
            if (haber == null)
            {
                return HttpNotFound();
            }
            return View(haber);
        }

        // GET: Haber/Create
        public ActionResult Create()
        {
            ViewBag.AdminID = new SelectList(db.Adminler, "AdminID", "Ad");
            return View();
        }

        // POST: Haber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HaberID,AdminID,Icerik,Foto,Kategori,HaberTarihi,Onay,Baslik,OkunmaSayisi")] Haber haber)
        {
            if (ModelState.IsValid)
            {
                haber.HaberTarihi = DateTime.Now;
                haber.OkunmaSayisi = 0;
                db.Haberler.Add(haber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminID = new SelectList(db.Adminler, "AdminID", "Ad", haber.AdminID);
            return View(haber);
        }

        // GET: Haber/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haber haber = db.Haberler.Find(id);
            if (haber == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminID = new SelectList(db.Adminler, "AdminID", "Ad", haber.AdminID);
            return View(haber);
        }
        
        public ActionResult Delete(int? id)
        {
            Haber haber = db.Haberler.Find(id);
            db.Haberler.Remove(haber);
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
