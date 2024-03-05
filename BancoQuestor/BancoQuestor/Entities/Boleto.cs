using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoQuestor.Entities
{
    public class Boleto
    {
        [Key]
        [Required]
        public int Boleto_id { get; set; }
        [Required]
        public string NomePagador { get; set; }
        [Required]
        public string CpfcnpjPagador { get; set; }
        [Required]
        public string NomeBeneficiario { get; set; }
        [Required]
        public string CpfcnpjBeneficiario { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        [Required]
        public int Banco_id { get; set; }

    }
}
