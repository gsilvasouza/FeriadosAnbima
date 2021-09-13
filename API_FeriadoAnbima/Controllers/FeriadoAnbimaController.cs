using API_FeriadoAnbima.AutoMapper;
using API_FeriadoAnbima.Model;
using API_FeriadoAnbima.Repository;
using API_FeriadoAnbima.Scrapping;
using API_FeriadoAnbima.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace API_FeriadoAnbima.Controllers
{
    [Route("api/FeriadosAnbima")]
    [ApiController]
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeriadoAnbimaController : Controller
    {
        private ILogDeRaspagemRequisicaoRepository _logDeRaspagemRequisicaoRepository;
        private IFeriadoRepository _feriadoRepository;
        private IStatusRepository _statusRepository;
        private MappingList _mapping;

        public FeriadoAnbimaController(ILogDeRaspagemRequisicaoRepository logDeRaspagemRequisicaoRepository,
                                        IFeriadoRepository feriadoRepository,
                                        IStatusRepository statusRepository,
                                        MappingList mapping)
        {
            _logDeRaspagemRequisicaoRepository = logDeRaspagemRequisicaoRepository;
            _feriadoRepository = feriadoRepository;
            _statusRepository = statusRepository;
            _mapping = mapping;
        }


        [HttpGet]
        [Route("{ano}")]
   
        public async Task<object> BuscaFeriadosAno(string ano)
        {
            ListFeriado feriados = new ListFeriado();
            FeriadoAnbimaService service = new FeriadoAnbimaService(_logDeRaspagemRequisicaoRepository, _feriadoRepository, _statusRepository, _mapping);
            if (Int32.Parse(ano) > 2000)
            {
                try
                {
                    feriados.feriados = await service.SearchHoliday(ano);
                    feriados.quantidadeFeriados = feriados.feriados.Count;
                    feriados.error = null;
                    return feriados;
                }
                catch (Exception ex)
                {
                    feriados.isSucess = false;
                    feriados.error = new List<string> { ex.ToString() };
                    return BadRequest("Erro durante a requisição, por favor tente novamente mais tarde");
                }
                
            }
            else
            {
                return BadRequest("Por favor, digite um ano entre 2001 e 2078");
            }
        }
    }
}
