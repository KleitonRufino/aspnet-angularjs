using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ANGULARJS.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }
        public string Numero { get; set; }
    }
}