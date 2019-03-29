using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class DergimizController : Controller
    {
        // GET: Dergimiz
        public ActionResult Hakkımızda()
        {
            return View();
        }
    }
}