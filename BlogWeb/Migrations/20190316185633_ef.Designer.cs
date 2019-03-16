﻿// <auto-generated />
using System;
using BlogWeb.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogWeb.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20190316185633_ef")]
    partial class ef
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogWeb.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AutorId");

                    b.Property<string>("Categoria");

                    b.Property<DateTime?>("DataPublicacao");

                    b.Property<bool>("Publicado");

                    b.Property<string>("Resumo")
                        .IsRequired();

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogWeb.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BlogWeb.Models.Post", b =>
                {
                    b.HasOne("BlogWeb.Models.Usuario", "Autor")
                        .WithMany("Posts")
                        .HasForeignKey("AutorId");
                });
#pragma warning restore 612, 618
        }
    }
}
