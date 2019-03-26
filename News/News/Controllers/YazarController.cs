using BLL;
using Entity;
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

            Authors Author = _uw.AuthorsRep.BringOne(id);
            return View(Author);

        }
    }
}