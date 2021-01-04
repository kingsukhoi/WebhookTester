using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using APITester.Models;

namespace APITester.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly APITesterContext _context;

        public RequestsController(APITesterContext context)
        {
            _context = context;
        }

        [AcceptVerbs("GET", "POST", "PUT", "DELETE", "HEAD", "OPTIONS", "PATCH")]
        public void AcceptRequest()
        {
            string body;
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                body = reader.ReadToEnd();
            }

            Dictionary<string, string> headersDictionary
                = Request.Headers.ToDictionary(a => a.Key, a => string.Join(";", a.Value));

            string headerString = string.Join("\n", headersDictionary.Select(x=> $"{x.Key}: {x.Value}" ));

            var dbRequest = new Requests
            {
                Verb = Request.Method,
                Headers = headerString,
                Body = body,
                DateReceived = DateTime.UtcNow
            };

            _context.Requests.Add(dbRequest);
            _context.SaveChanges();
        }

    }
}
