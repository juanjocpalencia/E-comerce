using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "producto,familia,descripcion,costo,capacidad,procesador,sistemaoperativo")] catalogo catalogonew, HttpPostedFileBase ruta_imagen)
        {
            if (ruta_imagen != null && ruta_imagen.ContentLength > 0)
            {
                try
                {
                    /*Guardar archivo */
                    string path = Path.Combine(Server.MapPath("~/Archivos/Sistemas/" ), Path.GetFileName(ruta_imagen.FileName));
                    System.IO.Directory.CreateDirectory((Server.MapPath("~/Archivos/Sistemas/")));
                    ruta_imagen.SaveAs(path);
                    System.Diagnostics.Debug.WriteLine("Archivo guardado");
                    var ruta = "../Archivos/Sistemas/" + ruta_imagen.FileName;
                    catalogonew.foro = ruta;
                }
                catch (Exception e)
                {

                }
            }
            db.catalogo.Add(catalogonew);
            db.SaveChanges();
            return RedirectToAction("Index", "catalogo");
        }

        public ActionResult Edit(int? id)
        {
            return View(db.catalogo.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_producto,producto,familia,descripcion,costo,capacidad,procesador,sistemaoperativo")] catalogo catalogonew ,HttpPostedFileBase ruta_imagen)
        {
            if (ruta_imagen != null && ruta_imagen.ContentLength > 0)
            {
                try
                {
                    /*Guardar archivo */
                    string path = Path.Combine(Server.MapPath("~/Archivos/Sistemas/"), Path.GetFileName(ruta_imagen.FileName));
                    System.IO.Directory.CreateDirectory((Server.MapPath("~/Archivos/Sistemas/")));
                    ruta_imagen.SaveAs(path);
                    System.Diagnostics.Debug.WriteLine("Archivo guardado");
                    var ruta = "../Archivos/Sistemas/" + ruta_imagen.FileName;
                    catalogonew.foro = ruta;
                }
                catch (Exception e)
                {

                }
            }
            db.Entry(catalogonew).State = System.Data.Entity.EntityState.Modified; 
            db.SaveChanges();
            return RedirectToAction("Index", "catalogo");
        }

        public ActionResult comprar(int? id)
        {
            return View(db.catalogo.Find(id));
        }

    }
}