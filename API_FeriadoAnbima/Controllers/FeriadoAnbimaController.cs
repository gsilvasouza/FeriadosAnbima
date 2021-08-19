using API_FeriadoAnbima.Model;
using API_FeriadoAnbima.Repository;
using API_FeriadoAnbima.Scrapping;
using API_FeriadoAnbima.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Controllers
{
    [Route("api/FeriadosAnbima")]
    [ApiController]
    public class FeriadoAnbimaController : Controller
    {
        private FeriadoAnbimaService _feriadoAnbimaService;
        private ILogDeRaspagemRequisicaoRepository _logDeRaspagemRequisicaoRepository;
        private IFeriadoRepository _feriadoRepository;
        private IStatusRepository _statusRepository;

        public FeriadoAnbimaController( ILogDeRaspagemRequisicaoRepository logDeRaspagemRequisicaoRepository, 
                                        FeriadoAnbimaService feriadoAnbimaService,
                                        IFeriadoRepository feriadoRepository,
                                        IStatusRepository statusRepository)
        {
            this._logDeRaspagemRequisicaoRepository = logDeRaspagemRequisicaoRepository;
            this._feriadoAnbimaService = feriadoAnbimaService;
            this._feriadoRepository = feriadoRepository;
            this._statusRepository = statusRepository;
        }

        [HttpGet]
        [Route("{ano}")]
        public async Task<ListFeriado> BuscaFeriadosAno(string ano)
        {
            ListFeriado feriados = new ListFeriado(); 
            try
            {
                feriados.feriados = await _feriadoAnbimaService.SearchHoliday(ano, _logDeRaspagemRequisicaoRepository, _feriadoRepository, _statusRepository);
                feriados.quantidadeFeriados = feriados.feriados.Count;
                feriados.error = null;
            }
            catch(Exception ex)
            {
                feriados.isSucess = false;
                feriados.error = new List<string> { ex.ToString() };
            }
            return feriados;
        }
    }
}
