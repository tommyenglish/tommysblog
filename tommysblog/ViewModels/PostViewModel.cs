using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tommysblog.Data;
using tommysblog.Helpers;

namespace tommysblog.ViewModels
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Content { get; set; }
        public string LastEditMonth { get; set; }
        public string LastEditDay { get; set; }
        public string LastEditYear { get; set; }
        public bool IsUpdated { get; set; }
        public string Url { get; set; }
        public string ExternalUrl { get; set; }
        public string ImageName { get; set; }
        public string TeaserImageName { get; set; }
        public string Author { get; set; }
        public IList<TagViewModel> Tags { get; set; }

        public static PostViewModel FromBlogPost(BlogPost p)
        {
            bool isUpdated = p.DateUpdated.HasValue;
            string month = isUpdated ? p.DateUpdated.Value.ToString("MMMM") : p.DateCreated.ToString("MMMM");
            string day = isUpdated ? p.DateUpdated.Value.Day.ToString() : p.DateCreated.Day.ToString();
            string year = isUpdated ? p.DateUpdated.Value.Year.ToString() : p.DateCreated.Year.ToString();
            IList<TagViewModel> tags = p.Tags.Select(t => TagViewModel.FromTag(t)).ToList();

            return new PostViewModel
            {
                Title = p.Title,
                Synopsis = p.Synopsis,
                Content = p.Content,
                LastEditMonth = month,
                LastEditDay = day,
                LastEditYear = year,
                IsUpdated = isUpdated,
                Url = UrlBuilder.GetBlogPostUrl(p.UrlSlug),
                ExternalUrl = UrlBuilder.GetBlogPostUrl(p.UrlSlug, true),
                ImageName = p.ImageName,
                TeaserImageName = p.TeaserImageName,
                Author = p.Author.Nickname,
                Tags = tags
            };
        }
    }
}