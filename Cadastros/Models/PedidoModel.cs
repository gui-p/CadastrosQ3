using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastros.Models
{
    public class PedidoModel : GenericModel
    {
        //[Required(ErrorMessage = "Campo obrigatório")]
        //public long Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime DataPedido { get; set; }

        [Range(typeof(decimal), "0", "decimal.MaxValue", ErrorMessage = "Apenas valores positivos")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }

        public string? Status { get; set; }


        public long ClienteId { get; set; }

        public ClienteModel Cliente { get; set; }

        public long FuncionarioId { get; set; }

        public FuncionarioModel Funcionario { get; set; }

        public ICollection<ItemPedidoModel> ItemPedidos { get; set; } = new List<ItemPedidoModel>();



    }
}
