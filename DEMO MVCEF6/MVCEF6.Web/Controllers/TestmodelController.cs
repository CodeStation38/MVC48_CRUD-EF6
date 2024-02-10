using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEF6.Model;

namespace MVCEF6.Web.Controllers
{
    public class TestmodelController : Controller
    {
        private MVCEF6Context db = new MVCEF6Context();

        // GET: Testmodel
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Testmodel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testmodel testmodel = db.Students.Find(id);
            if (testmodel == null)
            {
                return HttpNotFound();
            }
            return View(testmodel);
        }

        // GET: Testmodel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Testmodel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] Testmodel testmodel)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(testmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testmodel);
        }

        // GET: Testmodel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testmodel testmodel = db.Students.Find(id);
            if (testmodel == null)
            {
                return HttpNotFound();
            }
            return View(testmodel);
        }

        // POST: Testmodel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Testmodel testmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testmodel);
        }

        // GET: Testmodel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testmodel testmodel = db.Students.Find(id);
            if (testmodel == null)
            {
                return HttpNotFound();
            }
            return View(testmodel);
        }

        // POST: Testmodel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Testmodel testmodel = db.Students.Find(id);
            db.Students.Remove(testmodel);
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
