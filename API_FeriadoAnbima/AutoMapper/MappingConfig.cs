using API_FeriadoAnbima.Model;
using API_FeriadoAnbima.Model.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.AutoMapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<FeriadoDto, Feriado>();
                config.CreateMap<Feriado, FeriadoDto>();
            });

            return mappingConfig;
        }
    }
}
