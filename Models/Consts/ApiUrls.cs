using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Microservice.Models.Consts
{
    public static class ApiUrls
    {
        public const string POST = "https://www.googleapis.com/blogger/v3/blogs/{0}/posts/{1}?key={2}";
        public const string PAGE = "https://www.googleapis.com/blogger/v3/blogs/{0}/pages/{1}?key={2}";
        public const string POSTS = "https://www.googleapis.com/blogger/v3/blogs/{0}/posts?key={1}";
        public const string PAGES = "https://www.googleapis.com/blogger/v3/blogs/{0}/pages?key={1}";
        public const string SEARCH = "https://www.googleapis.com/blogger/v3/blogs/{0}/posts/search?q={0}&key={1}";
    }
}
