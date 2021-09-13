using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Model.Dto
{
    public class UsuarioDto
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }

        public UsuarioDto()
        {
        }

        public UsuarioDto(int iD, string nome, string senha, string email)
        {
            ID = iD;
            this.nome = nome;
            this.senha = senha;
            this.email = email;
        }
    }
}
