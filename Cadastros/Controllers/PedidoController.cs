using Cadastros.Models;
using Cadastros.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Cadastros;
using Cadastros.Controllers;

namespace ControleProdutosQ3.Controllers
{
    public class PedidoController : CadastroController<PedidoModel>
    {
   

        private readonly IWebHostEnvironment _environment;

        public PedidoController(IGenericRepositorio<PedidoModel> produtoRepositorio, IWebHostEnvironment environment) : base(produtoRepositorio)
        {
            _environment = environment;
        }


        [HttpPost]
        public async Task<IActionResult> Alterar(PedidoModel modelo)
        {


           


            bool isValid = ValidaModels.Valida(modelo);
            if (!isValid)
            {

                return await Task.FromResult(RedirectToAction("Editar", "Produto"));

            }



            PedidoModel? modBanco = await _repo.ListarPorId(modelo.Id);

            modBanco.ClienteId = modelo.ClienteId;
            modBanco.FuncionarioId = modelo.FuncionarioId;
            modBanco.Status = modelo.Status;
            modBanco.Ativo = modelo.Ativo;

            await _repo.Atualizar(modBanco);
            return await Task.FromResult(RedirectToAction("Index"));
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PedidoModel modelo)
        {
            
            bool isValid = ValidaModels.Valida(modelo);
            if (!isValid)
            {
                
                return await Task.FromResult(View(modelo));
                
            }

            modelo.DataPedido = DateTime.Now;
            modelo.ValorTotal = decimal.Parse("0,00");

            await _repo.Adicionar(modelo);

            return await Task.FromResult(RedirectToAction("Index"));
        }


        public async Task<IActionResult> AlterarEstado(long id)
        {
            PedidoModel modelo = await _repo.ListarPorId(id);

            modelo.Ativo = !modelo.Ativo;

            await _repo.Atualizar(modelo);
            return await Task.FromResult(RedirectToAction("Index"));

        }

    }
}
