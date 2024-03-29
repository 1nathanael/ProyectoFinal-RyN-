﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal__RyN__.Models;

namespace ProyectoFinal__RyN__.Controllers
{
    public class LicenciaController : Controller
    {
        private RecursosHumanosEntities db = new RecursosHumanosEntities();

        // GET: Licencia
        public ActionResult Index()
        {
            var Licencia = db.Licencia.Include(l => l.Empleado);

            return View(Licencia.ToList());
        }

        // GET: Licencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencia licencia = db.Licencia.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            return View(licencia);
        }

        // GET: Licencia/Create
        public ActionResult Create()
        {
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "Id_Empleado", "Nombre_Empleado");
            return View();
        }

        // POST: Licencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Licensia,Id_Empleado,Inicio_Licencia,Fin_Licencia,Motivo,Comentario")] Licencia licencia)
        {
            if (ModelState.IsValid)
            {
                db.Licencia.Add(licencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "Id_Empleado", "Codigo_Empleado", licencia.Id_Empleado);
            return View(licencia);
        }

        // GET: Licencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencia licencia = db.Licencia.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "Id_Empleado", "Nombre_Empleado", licencia.Id_Empleado);
            return View(licencia);
        }

        // POST: Licencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Licensia,Id_Empleado,Inicio_Licencia,Fin_Licencia,Motivo,Comentario")] Licencia licencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "Id_Empleado", "Nombre_Empleado", licencia.Id_Empleado);
            return View(licencia);
        }

        // GET: Licencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencia licencia = db.Licencia.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            return View(licencia);
        }

        // POST: Licencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Licencia licencia = db.Licencia.Find(id);
            db.Licencia.Remove(licencia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
