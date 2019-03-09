using BlogWeb.Validacoes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogWeb.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(50)]
        [FilmeRambo]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo requirido")]
        public string Resumo { get; set; }
        public string Categoria { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public bool Publicado { get; set; }
    }
}
