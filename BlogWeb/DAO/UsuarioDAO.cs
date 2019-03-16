using BlogWeb.Infra;
using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.DAO
{
    public class UsuarioDAO
    {
        protected readonly BlogContext ctx;

        public UsuarioDAO(BlogContext context)
        {
            ctx = context;
        }

        public bool HasDuplicidade(string login)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Login.Equals(login)) != null ? true : false;
        }

        public void Adiciona(Usuario obj)
        {
            ctx.Add(obj);
            ctx.SaveChanges();
        }

        public Usuario BuscaPorLoginSenha(string login, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Senha.Equals(senha) && x.Login.Equals(login));
        }
    }
}
