using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tommysblog.Data
{
    public class Author
    {
        public int Id { get; set; }
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(128)]
        public string Nickname { get; set; }
        [StringLength(512)]
        public string Bio { get; set; }
        [StringLength(128)]
        public string ImageName { get; set; }
    }
}