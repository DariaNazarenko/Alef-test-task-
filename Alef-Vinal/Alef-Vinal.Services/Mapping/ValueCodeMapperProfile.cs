using System;
using System.Collections.Generic;
using System.Text;
using Alef_Vinal.DataAccess.Domain.Entities;
using Alef_Vinal.Services.DTOs;
using AutoMapper;

namespace Alef_Vinal.Services.Mapping
{
    public class ValueCodeMapperProfile : Profile
    {
        public ValueCodeMapperProfile()
        {
            CreateMap<ValueCodeDto, ValueCode>().ReverseMap();
        }
    }
}
