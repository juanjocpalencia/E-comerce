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


        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create([Bind(Include = "producto,familia,descripcion,costo,capacidad,procesador,sistemaoperativo")] catalogo catalogonew)
        {
            db.catalogo.Add(catalogonew);
            db.SaveChanges();
            return RedirectToAction("Home", "catalogo");
        }

        public ActionResult Edit(int? id)
        {
            return View(db.catalogo.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_producto,producto,familia,descripcion,costo,capacidad,procesador,sistemaoperativo")] catalogo catalogonew)
        {

            db.Entry(catalogonew).State = System.Data.Entity.EntityState.Modified; 
            db.SaveChanges();
            return RedirectToAction("catalogo","Home");
        }

    }
}