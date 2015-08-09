using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tommysblog.Data;

namespace tommysblog.Services
{
    public class BlogPostService
    {
        public IList<BlogPost> GetBlogPosts(int count = 10)
        {
            var dataservice = new Dataservice();
            IList<BlogPost> blogPosts = dataservice.GetBlogPosts(count);
            return blogPosts;
        }
    }
}