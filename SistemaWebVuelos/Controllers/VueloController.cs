using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;

namespace SistemaWebVuelos.Controllers
{
    public class VueloController : Controller
    {
        VueloDbContext context = new VueloDbContext();
        // GET: Vuelo
        public ActionResult Index()
        {
            var vuelos = context.Vuelos.ToList();
            return View("Index", vuelos);
        }

        [HttpGet] 
        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();

            return View("Create", vuelo);
        }

        [HttpPost]
        public ActionResult Create(Vuelo v)
        {
            if(ModelState.IsValid)
            {
                context.Vuelos.Add(v);
                context.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View("Create", v);
        }

        public ActionResult Detail(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            if (vuelo != null)
            {
                return View("Delete", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelo v = context.Vuelos.Find(id); 
            context.Vuelos.Remove(v);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BuscarPorDestino(string destino)
        {
            if (destino == "")
            {
                return RedirectToAction("Index");
            }
            List<Vuelo> vuelos = (from v in context.Vuelos
                                      where v.Destino == destino
                                      select v).ToList();
            return View("Index", vuelos);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Vuelo v = context.Vuelos.Find(id);
            if (v != null)
            {
                return View("Edit", v);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Vuelo v)
        {
            if (ModelState.IsValid)
            {
                context.Entry(v).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", v);
        }
    }
}