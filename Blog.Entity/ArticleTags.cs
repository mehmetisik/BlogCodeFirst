using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class ArticleTags
    {
        [Key]
        public int ArticleTagID { get; set; }
        public Articles Articles { get; set; }
        public Tags Tags { get; set; }


    }
}
