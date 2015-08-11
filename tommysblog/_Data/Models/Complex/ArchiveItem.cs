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
}