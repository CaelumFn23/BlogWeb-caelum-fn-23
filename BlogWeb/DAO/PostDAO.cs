using BlogWeb.Infra;
using BlogWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.DAO
{
    public class PostDAO
    {
        public PostDAO(BlogContext ctx)
        {
            this.ctx = ctx;
        }

        private BlogContext ctx;

        public IEnumerable<Post> Lista()
        {
            //using (SqlConnection conexao = ConnectionFactory.CriaConexaoAberta())
            //{
            //    SqlCommand cmd = conexao.CreateCommand();
            //    cmd.CommandText = "SELECT Id, Titulo, Resumo, Categoria FROM Post";

            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        lista.Add(
            //            new Post()
            //            {
            //                Id = Convert.ToInt32(reader["Id"]),
            //                Titulo = reader["Titulo"].ToString(),
            //                Resumo = reader["Resumo"].ToString(),
            //                Categoria = reader["Categoria"].ToString()
            //            });
            //    }
            //}

            return ctx.Posts.ToList();
        }

        public Post FirstOrDefault(int id)
        {
            //using (SqlConnection conexao = ConnectionFactory.CriaConexaoAberta())
            //{
            //    SqlCommand cmd = conexao.CreateCommand();
            //    cmd.CommandText = "SELECT Id, Titulo, Resumo, Categoria FROM Post WHERE Id =" + id;

            //    SqlDataReader reader = cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        return new Post() { Id = Convert.ToInt32(reader["Id"]), Titulo = reader["Titulo"].ToString(), Resumo = reader["Resumo"].ToString(), Categoria = reader["Categoria"].ToString() };
            //    }
            //    return new Post();
            //}

            return ctx.Posts.FirstOrDefault(x => x.Id == id);
        }

        public void Editar(Post p)
        {
            //using (SqlConnection conexao = ConnectionFactory.CriaConexaoAberta())
            //{
            //    SqlCommand cmd = conexao.CreateCommand();
            //    cmd.CommandText = "UPDATE Post SET Titulo = '" + p.Titulo + "', Resumo = '" + p.Resumo + "', Categoria = '" + p.Categoria + "' WHERE Id =" + p.Id;
            //    cmd.ExecuteNonQuery();
            //}

            ctx.Posts.Update(p);
            //ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Adiciona(Post p)
        {
            //using (SqlConnection conexao = ConnectionFactory.CriaConexaoAberta())
            //{
            //    SqlCommand cmd = conexao.CreateCommand();
            //    cmd.CommandText = "INSERT INTO Post VALUES ('" + p.Titulo + "','" + p.Resumo + "','" + p.Categoria + "')";
            //    cmd.ExecuteNonQuery();
            //}

            ctx.Posts.Add(p);
            ctx.SaveChanges();
        }

        public void Remover(int id)
        {
            //using (SqlConnection conexao = ConnectionFactory.CriaConexaoAberta())
            //{
            //    SqlCommand cmd = conexao.CreateCommand();
            //    cmd.CommandText = "DELETE FROM Post WHERE Id = " + id;
            //    cmd.ExecuteNonQuery();
            //}

            var obj = ctx.Posts.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                ctx.Posts.Remove(obj);
                ctx.SaveChanges();
            }

        }

        public IEnumerable<Post> BuscaPorCategoria(string categoria)
        {
            return ctx.Posts.Where(x => x.Categoria.Contains(categoria)).ToList();
        }

        public void Publicar(int id)
        {
            var obj = ctx.Posts.Find(id);
            obj.Publicado = true;
            obj.DataPublicacao = DateTime.Now;
            ctx.SaveChanges();
        }

        public void RetirarPublicacao(int id)
        {
            var obj = ctx.Posts.Find(id);
            obj.Publicado = false;
            ctx.SaveChanges();
        }

        public IList<string> AutoCompleteCategoria(string categoria)
        {
            return ctx.Posts.Where(x => x.Categoria.Contains(categoria)).Select(x => x.Categoria).Distinct().ToList();
        }

        public IList<Post> BuscaPublicados()
        {
            return ctx.Posts.Where(p => p.Publicado).OrderByDescending(p => p.DataPublicacao).ToList();
        }

        public IList<Post> BuscaPublicadosBusca(string texto)
        {
            return ctx.Posts.Where(p => p.Publicado && (p.Titulo.Contains(texto) || p.Resumo.Contains(texto))).OrderByDescending(p => p.DataPublicacao).ToList();
        }

        
    }
}
