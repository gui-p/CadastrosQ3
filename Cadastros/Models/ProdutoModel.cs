using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Cadastros.Models
{

    [Index("CodigoDeBarras", IsUnique = true)]
    public class ProdutoModel : GenericModel
    {
        //[Required(ErrorMessage = "Campo obrigatório")]
        //public long Id { get; set; }

        [StringLength(255, ErrorMessage = "Máximo de 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [StringLength(12, MinimumLength = 12, ErrorMessage = "Precisa de 12 caracteres")]
        [RegularExpression(@"^\d{12}?")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CodigoDeBarras { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataDeValidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime DataDeRegistro { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Apenas valores positivos")]
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public long Quantidade {  get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [MaybeNull]
        [StringLength(255, ErrorMessage = "Máximo de 255 caracteres")]
        public string? NomeDaFoto { get; set; }

        [MaybeNull]
        public byte[]? Foto { get; set; }

        //[Required(ErrorMessage = "Campo obrigatório")]
        //public bool Ativo { get; set; }

        public ICollection<ItemPedidoModel>? ItemPedidos { get; set; } = new List<ItemPedidoModel>();


    }
}
