using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWeb.DAO;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(PostDAO.BuscaPublicados());

        public IActionResult Busca(string texto) => View("Index", PostDAO.BuscaPublicadosBusca(texto));
    }
}