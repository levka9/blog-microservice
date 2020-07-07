using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Microservice.Models;
using Blog.Microservice.Models.Requests;
using Blog.Microservice.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Microservice.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PageController : Controller
    {
        IMapper mapper;
        IOptions<GoogleBloggerAppSettings> googleBloggerAppSettings;

        public PageController(IOptions<GoogleBloggerAppSettings> GoogleBloggerAppSettings,
            IMapper Mapper)
        {
            this.mapper = Mapper;
            this.googleBloggerAppSettings = GoogleBloggerAppSettings;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageRequest PageRequest)
        {
            var pageModule = new PageModule(googleBloggerAppSettings, PageRequest.Language);
            var pageResponse = await pageModule.Get(PageRequest.PageId);

            return Ok(pageResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]ELanguage Language)
        {
            var pageModule = new PageModule(googleBloggerAppSettings, Language);
            var lstPagesResponse = await pageModule.GetAll();

            return Ok(lstPagesResponse);
        }
    }
}
