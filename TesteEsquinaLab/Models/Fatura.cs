using System;
using System.ComponentModel.DataAnnotations;

namespace EsquinaLabApi.Models
{
    public class Fatura
    {
        [Key]
        public int CodigoFatura { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataVencimento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public decimal ValorFatura { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(47, ErrorMessage = "Este campo deve conter no máximo 47 caracteres")]
        public string CodigoDeBarra { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Cliente inválido")]
        public int CodigoCliente { get; set; }

        public Cliente Cliente { get; set; }
    }
}
