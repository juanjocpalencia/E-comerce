using E_comerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_comerce.Controllers
{
    public class HomeController : Controller
    {
        ecomerceEntities db = new ecomerceEntities();
        public ActionResult Index(string buscar)
        {
            ViewBag.familias = db.catalogo.Select(s => s.familia).Distinct().ToList();
            if (buscar == null)
            {
                return View(db.catalogo.ToList());
            }
            else
            {
                var busqueda = from catalogo in db.catalogo
                               where catalogo.sistemaOperativo.Contains(buscar)
                               || catalogo.descripcion.Contains(buscar)
                               || catalogo.procesador.Contains(buscar)
                               ||catalogo.familia.Contains(buscar)
                               select catalogo;
                return View(busqueda.ToList());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}