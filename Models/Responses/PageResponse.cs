using Helpers.Microservice;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Microservice.Models.Response
{
    public class PageResponse
    {
        public long Id { get; set; }
        [JsonProperty("kind")]
        public string Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [JsonProperty("published")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("updated")]
        public DateTime UpdatedDate { get; set; }
        [JsonProperty("author")]
        public AuthorResponse Author { get; set; }
    }

    [JsonConverter(typeof(JsonPathConverter))]
    public class AuthorResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("image.url")]
        public string ImageUrl { get; set; }
    }
}
