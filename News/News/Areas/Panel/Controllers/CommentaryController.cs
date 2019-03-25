using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Areas.Panel.Controllers
{
    public class CommentaryController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();

        public ActionResult Index(int? deleted)
        {

            if (deleted.HasValue)
            {
                _uw.CommentaryRep.Clear(deleted.Value);

            }
            return View(_uw.CommentaryRep.BringItAll());
        }
        [HttpGet]
        public ActionResult New()
        {
            ViewBag.Groups = _uw.CommentaryRep.BringItAll();
            return View();
        }

        [HttpPost]
        public ActionResult New(Commentary Coming)
        {
            if (ModelState.IsValid)
            {
                _uw.CommentaryRep.Add(Coming);
                return RedirectToAction("Index");
            }
            return View(Coming);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Groups = _uw.CommentaryRep.BringItAll();
            return View(_uw.CommentaryRep.BringOne(id));
        }

        [HttpPost]
        public ActionResult Edit(Commentary newObject)
        {
            if (ModelState.IsValid)
            {
                _uw.CommentaryRep.Update(newObject);
                return RedirectToAction("Index");
            }

            return View(newObject);
        }
    }
}