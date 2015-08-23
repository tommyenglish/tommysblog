using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tommysblog._Data.Models.Complex;
using tommysblog.Data;

namespace tommysblog.Services
{
    public class BlogPostService
    {
        public IList<BlogPost> GetBlogPosts(int skip = 0, int take = 10)
        {
            var dataservice = new Dataservice();
            IList<BlogPost> blogPosts = dataservice.GetBlogPosts(skip, take);
            return blogPosts;
        }

        public IList<BlogPost> GetBlogPostsByTag(string tagUrlSlug, int skip = 0, int take = 10)
        {
            var dataservice = new Dataservice();
            IList<BlogPost> blogPosts = dataservice.GetBlogPostsByTag(tagUrlSlug, skip, take);
            return blogPosts;
        }

        public IList<BlogPost> GetBlogPostsByMonth(int month, int year)
        {
            var dataservice = new Dataservice();
            IList<BlogPost> blogPosts = dataservice.GetBlogPostsByMonth(month, year);
            return blogPosts;
        }

        public BlogPost GetBlogPost(string urlSlug)
        {
            var dataservice = new Dataservice();
            BlogPost blogPost = dataservice.GetBlogPost(urlSlug);
            return blogPost;
        }

        public IList<ArchiveItem> GetArchiveDetails()
        {
            var dataservice = new Dataservice();
            IList<ArchiveItem> archiveDetails = dataservice.GetArchiveDetails();
            return archiveDetails;
        }
    }
}