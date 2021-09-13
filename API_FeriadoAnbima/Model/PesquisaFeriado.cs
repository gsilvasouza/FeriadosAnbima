using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace API_FeriadoAnbima.Model
{
    public class PesquisaFeriado
    {
        public int Ano { get; set; }

        public PesquisaFeriado(){}

        public PesquisaFeriado(int ano)
        {
            Ano = ano;
        }

        public ValidationResult EhValido()
        {
            ValidationResult validation = new PesquisaFeriadoValidacao().Validate(this);
            return validation;
        }
    }

    public class PesquisaFeriadoValidacao : AbstractValidator<PesquisaFeriado>
    {
        //DateTime data, bool isSucess, int anoSolicitado, string enderecoHttps, string descrição
        public PesquisaFeriadoValidacao()
        {
            RuleFor(l => l.Ano)
                .Must(VerifyYear).WithMessage("Por favor, certifique-se de digitar um ano entre 2001 e 2078")
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o ano");
        }

        public static bool VerifyYear(int ano)
        {
            return ano > 2001 && ano < 2078;
        }
    }
}
