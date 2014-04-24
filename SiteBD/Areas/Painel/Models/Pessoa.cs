using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteBD.Areas.Painel.Models;
using System.ComponentModel.DataAnnotations;

namespace SiteBD.Areas.Painel.Models
{
    public class Pessoa
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}