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
        // GET: Panel/Commentary
        UnitOfWork _uw = new UnitOfWork();




        // GET: Marka
        public ActionResult Index(int? sil)
        {

            if (Session["Giris"] == null)
            {

                return RedirectToAction("Index", "Login");

            }
            if (sil.HasValue)
            {
                _uw.CommentaryRep.Sil(sil.Value);

            }
            return View(_uw.CommentaryRep.HepsiniGetir());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            ViewBag.Gruplar = _uw.CommentaryRep.HepsiniGetir();
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Commentary gelen)
        {
            if (ModelState.IsValid)
            {
                _uw.CommentaryRep.Ekle(gelen);
                return RedirectToAction("Index");
            }
            return View(gelen);
        }
        //Marka/Duzenle/5
        //{controller}/{action}/{id}

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            ViewBag.Gruplar = _uw.CommentaryRep.HepsiniGetir();
            return View(_uw.CommentaryRep.BirTaneGetir(id));
        }

        [HttpPost]
        public ActionResult Duzenle(Commentary yeni)
        {
            if (ModelState.IsValid)
            {
                _uw.CommentaryRep.Guncelle(yeni);
                return RedirectToAction("Index");
            }

            return View(yeni);
        }
    }
}