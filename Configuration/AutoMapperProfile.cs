using AutoMapper;
using Blog.Microservice.Models.Response;
using Blog.Microservice.Models.Responses;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Microservice.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<JObject, PageResponse>().ForMember(dest => dest.Type,
            //                                            m => { m.MapFrom(jo => jo.SelectToken("kind")); })
            //                                  .ForMember(dest => dest.CreatedDate,
            //                                            m => { m.MapFrom(jo => jo.SelectToken("published")); })
            //                                  .ForMember(dest => dest.UpdatedDate,
            //                                            m => { m.MapFrom(jo => jo.SelectToken("updated")); });
        }
    }
}
