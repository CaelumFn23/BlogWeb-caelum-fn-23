using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWeb.Areas.Login.Models;
using BlogWeb.DAO;
using BlogWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogWeb.Areas.Login.Controllers
{
    [Area("login")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO dao)
        {
            usuarioDAO = dao;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        public ActionResult Autentica(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var user = usuarioDAO.BuscaPorLoginSenha(senha: obj.Password, login: obj.LoginName);
                if (user != null)
                {
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(user));

                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                }
                else
                    ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
            }

            return View("Login", obj);
        }

        public IActionResult Cadastra()
        {
            return View(new RegistroViewModel());
        }

        [HttpPost]
        public IActionResult Cadastra(RegistroViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Senha.Equals(obj.ConfirmacaoSenha))
                {
                    if (usuarioDAO.HasDuplicidade(obj.LoginName))
                    {
                        ModelState.AddModelError("Duplicidade", "Existe um usuário com esse login");
                    }
                    else
                    {
                        Usuario usuario = new Usuario()
                        {
                            Nome = obj.Name,
                            Login = obj.LoginName,
                            Email = obj.Email,
                            Senha = obj.Senha
                        };

                        usuarioDAO.Adiciona(usuario);

                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    ModelState.AddModelError("senhaErrada", "As senhas não são compatíveis");
                }
            }

            return View("Cadastra", obj);
        }
    }
}