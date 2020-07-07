using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}