using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alef_Vinal.Services.Mapping;
using AutoMapper;

namespace Alef_Vinal.Services.Services
{
    public class MapperService
    {
        private readonly IMapper mapper;

        public MapperService()
        {
            mapper = ConfigureMapper();
        }

        private IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ValueCodeMapperProfile>();

            });

            return config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return mapper.Map(source, destination);
        }

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            return mapper.ProjectTo<TDestination>(source);
        }
    }
}
