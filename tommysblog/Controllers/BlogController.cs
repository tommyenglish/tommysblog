using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tommysblog._Data.Models.Complex;
using tommysblog.Data;
using tommysblog.Services;
using tommysblog.ViewModels;

namespace tommysblog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            BlogPostService bps = new BlogPostService();
            TagService ts = new TagService();
            IList<PostViewModel> postVms = bps.GetBlogPosts().Select(p => PostViewModel.FromBlogPost(p)).ToList();
            IList<ArchiveItem> archiveItems = bps.GetArchiveDetails();
            IList<TagCount> tagCounts = ts.GetTagCounts();

            BlogLandingPageViewModel vm = new BlogLandingPageViewModel 
            { 
                PostViewModels = postVms,
                ArchiveItems = archiveItems,
                TagCounts = tagCounts
            };

            return View(vm);
        }

        public ActionResult Archive(int month = 0, int year = 0)
        {
            DateTime now = DateTime.Now;

            if(month == 0 || year == 0)
            {
                month = now.Month;
                year = now.Year;
            }
            BlogPostService bps = new BlogPostService();
            TagService ts = new TagService();
            IList<PostViewModel> postVms = bps.GetBlogPostsByMonth(month, year).Select(p => PostViewModel.FromBlogPost(p)).ToList();
            IList<ArchiveItem> archiveItems = bps.GetArchiveDetails();
            IList<TagCount> tagCounts = ts.GetTagCounts();

            BlogArchivesPageViewModel vm = new BlogArchivesPageViewModel
            {
                PostViewModels = postVms,
                ArchiveItems = archiveItems,
                TagCounts = tagCounts,
                Year = year,
                MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                IsFuture = now.Year <= year && now.Month < month
            };

            return View(vm);
        }

        public ActionResult Tags(string urlSlug)
        {
            BlogPostService bps = new BlogPostService();
            TagService ts = new TagService();
            IList<PostViewModel> postVms = bps.GetBlogPostsByTag(urlSlug).Select(p => PostViewModel.FromBlogPost(p)).ToList();
            IList<ArchiveItem> archiveItems = bps.GetArchiveDetails();
            IList<TagCount> tagCounts = ts.GetTagCounts();
            string tagName = ts.GetTagNameFromSlug(urlSlug);

            BlogTagsPageViewModel vm = new BlogTagsPageViewModel
            {
                PostViewModels = postVms,
                ArchiveItems = archiveItems,
                TagCounts = tagCounts,
                TagName = tagName
            };

            return View(vm);
        }
    }
}