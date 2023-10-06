namespace Cadastros.Models
{
    public class DependenteModel : PessoaModel
    {
        public FuncionarioModel? Funcionario { get; set; }

        public long? FuncionarioId { get; set; }

    }
}
