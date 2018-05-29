using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebAppTemplate.Repo;
using WebAppTemplate.ViewModels;

namespace WebAppTemplate
{
    public class AutoMapperConfig
    {
        public static void Configure() {
            Mapper.Initialize(
                x => x.AddProfile<WebProfile>()
            );
        }
    }

    public class WebProfile : Profile
    {
        public WebProfile() {
            CreateMap<OrderViewModel, Orders>();
            CreateMap<Orders, OrderViewModel>();
        }
    }
}