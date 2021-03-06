﻿using System.Data.Entity;

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