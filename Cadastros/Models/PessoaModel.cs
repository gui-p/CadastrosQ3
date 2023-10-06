using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Cadastros.Models
{
    public class PessoaModel : GenericModel
    {
        //[Required(ErrorMessage = "Campo obrigatório")]
        //public long Id { get; set; }

        [StringLength(255, ErrorMessage = "Máximo de 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [StringLength(255, ErrorMessage = "Máximo de 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Sobrenome { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Precisa de 11 caracteres")]
        [RegularExpression(@"^\d{11}?")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CPF { get; set; }


        [RegularExpression(@"^\d{2}?")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Precisa de 12 caracteres")]
        public string DDD { get; set; }

        [StringLength(9, MinimumLength = 8, ErrorMessage = "Precisa de no minimo 8 caracteres")]
        [RegularExpression(@"^\d{11}?")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Precisa de 8 caracteres")]
        [RegularExpression(@"^\d{8}?")]
        public string CEP { get; set; }

        //[Required(ErrorMessage = "Campo obrigatório")]
        //public bool Ativo { get; set; } 


    }
}
