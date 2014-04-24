using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteBD.Areas.Industria.Controllers
{
    public class IndustriaController : Controller
    {
        //
        // GET: /Industria/Industria/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditarEmpresa()
        {
            return View();
        }
        public ActionResult DeletarEmpresa()
        {
            return View();
        }

        public ActionResult CadastrarEmpresa()
        {
            return View();
        }
	}
}