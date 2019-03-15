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
        // GET: Panel/Writer
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
                _uw.AuthorsRep.Sil(sil.Value);

            }
            return View(_uw.AuthorsRep.HepsiniGetir());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            ViewBag.Gruplar = _uw.AuthorsRep.HepsiniGetir();
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Authors gelen)
        {
            if (ModelState.IsValid)
            {
                _uw.AuthorsRep.Ekle(gelen);
                return RedirectToAction("Index");
            }
            return View(gelen);
        }
        //Marka/Duzenle/5
        //{controller}/{action}/{id}

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            ViewBag.Gruplar = _uw.AuthorsRep.HepsiniGetir();
            return View(_uw.AuthorsRep.BirTaneGetir(id));
        }

        [HttpPost]
        public ActionResult Duzenle(Authors yeni)
        {
            if (ModelState.IsValid)
            {
                _uw.AuthorsRep.Guncelle(yeni);
                return RedirectToAction("Index");
            }

            return View(yeni);
        }
    }
}