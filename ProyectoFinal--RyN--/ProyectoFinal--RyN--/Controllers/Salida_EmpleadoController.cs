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
    public class Salida_EmpleadoController : Controller
    {
        private RecursosHumanosEntities db = new RecursosHumanosEntities();

        // GET: Salida_Empleado
        public ActionResult Index()
        {
            return View(db.Salida_Empleado.ToList());
        }

        // GET: Salida_Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleado salida_Empleado = db.Salida_Empleado.Find(id);
            if (salida_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(salida_Empleado);
        }

        // GET: Salida_Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salida_Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Salida,Id_Empleado,Tipo_Salida,Motivo,Fecha_Salida")] Salida_Empleado salida_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Salida_Empleado.Add(salida_Empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salida_Empleado);
        }

        // GET: Salida_Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleado salida_Empleado = db.Salida_Empleado.Find(id);
            if (salida_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(salida_Empleado);
        }

        // POST: Salida_Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Salida,Id_Empleado,Tipo_Salida,Motivo,Fecha_Salida")] Salida_Empleado salida_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida_Empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salida_Empleado);
        }

        // GET: Salida_Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleado salida_Empleado = db.Salida_Empleado.Find(id);
            if (salida_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(salida_Empleado);
        }

        // POST: Salida_Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salida_Empleado salida_Empleado = db.Salida_Empleado.Find(id);
            db.Salida_Empleado.Remove(salida_Empleado);
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