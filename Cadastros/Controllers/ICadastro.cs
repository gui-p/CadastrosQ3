using Cadastros.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadastros.Controllers
{
    public interface ICadastro
    {
        public Task<IActionResult> Index();

        public Task<IActionResult> Criar();

        public Task<IActionResult> Editar(long id);

        public Task<IActionResult> TrocarAtividade(long id);


    }
}
