using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace API_FeriadoAnbima.Model
{
    [Table("TB_LogDeRaspagemRequisicao")]
    public class LogDeRaspagemRequisicao
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("Data")]
        [Required]
        public DateTime data { get; set; }
        [Column("IsSucess")]
        [Required]
        public bool isSucess { get; set; }
        [Column("AnoSolicitado")]
        [Required]
        public int anoSolicitado { get; set; }
        [Column("EnderecoHttps")]
        [Required]
        public string enderecoHttps { get; set; }
        [Column("Descricao")]
        [Required]
        public string descrição { get; set; }
        public ICollection<Status> status { get; set; }
        public ICollection<Feriado> feriados { get; set; }

        public LogDeRaspagemRequisicao()
        {
        }

        public LogDeRaspagemRequisicao( DateTime data, bool isSucess, int anoSolicitado, string enderecoHttps, string descrição)
        {
            this.data = data;
            this.isSucess = isSucess;
            this.anoSolicitado = anoSolicitado;
            this.enderecoHttps = enderecoHttps;
            this.descrição = descrição;
        }

        public LogDeRaspagemRequisicao( DateTime data, int anoSolicitado, string descrição, string enderecoHttps )
        {
            this.data = data;
            this.anoSolicitado = anoSolicitado;
            this.enderecoHttps = enderecoHttps;
            this.descrição = descrição;
        }

        public override string ToString()
        {
            return $"ID: {this.ID }; data: {this.data}; isSucess: {this.isSucess}; enderecoHttps: {this.enderecoHttps}; anoSolicitado: {this.anoSolicitado}";
        }

        public ValidationResult EhValido()
        {
            ValidationResult validation = new LogDeRaspagemRequisicaoValidacao().Validate(this);
            return validation;
        }

    }

    public class LogDeRaspagemRequisicaoValidacao : AbstractValidator<LogDeRaspagemRequisicao>
    {
        //DateTime data, bool isSucess, int anoSolicitado, string enderecoHttps, string descrição
        public LogDeRaspagemRequisicaoValidacao()
        {
            RuleFor(l => l.data)
                .Must(VerifyDate).WithMessage("Por favor, certifique-se de digitar uma data valida")
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido a data");
            RuleFor(l => l.isSucess)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido qual foi o resultado da requisição");
            RuleFor(l => l.anoSolicitado)
                .Must(VerifyYear).WithMessage("Por favor, certifique-se de ter inserido um ano entre 2001 e 2078")
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o ano desejado");
            RuleFor(l => l.enderecoHttps)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o endereço HTTPS da requisição");
            RuleFor(l => l.descrição)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido a descrição da requisição");
        }

        public static bool VerifyDate(DateTime time)
        {
            return time.Hour == DateTime.UtcNow.Hour;
        }

        public static bool VerifyYear(int ano)
        {
            return ano > 2001 && ano < 2078;
        }
    }

}
