using API_FeriadoAnbima.DBContext;
using API_FeriadoAnbima.Model;
using API_FeriadoAnbima.Model.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Repository
{
    public class FeriadoRepository : IFeriadoRepository
    {
        private readonly FeriadoAnbimaContext _db;
        private IMapper _mapper;
        
        public FeriadoRepository(FeriadoAnbimaContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public async void CreateFeriado(FeriadoDto feriadodto, LogDeRaspagemRequisicao log)
        {
            Feriado feriado = _mapper.Map<FeriadoDto, Feriado>(feriadodto);
            feriado.LogDeRaspagemRequisicao = log;
            if (!feriado.EhValido().IsValid)
                return;
            _db.feriado.Add(feriado);
            await _db.SaveChangesAsync();
        } 
    }
}
