﻿using API_FeriadoAnbima.Model;
using API_FeriadoAnbima.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Repository
{
    public interface IFeriadoRepository
    {
        void CreateFeriado(FeriadoDto feriadodto, LogDeRaspagemRequisicao log);
    }
}
