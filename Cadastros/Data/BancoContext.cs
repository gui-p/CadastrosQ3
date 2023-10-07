using Cadastros.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastros.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options ) : base(options) 
        {

        }

        public DbSet<ProdutoModel> Produto { get; set; }

        public DbSet<ClienteModel> Cliente { get; set; }

        public DbSet<FuncionarioModel> Funcionario { get; set; }

        public DbSet<DependenteModel> Dependente { get; set;}

        public DbSet<EnderecoModel> Endereco { get; set; }

        public DbSet<PedidoModel> Pedido { get; set; }

        public DbSet<ItemPedidoModel> ItemPedido { get; set; }
        public DbSet<LoginModel> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClienteModel>().HasMany(e => e.Enderecos).WithOne(e => e.Cliente).HasForeignKey(e => e.ClienteId).IsRequired(false);

            modelBuilder.Entity<FuncionarioModel>().HasMany(e => e.Enderecos).WithOne(e => e.Funcionario).HasForeignKey(e => e.FuncionarioId).IsRequired(false);

            modelBuilder.Entity<FuncionarioModel>().HasMany(e => e.Pedidos).WithOne(e => e.Funcionario).HasForeignKey(e => e.FuncionarioId).IsRequired(true);

            modelBuilder.Entity<FuncionarioModel>().HasMany(e => e.Dependentes).WithOne(e => e.Funcionario).HasForeignKey(e => e.FuncionarioId).IsRequired(true);

            modelBuilder.Entity<ClienteModel>().HasMany(e => e.Pedidos).WithOne(e => e.Cliente).HasForeignKey(e => e.ClienteId).IsRequired(true);

            modelBuilder.Entity<ProdutoModel>().HasMany(e => e.ItemPedidos).WithOne(e => e.Produto).HasForeignKey(e => e.ProdutoId).IsRequired(true);

            modelBuilder.Entity<PedidoModel>().HasMany(e => e.ItemPedidos).WithOne(e => e.Pedido).HasForeignKey(e => e.PedidoId).IsRequired(true);


        }


    }
}
