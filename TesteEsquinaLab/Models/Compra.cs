using System;
using System.ComponentModel.DataAnnotations;

namespace EsquinaLabApi.Models
{
    public class Compra
    {
        [Key]
        public int CodigoCompra { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataCompra { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public decimal ValorCompra { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public int QuantidadeParcelas { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter no máximo 60 caracteres")]
        public string DescricaoExtrato { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Cliente inválido")]
        public int CodigoCliente { get; set; }

        public Cliente Cliente { get; set; }
    }
}
