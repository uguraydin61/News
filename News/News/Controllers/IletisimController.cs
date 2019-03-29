using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class IletisimController : Controller
    {
        // GET: İletisim
        public ActionResult Adres()
        {
            return View();
        }
    }
}