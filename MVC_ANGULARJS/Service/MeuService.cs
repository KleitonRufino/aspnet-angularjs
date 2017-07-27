using MVC_ANGULARJS.Infra;
using MVC_ANGULARJS.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_ANGULARJS.Service
{
    public class MeuService
    {
        MeuRepository repository = new MeuRepository();

        public void DeletePessoa(int id)
        {
            this.repository.DeletePessoa(id);
        }

        public List<Pessoa> GetAllPessoa()
        {
            return this.repository.GetAllPessoa();
        }

        public Pessoa GetBydPessoa(int id)
        {
            return this.repository.GetBydPessoa(id);
        }

        public void SavePessoa(Pessoa pessoa, List<Telefone> deleteTelefones)
        {
           if(pessoa.Id > 0)
            {
                if(deleteTelefones != null)
                {
                    foreach(Telefone t in deleteTelefones)
                    {
                        this.repository.DeleteTelefone(t.Id);
                    }
                }
                this.repository.UpdatePessoa(pessoa);
            }
            else
            {
                this.repository.SavePessoa(pessoa);
            }
        }
    }
}