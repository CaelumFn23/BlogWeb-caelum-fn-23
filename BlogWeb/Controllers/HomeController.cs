using BlogWeb.DAO;
using BlogWeb.Infra;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostDAO dao;

        public HomeController(PostDAO dao)
        {
            this.dao = dao;
        }

        public IActionResult Index() => View(dao.BuscaPublicados());

        public IActionResult Busca(string texto) => View("Index", dao.BuscaPublicadosBusca(texto));
    }
}