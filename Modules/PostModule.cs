using Blog.Microservice.Models;
using Blog.Microservice.Models.Consts;
using Blog.Microservice.Models.Responses;
using Helpers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blog.Microservice.Modules
{
    public class PostModule
    {
        #region Properties
        ELanguage language;
        readonly GoogleBloggerAppSettings googleBloggerAppSettings;
        static IAsyncPolicy exponentialRetryPolicy = Policy.Handle<HttpRequestException>()
                                                           .WaitAndRetryAsync(3,
                                                                attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt))); 
        #endregion

        public PostModule(IOptions<GoogleBloggerAppSettings> GoogleBloggerAppSettings,
                          ELanguage Language = ELanguage.En)
        {
            this.language = Language;
            this.googleBloggerAppSettings = GoogleBloggerAppSettings.Value;
        }

        #region Public Methods
        public async Task<PostResponse> GetPost(string postId)
        {
            string requestUrl = string.Format(ApiUrls.POST, googleBloggerAppSettings.GetBlogIdByLanguage(language),
                                                            postId,
                                                            googleBloggerAppSettings.ApiKey);

            var httpResponse = await GetService(requestUrl);
            var postResponse = await PreparePostResponse(httpResponse);

            return postResponse;
        }

        public async Task<IEnumerable<PostResponse>> GetPosts()
        {
            string requestUrl = string.Format(ApiUrls.POSTS, googleBloggerAppSettings.GetBlogIdByLanguage(language),
                                                             googleBloggerAppSettings.ApiKey);

            var httpResponse = await GetHttpResponse(requestUrl);
            var lstPostsResponse = await PreparePostsResponse(httpResponse);

            return lstPostsResponse;
        }
        #endregion

        #region Private Methods
        private async Task<HttpResponseMessage> GetHttpResponse(string requestUrl) => await exponentialRetryPolicy
                                                    .ExecuteAsync(async () => await GetService(requestUrl).ConfigureAwait(false));

        private async Task<HttpResponseMessage> GetService(string requestUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.GetAsync(requestUrl).ConfigureAwait(false);

                    return httpResponse;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex, "PostModule - GetService");
                throw ex;
            }
        }

        private async Task<PostResponse> PreparePostResponse(HttpResponseMessage httpResponse)
        {
            httpResponse.EnsureSuccessStatusCode();

            var jsonPostResponse = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var jObjectPost = JObject.Parse(jsonPostResponse);

            var postResponse = jObjectPost.ToObject<PostResponse>();

            return postResponse;
        }

        private async Task<IEnumerable<PostResponse>> PreparePostsResponse(HttpResponseMessage httpResponse)
        {
            httpResponse.EnsureSuccessStatusCode();

            var jsonPostsResponse = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var jObjectPosts = JObject.Parse(jsonPostsResponse);

            var postResponse = (jObjectPosts != null) ? jObjectPosts["items"].ToObject<IEnumerable<PostResponse>>() : null;

            return postResponse;
        } 
        #endregion
    }
}
