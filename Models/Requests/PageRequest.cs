using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Microservice.Models.Requests
{
    public class PageRequest
    {
        public string PageId { get; set; }
        public ELanguage Language { get; set; }
    }
}
