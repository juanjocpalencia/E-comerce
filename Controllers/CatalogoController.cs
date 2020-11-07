using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_comerce.Models;


namespace E_comerce.Controllers
{
    public class CatalogoController : Controller
    {
        ecomerceEntities db = new ecomerceEntities();

        // GET: Catalogo
        public ActionResult Index()
        {
            return View(db.catalogo.ToList());
        }
    }
}