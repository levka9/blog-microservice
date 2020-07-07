using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Microservice.Models;
using Blog.Microservice.Models.Requests;
using Blog.Microservice.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Blog.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostController : Controller
    {
        #region Properties
        IMapper mapper;
        IOptions<GoogleBloggerAppSettings> googleBloggerAppSettings;        
        #endregion

        public PostController(IOptions<GoogleBloggerAppSettings> GoogleBloggerAppSettings,
                              IMapper Mapper)
        {
            this.mapper = Mapper;
            this.googleBloggerAppSettings = GoogleBloggerAppSettings;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PostRequest PostRequest)
        {
            var postModule = new PostModule(googleBloggerAppSettings, PostRequest.Language);
            var postResponse = await postModule.GetPost(PostRequest.PostId);

            return Ok(postResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]ELanguage Language)
        {
            var postModule = new PostModule(googleBloggerAppSettings, Language);
            var lstPostsResponse = await postModule.GetPosts();

            return Ok(lstPostsResponse);
        }        
    }
}
