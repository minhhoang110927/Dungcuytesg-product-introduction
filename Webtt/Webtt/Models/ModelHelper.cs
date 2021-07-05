using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webtt.Models;

namespace Webtt.Models
{
    public class ModelHelper: Profile
    {
        public ModelHelper()
        {
            CreateMap<Product, ProductModels>();
            CreateMap<UserRegistrationModel, User>();
            CreateMap<News, NewsModels>();
        }

    }
}
