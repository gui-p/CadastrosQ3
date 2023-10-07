using Cadastros.Data;
using Cadastros.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastros.Repository
{
    public class LoginRepositorio : GenericRepositorio<LoginModel>, ILoginRepositorio
    {


        public LoginRepositorio(BancoContext bancoContext) : base(bancoContext)
        {
            
        }

        public async Task<LoginModel> ListarPorUsuario(string usuario)
        {
            DbSet<LoginModel> loginSet = _bancoContext.Set<LoginModel>();

            LoginModel model = await loginSet.FirstOrDefaultAsync(login => login.Usuario == usuario);

            return await Task.FromResult(model);


        }
    }
}
