using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Model.Dto
{
    public class FeriadoDto
    {
        public string nome { get; set; }
        public string diaDaSemana { get; set; }
        public DateTime data { get; set; }
        public int ano { get; set; }

        public FeriadoDto(string nome, string diaDaSemana, DateTime data, int ano)
        {
            this.nome = nome;
            this.diaDaSemana = diaDaSemana;
            this.data = data;
            this.ano = ano;
        }

        public FeriadoDto()
        {
        }
    }
}
