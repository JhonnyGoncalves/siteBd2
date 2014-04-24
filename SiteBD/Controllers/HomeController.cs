using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using SiteBD.Models;

namespace SiteBD.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Seach seach)
        {
            if(seach.Aux !=null)
            {
                return RedirectToAction("Busca", seach);
            }
            return View();
        }
        public ActionResult Busca(Seach seach) 
        {
            return View(seach);
        }
	}
}