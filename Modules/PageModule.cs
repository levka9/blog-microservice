using AutoMapper;
using Blog.Microservice.Models;
using Blog.Microservice.Models.Consts;
using Blog.Microservice.Models.Response;
using Blog.Microservice.Models.Responses;
using Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blog.Microservice.Modules
{
    public class PageModule
    {
        #region Properties
        ELanguage language;
        readonly GoogleBloggerAppSettings googleBloggerAppSettings;
        static IAsyncPolicy exponentialRetryPolicy = Policy.Handle<HttpRequestException>()
                                                           .WaitAndRetryAsync(3,
                                                                attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)));
        #endregion

        #region Constructors
        public PageModule(IOptions<GoogleBloggerAppSettings> GoogleBloggerAppSettings,
                          ELanguage Language)
        {
            this.language = Language;
            this.googleBloggerAppSettings = GoogleBloggerAppSettings.Value;

            if (googleBloggerAppSettings.ApiKey == null)
                throw new ArgumentNullException("GoogleBloggerAppSettings is null");
        }
        #endregion

        #region Methods
        public async Task<PageResponse> Get(string PageId)
        {
            string requestUrl = string.Format(ApiUrls.PAGE, googleBloggerAppSettings.GetBlogIdByLanguage(language),
                                                            PageId,
                                                            googleBloggerAppSettings.ApiKey);

            var httpResponse = await GetHttpResponse(requestUrl);
            var pageResponse = await PreparePageResponse(httpResponse);

            return pageResponse;
        }

        public async Task<List<PageResponse>> GetAll()
        {
            string requestUrl = string.Format(ApiUrls.PAGES, googleBloggerAppSettings.GetBlogIdByLanguage(language),
                                                             googleBloggerAppSettings.ApiKey);

            var httpResponse = await GetHttpResponse(requestUrl);
            var response = await PreparePagesResponse(httpResponse);

            return response;
        }

        private async Task<HttpResponseMessage> GetHttpResponse(string requestUrl) => await exponentialRetryPolicy.ExecuteAsync(async () =>
                                                                    await GetHttpResponseService(requestUrl).ConfigureAwait(false));

        private async Task<HttpResponseMessage> GetHttpResponseService(string requestUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.GetAsync(requestUrl);

                    return httpResponse;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex, "PostModule - GetPosts");
                throw ex;
            }
        }

        private async Task<PageResponse> PreparePageResponse(HttpResponseMessage httpResponse)
        {
            httpResponse.EnsureSuccessStatusCode();

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            var jObjectResponse = JObject.Parse(jsonResponse);

            var pageResponse = jObjectResponse.ToObject<PageResponse>();

            return pageResponse;
        }

        private async Task<List<PageResponse>> PreparePagesResponse(HttpResponseMessage httpResponse)
        {
            httpResponse.EnsureSuccessStatusCode();

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            var jObjectResponse = JObject.Parse(jsonResponse);

            var lstPageResult = (jObjectResponse != null) ? jObjectResponse["items"].ToObject<List<PageResponse>>() : null;

            return lstPageResult;
        }         
        #endregion
    }
}
