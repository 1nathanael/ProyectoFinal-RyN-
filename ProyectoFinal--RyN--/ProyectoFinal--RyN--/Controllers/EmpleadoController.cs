using System;
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
    public class EmpleadoController : Controller
    {
        private RecursosHumanosEntities db = new RecursosHumanosEntities();

        // GET: Empleado
        public ActionResult Index()
        {
            return View(db.Empleado.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.Id_Depto = new SelectList(db.Departamento, "Id_Depto", "Nombre_Depto");
            ViewBag.Id_Cargo = new SelectList(db.Cargo, "Id_Cargo", "Nombre_Cargo");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Empleado,Codigo_Empleado,Nombre_Empleado,Apellido,Telefono,Id_Depto,Id_Cargo,FechaIngreso,Salario,Status")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Depto = new SelectList(db.Departamento, "Id_Depto", "Nombre_Depto", empleado.Id_Depto);
            ViewBag.Id_Cargo = new SelectList(db.Cargo, "Id_Cargo", "Nombre_Cargo", empleado.Id_Cargo);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Depto = new SelectList(db.Departamento, "Id_Depto", "Nombre_Depto", empleado.Id_Depto);
            ViewBag.Id_Cargo = new SelectList(db.Cargo, "Id_Cargo", "Nombre_Cargo", empleado.Id_Cargo);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Empleado,Codigo_Empleado,Nombre_Empleado,Apellido,Telefono,Id_Depto,Id_Cargo,FechaIngreso,Salario,Status")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Depto = new SelectList(db.Departamento, "Id_Depto", "Nombre_Depto", empleado.Id_Depto);
            ViewBag.Id_Cargo = new SelectList(db.Cargo, "Id_Cargo", "Nombre_Cargo", empleado.Id_Cargo);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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

        //INFORMES

        public ActionResult EmpInactivos()
        {
            var empleados = db.Empleado.Where(x => x.Status == false).Include(c => c.Cargo).Include(d => d.Departamento);
            return View(empleados);
        }

        public ActionResult EmpActivos()
        {
            var empleados = db.Empleado.Where(x => x.Status == true).Include(c => c.Cargo).Include(d => d.Departamento);
            return View(empleados);
        }

        public ActionResult EntradaMes()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EntradaMesLista(int ano, int mes)
        {
            var empleados = db.Empleado.Where(x => x.FechaIngreso.Year == ano && x.FechaIngreso.Month == mes).Include(c => c.Cargo).Include(d => d.Departamento).ToList();
            if (empleados != null)
            {
                return View(empleados);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
