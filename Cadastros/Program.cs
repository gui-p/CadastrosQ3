using Cadastros.Data;
using Cadastros.Models;
using Cadastros.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BancoContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<IGenericRepositorio<ProdutoModel>, GenericRepositorio<ProdutoModel>>();
builder.Services.AddScoped<IGenericRepositorio<FuncionarioModel>, GenericRepositorio<FuncionarioModel>>();
builder.Services.AddScoped<IGenericRepositorio<ClienteModel>, GenericRepositorio<ClienteModel>>();
builder.Services.AddScoped<IGenericRepositorio<DependenteModel>, GenericRepositorio<DependenteModel>>();
builder.Services.AddScoped<IGenericRepositorio<PedidoModel>, GenericRepositorio<PedidoModel>>();
builder.Services.AddScoped<IGenericRepositorio<ItemPedidoModel>, GenericRepositorio<ItemPedidoModel>>();
builder.Services.AddScoped<IGenericRepositorio<EnderecoModel>, GenericRepositorio<EnderecoModel>>();


builder.Services.AddRazorPages()
 .AddMvcOptions(options =>
 {
     options.MaxModelValidationErrors = 50;
     options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
     _ => "Este campo é obrigatório.");
 });
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options => options.AddPolicy(
        name: "Politica",
        policy =>
        {
            policy.WithOrigins("https://192.168.0.14", "http://localhost")
            .WithMethods("PUT", "DELETE", "GET", "POST")
            .AllowAnyHeader().AllowAnyOrigin();
        }
    ));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".Cadastros.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(999999);
    options.Cookie.IsEssential = true;
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
