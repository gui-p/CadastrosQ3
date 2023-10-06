using Cadastros.Models;
using Cadastros.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Cadastros;
using Cadastros.Controllers;

namespace ControleProdutosQ3.Controllers
{
    public class ProdutoController : CadastroController<ProdutoModel>
    {
   

        private readonly IWebHostEnvironment _environment;

        public ProdutoController(IGenericRepositorio<ProdutoModel> produtoRepositorio, IWebHostEnvironment environment) : base(produtoRepositorio)
        {
            _environment = environment;
        }


        [HttpPost]
        public async Task<IActionResult> Alterar(ProdutoModel produto, IFormFile? imagemCarregada, DateTime dataAlterada)
        {

            produto.DataDeValidade = dataAlterada;

            if (imagemCarregada != null)
            {
                produto.Foto = Util.SalvaImagem(imagemCarregada, _environment.WebRootPath);
                produto.NomeDaFoto = Path.GetFileName(imagemCarregada!.FileName);
            }
            else
            {
                produto.Foto = null;
                produto.NomeDaFoto = "";
            }


            bool isValid = ValidaModels.Valida(produto);
            if (!isValid)
            {

                return await Task.FromResult(RedirectToAction("Editar", "Produto"));

            }



            ProdutoModel? prodBanco = await _repo.ListarPorId(produto.Id);

            prodBanco.Valor = produto.Valor;
            prodBanco.DataDeValidade = produto.DataDeValidade;
            prodBanco.Descricao = produto.Descricao;
            prodBanco.NomeDaFoto = produto.NomeDaFoto;
            prodBanco.Foto = produto.Foto;
            prodBanco.Ativo = produto.Ativo;
            prodBanco.CodigoDeBarras = produto.CodigoDeBarras;
            prodBanco.Quantidade = produto.Quantidade;

            await _repo.Atualizar(prodBanco);
            return await Task.FromResult(RedirectToAction("Index"));
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoModel produto, IFormFile? imagemCarregada)
        {
            
            bool isValid = ValidaModels.Valida(produto);
            if (!isValid)
            {
                
                return await Task.FromResult(View(produto));
                
            }

            if (imagemCarregada != null)
            {
                produto.Foto = Util.SalvaImagem(imagemCarregada, _environment.WebRootPath);
                produto.NomeDaFoto = Path.GetFileName(imagemCarregada!.FileName);
            }
            else
            {
                produto.Foto = null;
                produto.NomeDaFoto = "";
            }

            produto.DataDeRegistro = DateTime.Now;

            await _repo.Adicionar(produto);

            return await Task.FromResult(RedirectToAction("Index"));
        }


        public async Task<IActionResult> AlterarEstado(long id)
        {
            ProdutoModel produto = await _repo.ListarPorId(id);

            produto.Ativo = !produto.Ativo;

            await _repo.Atualizar(produto);
            return await Task.FromResult(RedirectToAction("Index"));

        }

    }
}
