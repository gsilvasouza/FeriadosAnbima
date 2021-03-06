using API_FeriadoAnbima.Model;
using API_FeriadoAnbima.Model.Dto;
using API_FeriadoAnbima.Repository;
using API_FeriadoAnbima.utils;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace API_FeriadoAnbima.Scrapping
{
    public class ScrappingAnbima
    {
        private IFeriadoRepository _feriadoRepository;
        private IStatusRepository _statusRepository;
        private ILogDeRaspagemRequisicaoRepository _logDeRaspagemRequisicaoRepository;
        public ScrappingAnbima( IFeriadoRepository feriadoRepository,
                               IStatusRepository statusRepository, 
                               ILogDeRaspagemRequisicaoRepository logDeRaspagemRequisicaoRepository)
        {
            this._feriadoRepository = feriadoRepository;
            this._statusRepository = statusRepository;
            this._logDeRaspagemRequisicaoRepository = logDeRaspagemRequisicaoRepository;
        }

        public async Task<List<FeriadoDto>> SearchHoliday(LogDeRaspagemRequisicao _logId, string ano)
        {
            try
            {
                List<FeriadoDto> feriados = new List<FeriadoDto>();

                LogDeRaspagemRequisicao log = await _logDeRaspagemRequisicaoRepository.FindByIdLogRaspagemRequisicao(_logId.ID);
                Console.WriteLine(log);

                Status statusXpath = new Status("Criação do XPATH", "Scrapping", log);
                await _statusRepository.CreateStatus(statusXpath);

                var html = @$"https://www.anbima.com.br/feriados/fer_nacionais/{ano}.asp";
                HtmlWeb web = new HtmlWeb();
                Status statusCarregamento = new Status($"Fazendo o carregamento da pagina Anbima {html}", "Scrapping", log); //Criação do objeto status
                await _statusRepository.CreateStatus(statusCarregamento); //Salvando o objeto status

                HtmlDocument htmlDoc = web.Load(html);
                var table = htmlDoc.DocumentNode.SelectNodes("//table")[2];
                var dados = table.SelectNodes("//tr/td[@class='tabela'][@style='padding-left:10px;']");

                Status statusScrapping = new Status($"Fazendo a raspagem da tela", "Scrapping", log); //Criação do objeto status
                await _statusRepository.CreateStatus(statusScrapping); //Salvando o objeto status

                int contador = 1;

                FeriadoDto feriado = new FeriadoDto();

                Status statusLoopFeriado = new Status($"Criação da lista FeriadoDto, dos valores resgatado", "Scrapping", log); //Criação do objeto status
                await _statusRepository.CreateStatus(statusLoopFeriado); //Salvando o objeto status

                foreach (var nodeLoop in dados)
                {
                    if (contador == 1)
                    {
                        feriado = new FeriadoDto();
                        feriado.data = ConvertUtils.ConvertDate(nodeLoop.InnerText);
                    }
                    if (contador == 2)
                    {
                        feriado.diaDaSemana = HttpUtility.HtmlDecode(nodeLoop.InnerText);
                    }
                    if (contador == 3)
                    {
                        feriado.nome = HttpUtility.HtmlDecode(nodeLoop.InnerText);
                        feriado.ano = Int32.Parse(ano);
                        feriados.Add(feriado);
                        await _feriadoRepository.CreateFeriado(feriado, log);
                        contador = 0;
                    }
                    contador++;
                }

                Status statusRetornoScrapping = new Status($"Criação com sucesso da lista FeriadoDto dos valores resgatado e retorno da função", "Scrapping", log); //Criação do objeto status
                await _statusRepository.CreateStatus(statusRetornoScrapping); //Salvando o objeto status
                return feriados;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro durante o scrapping");
            }   
        }
    }

    
}
