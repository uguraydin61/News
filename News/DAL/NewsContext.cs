using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsContext : DbContext
    {
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Commentary> Commentary { get; set; }
    }
}
