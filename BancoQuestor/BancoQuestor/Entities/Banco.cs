using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoQuestor.Entities
{
    public class Banco
    {
        [Key]
        [Required]
        public int Banco_id { get; set; }
        [Required]
        public string NomeBanco { get; set; }
        [Required]
        public int CodigoBanco { get; set; }
        [Required]
        public decimal PercentualJuros { get; set; }
    }
}
