using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using APITester.Framework.Models;

namespace APITester.Framework.Controllers
{
    [Route("api/")]
    public class RequestController : ApiController
    {
        [AcceptVerbs("GET", "POST", "PUT", "DELETE", "HEAD", "OPTIONS", "PATCH")]
        public IHttpActionResult RequestResult()
        {
            Dictionary<string, string> headersDictionary
                = Request.Headers.ToDictionary(a => a.Key, a => string.Join(";", a.Value));

            var apiTesterEntities = new APITesterEntities();
            var req = new Request
            {
                Body = Request.Content.ReadAsStringAsync().Result,
                Headers = string.Join("\n", headersDictionary.Select(x => $"{x.Key}: {x.Value}")),
                Verb = Request.Method.ToString(),
                DateReceived = DateTime.UtcNow
            };


            apiTesterEntities.Requests.Add(req);
            apiTesterEntities.SaveChanges();
            return Ok();
        }
    }
}
