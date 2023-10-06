using Cadastros.Models;
using Cadastros.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Cadastros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IGenericRepositorio<ProdutoModel> _repo;

        public HomeController(ILogger<HomeController> logger, IGenericRepositorio<ProdutoModel> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}