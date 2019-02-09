using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProje.Controllers
{
    public class HatalarController : Controller
    {
        // GET: Hatalar
        public ActionResult KayitOl()
        {
            return View();
        }
    }
}