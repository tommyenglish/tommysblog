using System;
using System.Text.RegularExpressions;

namespace tommysblog.Helpers
{
    public class UrlBuilder
    {
        private const string BaseUrl = "http://tommyenglish.net";

        public static string Urlify(string blurb)
        {
            string result = Regex.Replace(blurb, "[^A-Za-z0-9]", "-").ToLower();
            return result;
        }

        public static string GetBlogPostUrl(string postUrlSlug, bool externalize = false)
        {
            string url = String.Format("{0}/blog/{1}", externalize ? UrlBuilder.BaseUrl : "", postUrlSlug);
            return url;
        }

        public static string GetTagUrl(string tagUrlSlug, bool externalize = false)
        {
            string url = String.Format("{0}/blog/tag/{1}", externalize ? UrlBuilder.BaseUrl : "", tagUrlSlug);
            return url;
        }
    }
}