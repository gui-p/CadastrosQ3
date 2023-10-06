namespace Cadastros.Repository
{
    public interface IGenericRepositorio<Model>
    {
        Task<List<Model>?> BuscarTodos();

        Task<Model?> ListarPorId(long id);

        Task<Model?> Adicionar(Model model);

        Task<Model?> Atualizar(Model model);

        Task<bool> Apagar(Model model);


    }
}
