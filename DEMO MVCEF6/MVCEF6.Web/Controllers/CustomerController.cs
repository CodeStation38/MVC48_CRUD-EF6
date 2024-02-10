using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEF6.Model;
using MVCEF6.BL;

namespace MVCEF6.Web.Controllers
{
    public class CustomerController : Controller
    {
        private MVCEF6Context db = new MVCEF6Context();

        // GET: Customer
        public ActionResult Index(string prefColor, string mainHobbyString, string SearchString)
        {

            var customerManager = new CustomerManager();

            //PREFCOLOR DROPDOWNLIST
            var PrefColorLst = new List<string>();
            var PrefColorQry = customerManager.GetCustomersByPrefColor();


            //LOAD PREFCOLOR DDL
            PrefColorLst.AddRange(PrefColorQry.Distinct());
            ViewBag.prefColor = new SelectList(PrefColorLst);

            //MAINHOBBY DROPDOWNLIST
            var MainHobbyLst = new List<string>();
            var MainHobbyQry = customerManager.GetCustomersByMainHobby();

            //LOAD MAINHOBBY DDL
            MainHobbyLst.AddRange(MainHobbyQry.Distinct());
            ViewBag.mainHobbyString = new SelectList(MainHobbyLst);


            //CUSTOMERS DATASET
            var customersls = customerManager.GetAllCustomers();

            //FILTER BY BIRTHDATE
            //var customersBirthDate = customerManager.GetCustomersByBirthDate(SearchString);

            //FILTER BY NUMBER OF ROOMS
            //var customersNumberOfRooms = customerManager.GetCustomersByNumberOfRooms(SearchString);

            //GRID: POSSIBLE FILTER RESULTS

            if (customerManager.StringIsDate(SearchString) != null)
            {
                customersls = customersls.Where(s => s.Birthday == DateTime.Parse(SearchString)).ToList();
            }

            // TERMINAR StringIsNumber!!!
            if (customerManager.StringIsNumber(SearchString))
            {
                customersls = customersls.Where(s => s.NumberOfRooms == Int32.Parse(SearchString)).ToList();
            }
            if (!string.IsNullOrEmpty(mainHobbyString))
            {
                customersls = customersls.Where(x => x.MainHobby.Contains(mainHobbyString)).ToList();
            }

            if (!string.IsNullOrEmpty(prefColor))
            {
                customersls = customersls.Where(x => x.PrefferedColor.Contains(prefColor)).ToList();
            }

            return View(customersls);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Birthday,PrefferedColor,MainHobby,SSN,NumberOfRooms")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Birthday,PrefferedColor,MainHobby,SSN,NumberOfRooms")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
