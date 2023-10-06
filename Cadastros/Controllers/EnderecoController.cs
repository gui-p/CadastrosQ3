using Cadastros.Models;
using Cadastros.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cadastros.Controllers
{
    public class EnderecoController : CadastroController<EnderecoModel>
    {

        public EnderecoController(IGenericRepositorio<EnderecoModel> repo) : base(repo) { }

        public async Task<IActionResult> IndexFuncionarioId(long id)
        {
            List<EnderecoModel> enderecos = await _repo.BuscarTodos();
            IEnumerable<EnderecoModel> enderecosFiltrados = enderecos.Where(e => e.FuncionarioId == id);

            return await Task.FromResult(View(enderecosFiltrados));


        }

        public async Task<IActionResult> IndexClienteId(long id, string nome)
        {
            List<EnderecoModel> enderecos = await _repo.BuscarTodos();

            IEnumerable<EnderecoModel> enderecosFiltrados = enderecos.Where(e => e.ClienteId == id);

            return await Task.FromResult(View(enderecosFiltrados));
        }


    }
}
