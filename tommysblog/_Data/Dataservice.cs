using System.Collections.Generic;
using System.Linq;

namespace tommysblog.Data
{
    public class Dataservice
    {
        public IList<BlogPost> GetBlogPosts(int count = 10)
        {
            using(var db = new BlogPostContext()) {
                var query = db.BlogPost.Include("Tags").Include("Author").OrderByDescending(bp => bp.DateCreated).Take(count);
                return query.ToList();
            }
        }
    }
}