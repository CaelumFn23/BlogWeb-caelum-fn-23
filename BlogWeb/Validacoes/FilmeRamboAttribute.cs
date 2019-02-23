using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.Validacoes
{
    public class FilmeRamboAttribute : ValidationAttribute
    {
        public FilmeRamboAttribute() : base("Fora Rambo")
        {

        }

        public override bool IsValid(object titulo) => titulo != null ? titulo.ToString() == "Rambo" ?  false :  true : false;
    }
}
