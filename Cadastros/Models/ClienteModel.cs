using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Cadastros.Models
{
    public class ClienteModel : PessoaModel
    {
        [MaybeNull]
        [StringLength(255, ErrorMessage = "Máximo de 255 caracteres")]
        public string? NomeDaFoto { get; set; }

        [MaybeNull]
        public byte[]? Foto { get; set; }

        public ICollection<EnderecoModel> Enderecos { get; set; } = new List<EnderecoModel>();

        public ICollection<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();


    }
}
