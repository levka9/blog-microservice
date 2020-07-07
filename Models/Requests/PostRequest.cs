using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Microservice.Models.Requests
{
    public class PostRequest
    {
        public string PostId { get; set; }
        public ELanguage Language { get; set; }
    }
}
