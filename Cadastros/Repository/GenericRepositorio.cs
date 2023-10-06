using Cadastros.Data;
using Cadastros.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastros.Repository
{
    public class GenericRepositorio<T> : IGenericRepositorio<T> where T : GenericModel
    {

        protected readonly BancoContext _bancoContext;

        public GenericRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
           

        public async Task<T?> Adicionar(T model)
        {
            try
            {
                DbSet<T> dbSet = _bancoContext.Set<T>();
                await dbSet.AddAsync(model);
                await _bancoContext.SaveChangesAsync();
                return model;
            }
            catch 
            {
                return null;
            }
        }

        public async Task<bool> Apagar(T model)
        {
            try
            {
                DbSet<T> dbSet = _bancoContext.Set<T>();
                dbSet.Remove(model);
                await _bancoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<T?> Atualizar(T model)
        {
            try
            {
                _bancoContext.Update(model);
            
                await _bancoContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<T>?> BuscarTodos()
        {
            try
            {
                DbSet<T> dbSet = _bancoContext.Set<T>();
                return await dbSet.ToListAsync();

            }catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<T?> ListarPorId(long id) 
        {
            try
            {
                DbSet<T> dbSet = _bancoContext.Set<T>();
                return await dbSet.FirstOrDefaultAsync(modelo => modelo.Id == id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
