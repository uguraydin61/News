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
        public ActionResult Makale(int id)
        {

            Article Article = _uw.ArticleRep.BringOne(id);

            Authors author = _uw.AuthorsRep.BringOne(Article.AuthorId);
            ViewBag.Author = author;

            List<Commentary> commentaryList = _uw.CommentaryRep.BringItAll().Where(x => x.ArticleId == Article.Id && x.RepliedToId==null).ToList();
            ViewBag.Commentary = commentaryList;

            return View(Article);

        }
    }
}