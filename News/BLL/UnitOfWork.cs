using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork
    {
        public NewsContext db = new  NewsContext();

        public BaseRepository<Article> ArticleRep;
        public BaseRepository<Authors> AuthorsRep;
        public BaseRepository<Commentary> CommentaryRep;
       

        public UnitOfWork()
        {
            ArticleRep = new BaseRepository<Article >(db);
            AuthorsRep = new BaseRepository<Authors>(db);
            CommentaryRep =new BaseRepository<Commentary>(db);
           
        }
    }
}
