using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Mail { get; set; }
        public DateTime? RegisterDate { get; set; }
        [Required]
        public string Nick { get; set; }
        [Required]
        public string Password { get; set; }
        public Images Images { get; set; }
        public bool AuthorIs { get; set; }
        public bool Active { get; set; }


        //public List<Articles> Articles { get; set; }
        //public List<Comments> Comments { get; set; }
        //public List<Images> Images { get; set; }

    }
}
