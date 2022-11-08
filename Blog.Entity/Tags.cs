using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class Tags
    {
        [Key]
        public int TagID { get; set; }
        [Required]
        public string Tag { get; set; }


        public virtual ICollection<Articles> Article { get; set; }

    }
}
