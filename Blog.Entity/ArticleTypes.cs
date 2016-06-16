using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class ArticleTypes
    {
        [Key]
        public int ArticleTypeID { get; set; }
        [Required]
        public string TypeName { get; set; }


    }
}
