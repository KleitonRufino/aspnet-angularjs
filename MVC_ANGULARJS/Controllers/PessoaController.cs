using MVC_ANGULARJS.Models;
using MVC_ANGULARJS.Service;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_ANGULARJS.Controllers
{
    public class PessoaController : Controller
    {
        private MeuService service = new MeuService();

        // GET: Pessoa
        public ActionResult Index()
        {
            var list = this.service.GetAllPessoa();
            ViewData["pessoas"] = JsonConvert.SerializeObject(list);
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.service.DeletePessoa(id);
            var list = this.service.GetAllPessoa();
            return Json(new
            {
                Value = JsonConvert.SerializeObject(list),
                Status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(Pessoa pessoa, List<Telefone> deleteTelefones)
        {
            this.service.SavePessoa(pessoa, deleteTelefones);
            var list = this.service.GetAllPessoa();
            return Json(new
            {
                Value = JsonConvert.SerializeObject(list),
                Status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}