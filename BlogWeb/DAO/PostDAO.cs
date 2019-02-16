﻿using BlogWeb.Infra;
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
        public static IEnumerable<Post> Lista()
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
            using (BlogContext ctx = new BlogContext())
            {
                return ctx.Posts.ToList();
            }
            
        }

        public static Post FirstOrDefault(int id)
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

            using (BlogContext ctx = new BlogContext())
            {
                return ctx.Posts.FirstOrDefault(x => x.Id == id);
            }
        }

        public static void Editar(Post p)
        {
            //using (SqlConnection conexao = ConnectionFactory.CriaConexaoAberta())
            //{
            //    SqlCommand cmd = conexao.CreateCommand();
            //    cmd.CommandText = "UPDATE Post SET Titulo = '" + p.Titulo + "', Resumo = '" + p.Resumo + "', Categoria = '" + p.Categoria + "' WHERE Id =" + p.Id;
            //    cmd.ExecuteNonQuery();
            //}

            using (BlogContext ctx = new BlogContext())
            {
                ctx.Posts.Update(p);
                //ctx.Entry(p).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public static void Adiciona(Post p)
        {
            //using (SqlConnection conexao = ConnectionFactory.CriaConexaoAberta())
            //{
            //    SqlCommand cmd = conexao.CreateCommand();
            //    cmd.CommandText = "INSERT INTO Post VALUES ('" + p.Titulo + "','" + p.Resumo + "','" + p.Categoria + "')";
            //    cmd.ExecuteNonQuery();
            //}
            using (BlogContext ctx = new BlogContext())
            {
                ctx.Posts.Add(p);
                ctx.SaveChanges();
            }
        }

        public static void Remover(int id)
        {
            //using (SqlConnection conexao = ConnectionFactory.CriaConexaoAberta())
            //{
            //    SqlCommand cmd = conexao.CreateCommand();
            //    cmd.CommandText = "DELETE FROM Post WHERE Id = " + id;
            //    cmd.ExecuteNonQuery();
            //}

            using (BlogContext ctx = new BlogContext())
            {
                var obj = ctx.Posts.FirstOrDefault(x => x.Id == id);
                if (obj != null)
                {
                    ctx.Posts.Remove(obj);
                    ctx.SaveChanges();
                }
            }
        }

        public static IEnumerable<Post> BuscaPorCategoria(string categoria)
        {
            using (BlogContext ctx = new BlogContext())
            {
                return ctx.Posts.Where(x => x.Categoria.Contains(categoria)).ToList();
            }
        }
    }
}