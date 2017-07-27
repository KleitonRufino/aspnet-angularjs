using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ANGULARJS.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Telefone> Telefones { get; set; }
        [NotMapped]
        public string Numeros
        {
            get
            {
                var telefone = "";
                if (Telefones != null)
                {
                    var count = 0;
                    foreach (Telefone t in Telefones)
                    {
                        telefone = telefone +  t.Numero;
                        if (count + 1 < Telefones.Count)
                        {
                            telefone = telefone + " - ";
                        }
                        count++;
                    }
                }
                return telefone;
            }
        }
    }
}