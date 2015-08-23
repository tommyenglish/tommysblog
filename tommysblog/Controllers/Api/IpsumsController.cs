using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using tommysblog.Data;
using tommysblog.ViewModels;

namespace tommysblog.Controllers.Api
{
    public class IpsumsController : ApiController
    {
        public IHttpActionResult GetLewisQuotes()
        {
            Dataservice dataservice = new Dataservice();

            IList<LoremLewisViewModel> vms = dataservice.GetLewisQuotes().Select(q => new LoremLewisViewModel
            {
                Source = q.Source,
                Length = q.Content.Length,
                Content = q.Content
            }).ToList();

            if (vms == null)
            {
                return NotFound();
            }

            return Ok(vms);
        }
    }
}
