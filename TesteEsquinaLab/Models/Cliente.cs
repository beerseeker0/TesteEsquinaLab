using System.ComponentModel.DataAnnotations;

namespace EsquinaLabApi.Models
{
    public class Cliente
    {
        [Key]
        public int CodigoCliente { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 5 e 60 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter entre 5 e 60 caracteres")]
        public string Nome { get; set; }

        [MaxLength(60, ErrorMessage = "Este campo deve conter no máximo 60 caracteres")]
        public string Endereco{ get; set; }

        [MaxLength(8, ErrorMessage = "Este campo deve conter no máximo 8 caracteres")]
        public string CEP { get; set; }

        [MaxLength(50, ErrorMessage = "Este campo deve conter no máximo 50 caracteres")]
        public string Municipio { get; set; }

        [StringLength(2, ErrorMessage = "Este campo deve conter 2 caracteres", MinimumLength = 2)]
        public string UF { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(30, ErrorMessage = "Este campo deve conter entre 5 e 30 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter entre 5 e 30 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 5 e 60 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter entre 5 e 60 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(80, ErrorMessage = "Este campo deve conter no máximo 80 caracteres")]
        public string Email { get; set; }

        public int DataVenctCartao { get; set; }
    }
}
