using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tommysblog.Data
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Title { get; set; }
        [StringLength(1024)]
        public string Synopsis { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        public string Content { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        [Required]
        [StringLength(128)]
        public string UrlSlug { get; set; }
        [StringLength(128)]
        public string ImageName { get; set; }
        [StringLength(128)]
        public string TeaserImageName { get; set; }

        public virtual IList<Tag> Tags { get; set; }
        public virtual Author Author { get; set; }
    }
}