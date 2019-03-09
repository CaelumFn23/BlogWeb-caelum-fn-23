using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.Areas.Login.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Campo Usuário Obrigatório")]
        [Display(Name = "Usuário")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "Campo Senha Obrigatório")]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}
