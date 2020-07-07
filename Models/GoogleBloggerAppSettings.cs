using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Microservice.Models
{
    public class GoogleBloggerAppSettings
    {
        public string ApiKey { get; set; }
        public string RusBlogId { get; set; }
        public string EngBlogId { get; set; }
        
        public string GetBlogIdByLanguage(ELanguage Language)
        {
            string result = string.Empty;

            switch (Language)
            {
                case ELanguage.En:
                    result = EngBlogId;
                    break;
                case ELanguage.Ru:
                    result = RusBlogId;
                    break;
                default: 
                    result = string.Empty;
                    break;
            }
            
            return result;
        }
    }
}
