using System;
using System.ComponentModel.DataAnnotations;

namespace EsquinaLabApi.Models
{
    public class Parcela
    {
        [Key]
        public int CodigoParcela { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataVencimento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public decimal ValorParcela { get; set; }

        //Não coloquei como chave composta pois acabaria tendo que usar Fluent API para mapear e definir a chave
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Cliente inválido")]
        public int CodigoCompra { get; set; }

        public Compra Compra { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cliente inválido")]
        public int CodigoFatura { get; set; }

        public Fatura Fatura { get; set; }
    }
}
