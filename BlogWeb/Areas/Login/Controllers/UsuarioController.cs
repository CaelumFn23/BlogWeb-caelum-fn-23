using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWeb.Areas.Login.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Login.Controllers
{
    [Area("login")]
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        public ActionResult Autentica(LoginViewModel obj)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index", "Post", new { area = "Admin" });
            }

            return View("Login", obj);
        }
    }
}