using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Application.Mappers
{
    public  class CustomProfile :Profile
    {
        public CustomProfile()
        {
            CreateMap<ProductDetails, ProductDetailsRequestDto>();
        }
    }
}
