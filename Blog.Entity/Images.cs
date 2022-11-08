using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class Images
    {
       
        [Key]
        public int ImageID { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        private DateTime addDate;

        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = DateTime.Now; }
        }

        public ICollection<Articles> Article { get; set; }
    }
}
