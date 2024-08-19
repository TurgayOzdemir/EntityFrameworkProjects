using AutoMapper;
using Section11.Projections.DAL;
using Section11.Projections.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section11.Projections.Mappers
{
    internal class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => Lazy.Value;
    }

    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<PDTO, Product>().ReverseMap();
        }
    }
}
