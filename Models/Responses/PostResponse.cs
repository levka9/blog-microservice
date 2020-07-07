using Blog.Microservice.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Microservice.Models.Responses
{
    public class PostResponse : PageResponse
    {
        [JsonProperty("labels")]
        public IEnumerable<string> Categories { get; set; }
    }
}
