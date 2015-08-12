using System.Globalization;

namespace tommysblog._Data.Models.Complex
{
    public class ArchiveItem
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string MonthName
        {
            get
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.Month);
            }
        }
        public int TotalPosts { get; set; }
    }

    public class TagCount
    {
        public string TagName { get; set; }
        public string UrlSlug { get; set; }
        public int Total { get; set; }
    }
}