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
            IList<PostViewModel> postVms = bps.GetBlogPosts().Select(p => PostViewModel.FromBlogPost(p)).ToList();
            IList<ArchiveItem> archiveItems = bps.GetArchiveDetails().ToList();
            BlogLandingPageViewModel vm = new BlogLandingPageViewModel 
            { 
                PostViewModels = postVms,
                ArchiveItems = archiveItems
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
            IList<PostViewModel> postVms = bps.GetBlogPostsByMonth(month, year).Select(p => PostViewModel.FromBlogPost(p)).ToList();
            IList<ArchiveItem> archiveItems = bps.GetArchiveDetails().ToList();
            
            BlogArchivesPageViewModel vm = new BlogArchivesPageViewModel
            {
                PostViewModels = postVms,
                ArchiveItems = archiveItems,
                Year = year,
                MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                IsFuture = now.Year <= year && now.Month < month
            };

            return View(vm);
        }
    }
}