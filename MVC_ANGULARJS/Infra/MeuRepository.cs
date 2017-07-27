using System.Collections.Generic;
using MVC_ANGULARJS.Models;
using System.Linq;
using System.Data.Entity;

namespace MVC_ANGULARJS.Infra
{
    public class MeuRepository 
    {
        private MyContext ctx = new MyContext();

        public void DeletePessoa(int id)
        {
            Pessoa p = GetBydPessoa(id);
            ctx.Pessoas.Remove(p);
            ctx.SaveChanges();
        }

        public List<Pessoa> GetAllPessoa()
        {
            //Save(new Pessoa() { Nome = "Kleiton" });
            var l = ctx.Pessoas.ToList();
            return ctx.Pessoas.Include("Telefones").ToList();
        }

        public Pessoa GetBydPessoa(int id)
        {
            return ctx.Pessoas.Where(p => p.Id == id).Include(p => p.Telefones).FirstOrDefault();
        }

        public void SavePessoa(Pessoa pessoa)
        {
            ctx.Pessoas.Add(pessoa);
            ctx.SaveChanges();
        }

        public void UpdatePessoa(Pessoa pessoa)
        {
            ctx.Pessoas.Attach(pessoa);
            ctx.Entry(pessoa).State = EntityState.Modified;

           
            if (pessoa.Telefones != null)
            {
                foreach (Telefone t in pessoa.Telefones)
                {
                    if (t.Id > 0)
                    {
                        ctx.Telefones.Attach(t);
                        ctx.Entry(t).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(t).State = EntityState.Added;
                    }
                }
            }
            ctx.SaveChanges();
        }

        public void DeleteTelefone(int id)
        {
            Telefone t = GetByIdTelefone(id);
            ctx.Telefones.Remove(t);
        }

        public Telefone GetByIdTelefone(int id)
        {
            return ctx.Telefones.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}