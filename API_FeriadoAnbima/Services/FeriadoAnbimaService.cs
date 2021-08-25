using API_FeriadoAnbima.Model;
using API_FeriadoAnbima.Model.Dto;
using API_FeriadoAnbima.Repository;
using API_FeriadoAnbima.Scrapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Services
{
    public class FeriadoAnbimaService
    {
        private ILogDeRaspagemRequisicaoRepository _logDeRaspagemRequisicaoRepository;
        private IFeriadoRepository _feriadoRepository;
        private IStatusRepository _statusRepository;

        public FeriadoAnbimaService(ILogDeRaspagemRequisicaoRepository logDeRaspagemRequisicaoRepository,
                                    IFeriadoRepository feriadoRepository,
                                    IStatusRepository statusRepository)
        {
            _logDeRaspagemRequisicaoRepository = logDeRaspagemRequisicaoRepository;
            _feriadoRepository = feriadoRepository;
            _statusRepository = statusRepository;
        }
        //TODO: Injeção de metodo pelo construtor da classe
        public async Task<List<FeriadoDto>> SearchHoliday(string ano)
        {
            List<FeriadoDto> feriados = new List<FeriadoDto>();
            ILogDeRaspagemRequisicaoRepository logDeRaspagemRequisicaoRepository = _logDeRaspagemRequisicaoRepository;
            IFeriadoRepository feriadoRepository = _feriadoRepository;
            IStatusRepository statusRepository = _statusRepository;
            ScrappingAnbima scrappingAnbima = new ScrappingAnbima(feriadoRepository, statusRepository, logDeRaspagemRequisicaoRepository);
            try
            {
                //( DateTime data, bool isSucess, int anoSolicitado, string enderecoHttps, string descrição)
                LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, Int32.Parse(ano), $"Requisição de busca dos feriado do ano: {ano} no site Anbima", 
                                                  $"https://www.anbima.com.br/feriados/fer_nacionais/{ano}.asp");
                await _logDeRaspagemRequisicaoRepository.CreateLogRaspagemRequisicao(log); //Salvando a requisicao
                Status status = new Status("Inicio da requisição", "Requisicao", log); //Criando status de incio de requisicao "Inicio da requisição", "Requisição", log
                await _statusRepository.CreateStatus(status); //Salvando o status no banco de dados
                feriados = await scrappingAnbima.SearchHoliday(log, ano);
                Console.WriteLine(log);

                return feriados;
            }
            catch (Exception ex)
            {
                LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, false, Int32.Parse(ano), $"Requisição de busca dos feriado do ano: {ano} no site Anbima",
                                                  $"https://www.anbima.com.br/feriados/fer_nacionais/{ano}.asp");
                await _logDeRaspagemRequisicaoRepository.CreateLogRaspagemRequisicao(log);

                Status statusRetornoScrapping = new Status($"Erro durante o scrapping {ex}", "Scrapping", log); //Criação do objeto status
                await _statusRepository.CreateStatus(statusRetornoScrapping); //Salvando o objeto status

                throw new Exception("Erro durante o scrapping"); //TODO: Tratar melhor o erro gerado
            }
        }
    }
}
