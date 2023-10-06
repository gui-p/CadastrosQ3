namespace Cadastros.Models
{
    public class EnderecoModel : GenericModel
    {
        //public long Id { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }  

        public long? ClienteId { get; set; }

        public ClienteModel? Cliente { get; set; }

        public long? FuncionarioId { get; set; }

        public FuncionarioModel? Funcionario { get; set; }


    }
}
