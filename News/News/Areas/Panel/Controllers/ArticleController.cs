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
        // GET: Panel/Article
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
                _uw.ArticleRep.Sil(sil.Value);

            }
            return View(_uw.ArticleRep.HepsiniGetir());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            ViewBag.Gruplar = _uw.ArticleRep.HepsiniGetir();
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Article gelen)
        {
            if (ModelState.IsValid)
            {
                _uw.ArticleRep.Ekle(gelen);
                return RedirectToAction("Index");
            }
            return View(gelen);
        }
        //Marka/Duzenle/5
        //{controller}/{action}/{id}

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            ViewBag.Gruplar = _uw.ArticleRep.HepsiniGetir();
            return View(_uw.ArticleRep.BirTaneGetir(id));
        }

        [HttpPost]
        public ActionResult Duzenle(Article yeni)
        {
            if (ModelState.IsValid)
            {
                _uw.ArticleRep.Guncelle(yeni);
                return RedirectToAction("Index");
            }

            return View(yeni);
        }
    }
}