using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SiteBD.Areas.Painel.Models
{
    public class Area
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}