using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class Articles
    {
        [Key]
        public int ArticleID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ArticleTypes ArticleTypes { get; set; }

        public Users Users { get; set; }
        public int? visualization { get; set; }
        public int? Like { get; set; }

        public bool Active { get; set; }
        public Images Images { get; set; }

        public virtual ICollection<Images> Image { get; set; }

        public virtual ICollection<Tags> Tag { get; set; }
    }
}
