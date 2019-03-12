using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Article : IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Authors")]
        public int AuthorId { get; set; }
        public string Head { get; set; }
        public string Image { get; set; }
        public string Paragraph { get; set; }
        public int Year { get; set; }
        public string Mounth { get; set; }
        public long ClickNumber { get; set; }
        public virtual Authors Authors { get; set; }
        public virtual List<Commentary> Commentaries { get; set; }
    }
}
