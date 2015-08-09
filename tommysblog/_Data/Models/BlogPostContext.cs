using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace tommysblog.Data
{
    public class BlogPostContext : DbContext
    {
        public BlogPostContext()
            : base("tommysblog")
        { }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}