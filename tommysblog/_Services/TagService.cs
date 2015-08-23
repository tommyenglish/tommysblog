using System.Collections.Generic;
using tommysblog._Data.Models.Complex;
using tommysblog.Data;
using System.Linq;
using tommysblog.Helpers;

namespace tommysblog.Services
{
    public class TagService
    {
        public IList<TagCount> GetTagCounts()
        {
            var dataservice = new Dataservice();
            IList<TagCount> tagCounts = dataservice.GetTagCounts();
            fillTagCounts(tagCounts);
            return tagCounts;
        }
        /// <summary>
        /// Fill weight and url for each tag.
        /// </summary>
        /// <param name="tagCounts">The tags to fill.</param>
        private void fillTagCounts(IList<TagCount> tagCounts)
        {
            int maxCount = tagCounts.Max(t => t.Total);
            foreach (TagCount tagCount in tagCounts)
            {
                double count = (double)tagCount.Total;
                double percent = (count / maxCount) * 100;                    

                if (percent < 20)
                {
                    tagCount.Weight = 1;
                }
                else if (percent < 40)
                {
                    tagCount.Weight = 2;
                }
                else if (percent < 60)
                {
                    tagCount.Weight = 3;
                }
                else if (percent < 80)
                {
                    tagCount.Weight = 4;
                }
                else
                {
                    tagCount.Weight = 5;
                }

                tagCount.Url = UrlBuilder.GetTagUrl(tagCount.UrlSlug);
            }
        }

        public string GetTagNameFromSlug(string urlSlug)
        {
            var dataservice = new Dataservice();
            string tagName = dataservice.GetTagNameFromSlug(urlSlug);
            return tagName;
        }
    }
}