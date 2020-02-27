using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using System.Data.Entity;

namespace MVCCrud.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            using (testEntities dbmodels = new testEntities())
            {
                return View(dbmodels.Employees.ToList());
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            using (testEntities dbmodels = new testEntities())
            {
                return View(dbmodels.Employees.Where(x=>x.Empid==id).FirstOrDefault());
            }
                
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                // TODO: Add insert logic here
                using (testEntities dbmodel = new testEntities())
                {
                    dbmodel.Employees.Add(emp);
                    dbmodel.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            using (testEntities dbmodels = new testEntities())
            {
                return View(dbmodels.Employees.Where(x => x.Empid==id).FirstOrDefault());
            }
                
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                using (testEntities dbmodel = new testEntities())
                {
                    dbmodel.Entry(emp).State = EntityState.Modified;
                    dbmodel.SaveChanges();
                }
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (testEntities dbmodels = new testEntities())
            {
                return View(dbmodels.Employees.Where(x => x.Empid == id).FirstOrDefault());
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            try
            {
                using (testEntities dbmodel = new testEntities())
                {
                    Employee empp = dbmodel.Employees.Where(x => x.Empid == id).FirstOrDefault();
                    dbmodel.Employees.Remove(empp);
                    dbmodel.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
