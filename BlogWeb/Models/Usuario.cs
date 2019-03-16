using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.Models
{
    public class Usuario
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string  Login { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public DateTime DataAlteracao { get; set; }

        public IList<Post> Posts { get; set; }
    }
}
