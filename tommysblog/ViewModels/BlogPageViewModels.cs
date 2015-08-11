using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tommysblog._Data.Models.Complex;

namespace tommysblog.ViewModels
{
    public class BlogLandingPageViewModel
    {
        public IList<PostViewModel> PostViewModels { get; set; }
        public IList<ArchiveItem> ArchiveItems { get; set; }
    }

    public class BlogArchivesPageViewModel
    {
        public IList<PostViewModel> PostViewModels { get; set; }
        public IList<ArchiveItem> ArchiveItems { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public bool IsFuture { get; set; }
    }
}