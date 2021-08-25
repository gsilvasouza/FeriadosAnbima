using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace API_FeriadoAnbima.Model
{
    public class Feriado
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("Nome")]
        [Required]
        public string nome { get; set; }
        [Column("DiaDaSemana")]
        [Required]
        public string diaDaSemana { get; set; }
        [Column("Data")]
        [Required]
        public DateTime data { get; set; }
        [Column("Ano")]
        [Required]
        public int ano { get; set; }
        public LogDeRaspagemRequisicao LogDeRaspagemRequisicao { get; set; }

        public Feriado(string nome, string diaDaSemana, DateTime data, int ano, LogDeRaspagemRequisicao log)
        {
            this.nome = nome;
            this.diaDaSemana = diaDaSemana;
            this.data = data;
            this.ano = ano;
            this.LogDeRaspagemRequisicao = log;
        }

        public Feriado(string nome, string diaDaSemana, DateTime data, int ano)
        {
            this.nome = nome;
            this.diaDaSemana = diaDaSemana;
            this.data = data;
            this.ano = ano;
        }

        public Feriado() { }

        public ValidationResult EhValido()
        {
            ValidationResult validation = new FeriadoValidacao().Validate(this);
            return validation;
        }
    }

    public class FeriadoValidacao : AbstractValidator<Feriado>
    {
        public FeriadoValidacao()
        {
            RuleFor(f => f.ano)
                .NotEmpty().WithMessage("Por favor, certique-se de ter inserido o ano")
                .Must(VerifyYear).WithMessage("Por favor, digite um ano entre 2001 e 2078");
            RuleFor(f => f.nome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o nome do feriado");
            RuleFor(f => f.diaDaSemana)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o dia da semana");
            RuleFor(f => f.data)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido a data");
            RuleFor(f => f.LogDeRaspagemRequisicao)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o id do log de requisição");
        }

        public static bool VerifyYear(int ano)
        {
            return ano > 2001 && ano < 2078; 
        }
    }

}
