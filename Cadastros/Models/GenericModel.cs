using System.ComponentModel.DataAnnotations;

namespace Cadastros.Models
{
    public class GenericModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Ativo { get; set; }

    }
}
