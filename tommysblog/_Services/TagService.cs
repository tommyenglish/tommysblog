using System.Collections.Generic;
using tommysblog._Data.Models.Complex;
using tommysblog.Data;

namespace tommysblog.Services
{
    public class TagService
    {
        public IList<TagCount> GetTagCounts()
        {
            var dataservice = new Dataservice();
            IList<TagCount> tagCounts = dataservice.GetTagCounts();
            return tagCounts;
        }

        public string GetTagNameFromSlug(string urlSlug)
        {
            var dataservice = new Dataservice();
            string tagName = dataservice.GetTagNameFromSlug(urlSlug);
            return tagName;
        }
    }
}