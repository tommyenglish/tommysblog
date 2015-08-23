namespace tommysblog._Data.Models.Complex
{
    public class TagCount
    {
        public string TagName { get; set; }
        public string UrlSlug { get; set; }
        public string Url { get; set; }
        public int Total { get; set; }
        public int Weight { get; set; }
    }
}