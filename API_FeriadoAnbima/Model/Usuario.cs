using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Model
{
    [Table("TB_Usuario")]
    public class Usuario
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("Nome")]
        [Required]
        public string nome { get; set; }

        [Column("Senha")]
        [Required]
        public string senha { get; set; }

        [Column("Email")]
        [Required]
        public string email { get; set; }

        public Usuario()
        {
        }
    }
}
