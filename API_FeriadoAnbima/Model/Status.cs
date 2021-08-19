using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ValidationResult = FluentValidation.Results.ValidationResult;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Model
{
    public class Status
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Descrição")]
        [Required]
        public string Descricao { get; set; }
        [Column("Log")]
        [Required]
        public string Log { get; set; }
        public LogDeRaspagemRequisicao LogDeRaspagemRequisicao { get; set; }

        public Status() { }

        public Status(string descricao, string log, LogDeRaspagemRequisicao logDeRaspagemRequisicao) //($"Criação da lista FeriadoDto, dos valores resgatado", "Scrapping", log)
        {
            this.Descricao = descricao;
            this.Log = log;
            this.LogDeRaspagemRequisicao = logDeRaspagemRequisicao;
        }

        public Status(string descricao, string log)
        {
            Descricao = descricao;
            Log = log;
        }

        public ValidationResult EhValido()
        {
            ValidationResult validation = new StatusValidacao().Validate(this);
            return validation;
        }
    }

    public class StatusValidacao : AbstractValidator<Status>
    {
        public StatusValidacao()
        {
            RuleFor(s => s.Descricao)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido a descrição do status");
            RuleFor(s => s.Log)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o tipo de log do status");
            RuleFor(s => s.LogDeRaspagemRequisicao)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o identificador do log de requisição");
        }
    }
}
