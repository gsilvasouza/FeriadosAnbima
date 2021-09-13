using API_FeriadoAnbima.Model;
using API_FeriadoAnbima.Model.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.AutoMapper
{
    public class MappingList
    {
        private IMapper _mapper;

        public MappingList(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public List<FeriadoDto> MappingListEntityToDto(List<Feriado> feriados)
        {
            List<FeriadoDto> feriadosDtos = new List<FeriadoDto>();
            foreach (Feriado feriado in feriados)
            {
                FeriadoDto feriadoDto = new FeriadoDto();
                feriadoDto = _mapper.Map<Feriado, FeriadoDto>(feriado);
                feriadosDtos.Add(feriadoDto);
            }
            return feriadosDtos;
        }
    }
}
