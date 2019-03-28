using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Models
{
    public class MostClickViewModel
    {
        public List<Article> articles { get; set; }
        public List<Commentary> commentaries { get; set; }

    }
}