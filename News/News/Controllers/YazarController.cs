using BLL;
using Entity;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class YazarController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();

        public ActionResult Liste()
        {

            List<Authors> AuthorList = _uw.AuthorsRep.BringItAll();
            return View(AuthorList);

        }
        public ActionResult Editor(int id)
        {

            Authors author = _uw.AuthorsRep.BringOne(id);
            List<Article> articleList = _uw.ArticleRep.BringItAll().Where(x => x.AuthorId == id).ToList();
            ViewBag.articles = articleList;
            return View(author);
        }
        public ActionResult _MostRead()
        {

            Article Mostarticle = _uw.ArticleRep.BringItAll().OrderByDescending(x => x.Commentaries.Count).First();
            ViewBag.MostArticle = Mostarticle;

            List<Article> Mostarticles = _uw.ArticleRep.BringItAll().OrderByDescending(x => x.Commentaries.Count).Skip(1).ToList();
            ViewBag.MostArticles = Mostarticles;

            List<Article> articles = _uw.ArticleRep.BringItAll().Take(5).OrderByDescending(x => x.ClickNumber).ToList();
            return View(articles);
        }
    }
}