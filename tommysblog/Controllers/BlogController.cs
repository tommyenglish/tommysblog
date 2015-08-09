using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            IList<PostViewModel> vms = bps.GetBlogPosts(10).Select(p => PostViewModel.FromBlogPost(p)).ToList();
            return View(vms);
        }
    }
}