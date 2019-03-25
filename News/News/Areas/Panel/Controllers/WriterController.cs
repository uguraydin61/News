using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Areas.Panel.Controllers
{
    public class WriterController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();

        public ActionResult Index(int? deleted)
        {

            if (deleted.HasValue)
            {
                _uw.AuthorsRep.Clear(deleted.Value);

            }
            return View(_uw.AuthorsRep.BringItAll());
        }
        [HttpGet]
        public ActionResult New()
        {
            ViewBag.Groups = _uw.AuthorsRep.BringItAll();
            return View();
        }

        [HttpPost]
        public ActionResult New(Authors Coming)
        {
            if (ModelState.IsValid)
            {
                _uw.AuthorsRep.Add(Coming);
                return RedirectToAction("Index");
            }
            return View(Coming);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Groups = _uw.AuthorsRep.BringItAll();
            return View(_uw.AuthorsRep.BringOne(id));
        }

        [HttpPost]
        public ActionResult Edit(Authors newObject)
        {
            if (ModelState.IsValid)
            {
                _uw.AuthorsRep.Update(newObject);
                return RedirectToAction("Index");
            }

            return View(newObject);
        }
    }
}