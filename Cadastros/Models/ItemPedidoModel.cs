using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cadastros.Models
{
    public class ItemPedidoModel : GenericModel
    {
        //public long Id { get; set; }

        public long Quantidade { get; set; }

        [Range(typeof(decimal), "0", "decimal.MaxValue", ErrorMessage = "Apenas valores positivos")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        public long PedidoId { get; set; }

        public PedidoModel Pedido { get; set; }

        public ProdutoModel Produto { get; set; }

        public long ProdutoId { get; set; } 





    }
}
