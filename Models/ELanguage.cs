using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Microservice.Models
{
    public enum ELanguage
    {
        [Description("English")]
        En = 1,
        [Description("Russian")]
        Ru = 2
    }
}
