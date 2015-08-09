using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tommysblog.Data
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(128)]
        public string UrlSlug { get; set; }

        public virtual IList<BlogPost> BlogPosts { get; set; }
    }
}