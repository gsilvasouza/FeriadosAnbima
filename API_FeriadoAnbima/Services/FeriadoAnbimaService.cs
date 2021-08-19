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

        public FeriadoAnbimaService()
        {

        }

        public async Task<List<FeriadoDto>> SearchHoliday(string ano, 
                                                          ILogDeRaspagemRequisicaoRepository _logDeRaspagemRequisicaoRepository,
                                                          IFeriadoRepository _feriadoRepository,
                                                          IStatusRepository _statusRepository)
        {
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao();
            List<FeriadoDto> feriados = new List<FeriadoDto>();
            ILogDeRaspagemRequisicaoRepository logDeRaspagemRequisicaoRepository = _logDeRaspagemRequisicaoRepository;
            IFeriadoRepository feriadoRepository = _feriadoRepository;
            IStatusRepository statusRepository = _statusRepository;
            ScrappingAnbima scrappingAnbima = new ScrappingAnbima(feriadoRepository, statusRepository, logDeRaspagemRequisicaoRepository);
            try
            {
                log.data = DateTime.UtcNow;
                log.anoSolicitado = Int32.Parse(ano);
                log.descrição = $"Requisição de busca dos feriado do ano: {ano} no site Anbima";
                log.enderecoHttps = $"https://www.anbima.com.br/feriados/fer_nacionais/{ano}.asp";
                log.isSucess = true;
                Console.WriteLine(await _logDeRaspagemRequisicaoRepository.CreateLogRaspagemRequisicao(log)); //Salvando a requisicao 

                Status status = new Status(); //Criando status de incio de requisicao "Inicio da requisição", "Requisição", log
                status.Descricao = "Inicio da requisição";
                status.Log = "Requisicao";
                status.LogDeRaspagemRequisicao = log;
                _statusRepository.CreateStatus(status); //Salvando o status no banco de dados

                feriados = await scrappingAnbima.SearchHoliday(log, ano);
                Console.WriteLine(log);

                return feriados;
            }
            catch (Exception ex)
            {
                log.isSucess = false;
                Console.WriteLine(await _logDeRaspagemRequisicaoRepository.UpdateLogRaspagemRequisicao(log));

                Status statusRetornoScrapping = new Status($"Erro durante o scrapping {ex}", "Scrapping", log); //Criação do objeto status
                _statusRepository.CreateStatus(statusRetornoScrapping); //Salvando o objeto status

                throw new Exception(ex.ToString());
            }
        }
    }
}
