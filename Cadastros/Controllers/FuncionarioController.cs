using Cadastros.Models;
using Cadastros.Repository;
using ControleProdutosQ3.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Cadastros.Controllers
{
    public class ClienteController : CadastroController<ClienteModel>
    {

        private readonly IWebHostEnvironment _env;


        public ClienteController(IGenericRepositorio<ClienteModel> repo, IWebHostEnvironment env) : base(repo)
        {
            this._env = env;
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarCriacao(ClienteModel modelo, IFormFile? imagemCarregada, string logradouro, string bairro, string cidade)
        {
            if (ValidaModels.Valida(modelo))
            {
                return await Task.FromResult(RedirectToAction("Criar"));
            }

            if (imagemCarregada != null)
            {
                modelo.Foto = Util.SalvaImagem(imagemCarregada, _env.WebRootPath);
                modelo.NomeDaFoto = Path.GetFileName(imagemCarregada!.FileName);
            }
            else
            {
                modelo.Foto = null;
                modelo.NomeDaFoto = "";
            }

            EnderecoModel endereco = new EnderecoModel()
            {
                Bairro = bairro,
                Logradouro = logradouro,
                Cidade = cidade,
                CEP = modelo.CEP,
                ClienteId = modelo.Id,
                Cliente = modelo
            };

            modelo.Enderecos.Add(endereco);

            await _repo.Adicionar(modelo);

            return await Task.FromResult(RedirectToAction("Index"));
        }

        public async Task<IActionResult> ConfirmarEdicao(ClienteModel modelo, IFormFile? imagemCarregada)
        {

            if (ValidaModels.Valida(modelo))
            {
                return await Task.FromResult(RedirectToAction("Criar"));
            }

            if (imagemCarregada != null)
            {
                modelo.Foto = Util.SalvaImagem(imagemCarregada, _env.WebRootPath);
                modelo.NomeDaFoto = Path.GetFileName(imagemCarregada!.FileName);
            }
            else
            {
                modelo.Foto = null;
                modelo.NomeDaFoto = "";
            }


            ClienteModel modeloBanco = await _repo.ListarPorId(modelo.Id);

            modeloBanco.Nome = modelo.Nome;
            modeloBanco.Sobrenome = modelo.Sobrenome;
            modeloBanco.CPF = modelo.CPF;
            modeloBanco.DDD = modelo.DDD;
            modeloBanco.telefone = modelo.telefone;
            modeloBanco.Ativo = modelo.Ativo;
            modeloBanco.NomeDaFoto = modelo.NomeDaFoto;
            modeloBanco.Foto = modelo.Foto;

            await _repo.Atualizar(modeloBanco);
            return await Task.FromResult(RedirectToAction("Index"));

        }

    }
}
