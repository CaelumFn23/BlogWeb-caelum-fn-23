using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BlogWeb.DAO;
using BlogWeb.Infra;
using BlogWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers
{
    public class PostController : Controller
    {


        public IActionResult Index()
        {
            return View(PostDAO.Lista());
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
                PostDAO.Adiciona(p);
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
            return View(PostDAO.FirstOrDefault(id));
        }

        [HttpPost]
        public IActionResult Editar(Post p)
        {
            if (ModelState.IsValid)
            {
                PostDAO.Editar(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Visualiza", p);
            }
        }

        public IActionResult Remover(int id)
        {
            PostDAO.Remover(id);
            return RedirectToAction("Index");
        }

        public IActionResult BuscaPorCategoria(string categoria)
        {
            return View("Index", PostDAO.BuscaPorCategoria(categoria));
        }

        public IActionResult Publicar(int id)
        {
            PostDAO.Publicar(id);
            return RedirectToAction("Index");
        }

        public IActionResult RetirarPublicacao(int id)
        {
            PostDAO.RetirarPublicacao(id);
            return RedirectToAction("Index");
        }

        public IActionResult AutoCompleteCategoria(string termoDigitado)
        {
            return Json(PostDAO.AutoCompleteCategoria(termoDigitado));
        }
    }
}