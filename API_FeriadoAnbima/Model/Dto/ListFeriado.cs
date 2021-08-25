using API_FeriadoAnbima.Model.Dto;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Model
{
    public class ListFeriado
    {
        public List<FeriadoDto> feriados { get; set; }
        public int quantidadeFeriados { get; set; }
        public List<string> error { get; set; }
        public Boolean isSucess { get; set; } = true;

        public ListFeriado()
        {

        }

        public ListFeriado(List<string> errors, List<FeriadoDto> listFeriados)
        {
            this.feriados = listFeriados;
            this.quantidadeFeriados = listFeriados.Count();
            this.error = errors;
        }

        public ListFeriado(List<FeriadoDto> listFeriados)
        {
            this.feriados = listFeriados;
            this.quantidadeFeriados = listFeriados.Count();
            this.error = null;
        }

        public ListFeriado(List<FeriadoDto> feriados, bool isSucess)
        {
            this.isSucess = isSucess;
            this.feriados = feriados;
        }

        public ValidationResult EhValido()
        {
            ValidationResult validation = new ListFeriadoValidacao().Validate(this);
            return validation;
        }
    }

    public class ListFeriadoValidacao : AbstractValidator<ListFeriado>
    {
        public ListFeriadoValidacao()
        {
            RuleFor(lf => lf.feriados)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido a lista de feriados");
            RuleFor(lf => lf.isSucess)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido se a requisição deu certo");
        }
    }
}
