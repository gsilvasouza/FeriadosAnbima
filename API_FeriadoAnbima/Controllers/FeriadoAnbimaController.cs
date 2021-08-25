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
        private ILogDeRaspagemRequisicaoRepository _logDeRaspagemRequisicaoRepository;
        private IFeriadoRepository _feriadoRepository;
        private IStatusRepository _statusRepository;

        public FeriadoAnbimaController( ILogDeRaspagemRequisicaoRepository logDeRaspagemRequisicaoRepository,
                                        IFeriadoRepository feriadoRepository,
                                        IStatusRepository statusRepository)
        {
            this._logDeRaspagemRequisicaoRepository = logDeRaspagemRequisicaoRepository;
            this._feriadoRepository = feriadoRepository;
            this._statusRepository = statusRepository;
        }

        [HttpGet]
        [Route("{ano}")]
        public async Task<object> BuscaFeriadosAno(string ano)
        {
            ListFeriado feriados = new ListFeriado();
            FeriadoAnbimaService service = new FeriadoAnbimaService(_logDeRaspagemRequisicaoRepository, _feriadoRepository, _statusRepository);
            if (Int32.Parse(ano) > 2000)
            {
                try
                {
                    feriados.feriados = await service.SearchHoliday(ano);
                    feriados.quantidadeFeriados = feriados.feriados.Count;
                    feriados.error = null;
                    return Ok(feriados);
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
