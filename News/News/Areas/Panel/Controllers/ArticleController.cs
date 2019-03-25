using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Areas.Panel.Controllers
{
    public class ArticleController : Controller
    {

        UnitOfWork _uw = new UnitOfWork();
  
        public ActionResult Index(int? deleted)
        {

            if (deleted.HasValue)
            {
                _uw.ArticleRep.Clear(deleted.Value);

            }
            return View(_uw.ArticleRep.BringItAll());
        }
        [HttpGet]
        public ActionResult New()
        {
            ViewBag.Groups = _uw.ArticleRep.BringItAll();
            return View();
        }

        [HttpPost]
        public ActionResult New(Article Coming)
        {
            if (ModelState.IsValid)
            {
                _uw.ArticleRep.Add(Coming);
                return RedirectToAction("Index");
            }
            return View(Coming);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Groups = _uw.ArticleRep.BringItAll();
            return View(_uw.ArticleRep.BringOne(id));
        }

        [HttpPost]
        public ActionResult Edit(Article newObject)
        {
            if (ModelState.IsValid)
            {
                _uw.ArticleRep.Update(newObject);
                return RedirectToAction("Index");
            }

            return View(newObject);
        }
    }
}