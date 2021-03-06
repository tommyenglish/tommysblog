﻿using System;
using System.Collections.Generic;
using System.Linq;
using tommysblog._Data.Models.Complex;

namespace tommysblog.Data
{
    public partial class Dataservice
    {
        public IList<BlogPost> GetBlogPosts(int skip, int take)
        {
            using(var db = new BlogPostContext()) {
                var query = db.BlogPost.Include("Tags").Include("Author").OrderByDescending(bp => bp.DateCreated).Skip(skip).Take(take);
                return query.ToList();
            }
        }

        public IList<BlogPost> GetBlogPostsByTag(string tagUrlSlug, int skip, int take)
        {
            using (var db = new BlogPostContext())
            {
                var query = db.BlogPost.Include("Tags").Include("Author")
                    .Where(bp => bp.Tags.Any(t => t.UrlSlug == tagUrlSlug))
                    .OrderByDescending(bp => bp.DateCreated).Skip(skip).Take(take);
                return query.ToList();
            }
        }

        public IList<BlogPost> GetBlogPostsByMonth(int month, int year)
        {
            DateTime beginDate = new DateTime(year, month, 1);
            DateTime endDate = beginDate.AddMonths(1).AddMilliseconds(-1);

            using (var db = new BlogPostContext())
            {
                var query = db.BlogPost.Include("Tags").Include("Author")
                    .Where(bp => bp.DateCreated >= beginDate && bp.DateCreated <= endDate)
                    .OrderBy(bp => bp.DateCreated);
                return query.ToList();
            }
        }

        public BlogPost GetBlogPost(string urlSlug)
        {
            using (var db = new BlogPostContext())
            {
                var query = db.BlogPost.Include("Tags").Include("Author")
                    .Where(bp => bp.UrlSlug.Equals(urlSlug));
                return query.SingleOrDefault();
            }
        }

        public IList<ArchiveItem> GetArchiveDetails()
        {
            using (var db = new BlogPostContext())
            {
                var query = db.BlogPost
                    .GroupBy(p => new
                    {
                        Month = p.DateCreated.Month,
                        Year = p.DateCreated.Year 
                    })
                    .Select(a => new ArchiveItem 
                    {
                        Month = a.Key.Month,
                        Year = a.Key.Year,
                        TotalPosts = a.Count()
                    })
                    .OrderByDescending(a => a.Year)
                    .ThenByDescending(a => a.Month);

                return query.ToList();
            }
        }

        public IList<TagCount> GetTagCounts()
        {
            using (var db = new BlogPostContext())
            {
                var query = db.BlogPost
                    .SelectMany(p => p.Tags)
                    .GroupBy(t => new { TagName = t.Name, UrlSlug = t.UrlSlug })
                    .Select(t => new TagCount 
                    { 
                        TagName = t.Key.TagName,
                        UrlSlug = t.Key.UrlSlug,
                        Total = t.Count()
                    })
                    .OrderBy(t => t.TagName);

                return query.ToList();
            }
        }

        public string GetTagNameFromSlug(string urlSlug)
        {
            using (var db = new BlogPostContext())
            {
                string tagName = db.Tags.Where(t => t.UrlSlug.Equals(urlSlug)).Select(t => t.Name).SingleOrDefault();
                return tagName;
            }
        }
    }
}