using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SiteBD.Areas.Painel.Models
{
    public class Empresa
    {
        [Required]
        public int idEmpresa { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Endereco { get; set; }
        public int idArea { get; set; }
        public string Area { get; set; }
    }
}