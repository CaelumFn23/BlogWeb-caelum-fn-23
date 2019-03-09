using BlogWeb.DAO;
using BlogWeb.Infra;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogContext ctx;
        private readonly PostDAO dao;

        public HomeController()
        {
            this.ctx = new BlogContext();
            this.dao = new PostDAO(this.ctx);
        }

        public IActionResult Index() => View(dao.BuscaPublicados());

        public IActionResult Busca(string texto) => View("Index", dao.BuscaPublicadosBusca(texto));

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                ctx.Dispose();

            base.Dispose(disposing);
        }
    }
}