using AutoMapper;
using CarsList.Core.Domain;
using CarsList.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsList.Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
           => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Car, CarDto>();
               cfg.CreateMap<CarDto, Car>();

           })
           .CreateMapper();
    }
}
