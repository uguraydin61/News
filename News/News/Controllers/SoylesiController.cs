using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class SoylesiController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Soylesi
        public ActionResult Makaleler()
        {
            List<Article> ArticleList = _uw.ArticleRep.BringItAll();
            return View(ArticleList);
           
        }
    }
}