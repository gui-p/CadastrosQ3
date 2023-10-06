using Cadastros.Models;
using Cadastros.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cadastros.Controllers
{
    public abstract class CadastroController<T> : Controller, ICadastro where T : GenericModel
    {
        protected readonly IGenericRepositorio<T> _repo;
        public CadastroController(IGenericRepositorio<T> repo)
        {
            this._repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<T>? modelos = await _repo.BuscarTodos();
            return View(modelos);
        }

        public async Task<IActionResult> Criar()
        {
            return await Task.FromResult(View());
        }

        public async Task<IActionResult> Editar(long id)
        {

            try
            {
                T? modelo = await _repo.ListarPorId(id) ?? throw new Exception();
                return await Task.FromResult(View(modelo)); ;
            }
            catch
            {
                return await Task.FromResult(RedirectToAction("Index"));
            }
            

        }

        public async Task<IActionResult> TrocarAtividade(long id)
        {
            try
            {
                T? modelo = await _repo.ListarPorId(id) ?? throw new Exception();
                modelo.Ativo = !modelo.Ativo;
                await _repo.Atualizar(modelo);
                return await Task.FromResult(RedirectToAction("Index"));
            }
            catch
            {
                return await Task.FromResult(RedirectToAction("Index")); 
            }
           
        }

        
    }
}
