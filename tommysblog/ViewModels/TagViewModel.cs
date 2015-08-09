using tommysblog.Data;
using tommysblog.Helpers;

namespace tommysblog.ViewModels
{
    public class TagViewModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ExternalUrl { get; set; }

        public static TagViewModel FromTag(Tag t)
        {
            return new TagViewModel
            {
                Name = t.Name,
                Url = UrlBuilder.GetTagUrl(t.UrlSlug),
                ExternalUrl = UrlBuilder.GetTagUrl(t.UrlSlug, true)
            };
        }
    }
}