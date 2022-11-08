using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public Articles Articles { get; set; }

        private DateTime addDate;

        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = DateTime.Now; }
        }

        public Users Users { get; set; }
        public bool Active { get; set; }

      
    }
}
