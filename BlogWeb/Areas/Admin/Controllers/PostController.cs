using BlogWeb.DAO;
using BlogWeb.Infra;
using BlogWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly PostDAO dao;

        public PostController(PostDAO dao)
        {
            this.dao = dao;
        }

        public IActionResult Index()
        {
            return View(dao.Lista());
        }

        public IActionResult Novo()
        {
            return View(new Post());
        }

        [HttpPost]
        public IActionResult Adiciona(Post p)
        {
            if (ModelState.IsValid)
            {
                dao.Adiciona(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Novo", p);
            }
        }

        [HttpGet]
        public IActionResult Visualiza(int id)
        {
            return View(dao.FirstOrDefault(id));
        }

        [HttpPost]
        public IActionResult Editar(Post p)
        {
            if (ModelState.IsValid)
            {
                dao.Editar(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Visualiza", p);
            }
        }

        public IActionResult Remover(int id)
        {
            dao.Remover(id);
            return RedirectToAction("Index");
        }

        public IActionResult BuscaPorCategoria(string categoria)
        {
            return View("Index", dao.BuscaPorCategoria(categoria));
        }

        public IActionResult Publicar(int id)
        {
            dao.Publicar(id);
            return RedirectToAction("Index");
        }

        public IActionResult RetirarPublicacao(int id)
        {
            dao.RetirarPublicacao(id);
            return RedirectToAction("Index");
        }

        public IActionResult AutoCompleteCategoria(string termoDigitado)
        {
            return Json(dao.AutoCompleteCategoria(termoDigitado));
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //        ctx.Dispose();

        //    base.Dispose(disposing);
        //}
    }
}