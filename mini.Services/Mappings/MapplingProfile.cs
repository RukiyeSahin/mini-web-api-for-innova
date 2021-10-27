using AutoMapper;
using mini.DTO.Requests;
using mini.DTO.Responses;
using mini.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.DTO.Mappings
{
   public  class MapplingProfile : Profile
    {
        public MapplingProfile()
        {
            CreateMap<Product, ProductSimpleUpdateResponse>().ReverseMap();
            CreateMap<UpdateProductRequest, Product>().ReverseMap();
            CreateMap<AddCustomerRequest, Customer>().ReverseMap();
        }
    }
}
