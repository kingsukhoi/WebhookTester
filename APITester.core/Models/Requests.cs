using System;
using System.Collections.Generic;

namespace APITester.Models
{
    public partial class Requests
    {
        public int Id { get; set; }
        public string Headers { get; set; }
        public string Verb { get; set; }
        public string Body { get; set; }
        public DateTime? DateReceived { get; set; }
    }
}
