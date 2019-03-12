using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Commentary : IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public string YourName { get; set; }
        public string Mail { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual Article Article { get; set; }

    }
}
