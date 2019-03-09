using BlogWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.Infra
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {

        }

        public DbSet<Post> Posts{ get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .AddEnvironmentVariables();
        //    IConfiguration configuration = builder.Build();
        //    string connectionString = configuration.GetConnectionString("Blog");

        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
