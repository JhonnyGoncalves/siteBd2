using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteBD.Areas.Painel.Models;
using System.Data.SqlClient;
using SiteBD.Repositorio;
using SiteBD.Aplicacao;

namespace SiteBD.Areas.Painel.Controllers
{
    public class InicioController : Controller
    {
        private readonly AreaAplicacao areaaplicacao;
        private readonly EmpresaAplicacao empresaaplicacao;
        public InicioController()
        {
            areaaplicacao = new AreaAplicacao();
            empresaaplicacao = new EmpresaAplicacao();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Pessoa pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Nome) || string.IsNullOrEmpty(pessoa.Senha))
            {
                return View();
            }

            else if(pessoa.Nome.Equals("marcos") && pessoa.Senha.Equals("123"))
            {
               return RedirectToAction("PainelControle", pessoa);
            }
            return View();
        }
        public ActionResult PainelControle(Pessoa pessoa)

        {
            ViewBag.nome = pessoa.Nome;
            return View(empresaaplicacao.Listar());
        }
        public ActionResult Detalhe(int id)
        {
            
            return View(empresaaplicacao.ListarporId(id));
        }
        public ActionResult Excluir(int id) 
        {
            empresaaplicacao.Excluir(id);
            return RedirectToAction("PainelControle");
        }
        public ActionResult Cadastrar()
        {
            
            ViewBag.listaDeAreas = areaaplicacao.Listar();
            return View(new Empresa());
        }
        [HttpPost]
        public ActionResult Cadastrar(Empresa empresa)
        {
            if(ModelState.IsValid)
            {
                empresaaplicacao.Salvar(empresa);
                return RedirectToAction("PainelControle");
            }
            ViewBag.listaDeAreas = areaaplicacao.Listar();
            return View(empresa);
        }
        public ActionResult Editar(int id)
        {
            ViewBag.listaDeAreas = areaaplicacao.Listar();
            return View(empresaaplicacao.ListarporId(id));
        }
        [HttpPost]
        public ActionResult Editar(Empresa empresa)
        {

            if (ModelState.IsValid)
            {
                empresaaplicacao.Alterar(empresa);
                return RedirectToAction("PainelControle");
            }
            ViewBag.listaDeAreas = areaaplicacao.Listar();
            return View(empresa);
        }
        public ActionResult CadastroArea()
                        {
            return View(new Area());
        }
        [HttpPost]
        public ActionResult CadastroArea(Area area)
        {
            if (ModelState.IsValid)
            {
                areaaplicacao.Salvar(area);
                return RedirectToAction("ListaCategoria");
            }
            return View(area);
        }
        public ActionResult ListaCategoria()
        {

            return View(areaaplicacao.Listar());
        }
        public ActionResult ExcluirArea(int id)
        {
            areaaplicacao.Excluir(id);
          return  RedirectToAction("ListaCategoria");
        }
        public ActionResult DetalheArea(int id)
        {
            return View(areaaplicacao.ListarporId(id));
        }
        public ActionResult EditarArea(int id) 
        {
            return View(areaaplicacao.ListarporId(id));
        }
        [HttpPost]
        public ActionResult EditarArea(Area area) 
        {
            if(ModelState.IsValid)
            {
                areaaplicacao.Alterar(area);
                return RedirectToAction("ListaCategoria");
            }
            return View(area);
        }
	}
}