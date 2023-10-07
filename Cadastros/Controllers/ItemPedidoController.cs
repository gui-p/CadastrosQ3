using Cadastros.Models;
using Cadastros.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Cadastros;
using Cadastros.Controllers;

namespace ControleProdutosQ3.Controllers
{
    public class ItemPedidoController : CadastroController<ItemPedidoModel>
    {
   

        private readonly IWebHostEnvironment _environment;

        public ItemPedidoController(IGenericRepositorio<ItemPedidoModel> produtoRepositorio, IWebHostEnvironment environment) : base(produtoRepositorio)
        {
            _environment = environment;
        }


        //[HttpPost]
        //public async Task<IActionResult> Alterar(ItemPedidoModel modelo)
        //{


           


        //    bool isValid = ValidaModels.Valida(modelo);
        //    if (!isValid)
        //    {

        //        return await Task.FromResult(RedirectToAction("Editar", "Produto"));

        //    }



        //    ItemPedidoModel? modBanco = await _repo.ListarPorId(modelo.Id);

        //    modBanco.ClienteId = modelo.ClienteId;
        //    modBanco.FuncionarioId = modelo.FuncionarioId;
        //    modBanco.Status = modelo.Status;
        //    modBanco.Ativo = modelo.Ativo;

        //    await _repo.Atualizar(modBanco);
        //    return await Task.FromResult(RedirectToAction("Index"));
        //}

        [HttpPost]
        public async Task<IActionResult> Criar(ItemPedidoModel modelo)
        {
            
            bool isValid = ValidaModels.Valida(modelo);
            if (!isValid)
            {
                
                return await Task.FromResult(View(modelo));
                
            }

            modelo.Valor = decimal.Parse("0,00");

            await _repo.Adicionar(modelo);

            return await Task.FromResult(RedirectToAction("Index"));
        }

        public async Task<IActionResult> IndexId(long id)
        {
            List<ItemPedidoModel>? modelos = await _repo.BuscarTodos();

            var modelosFiltro = modelos.Where(x => x.PedidoId == id);

            return View(modelosFiltro);
        }


    }
}
