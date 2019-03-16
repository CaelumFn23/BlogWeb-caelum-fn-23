using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.Areas.Login.Models
{
    public class RegistroViewModel
    {


        [Required]
        [Display(Name = "Nome de usuário")]
        public string LoginName { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required]
        [Compare("Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação da senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}
