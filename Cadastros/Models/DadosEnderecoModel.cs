namespace Cadastros.Models
{
    public class DadosEnderecoModel
    {

        
        public PessoaModel pessoa { get; set; }

        public IEnumerable<EnderecoModel> enderecos { get; set; }
        
    }
}
