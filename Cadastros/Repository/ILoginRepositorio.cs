using Cadastros.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadastros.Repository
{
    public interface ILoginRepositorio : IGenericRepositorio<LoginModel>
    {
        Task<LoginModel> ListarPorUsuario(string usuario);

    }
}
