using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcEmpDemo.Models;
using System.Net;
namespace MvcEmpDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpContext db = new EmpContext();

        // GET: Emp1
        public ActionResult Index()
        {

            return View(db.Employee.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = db.Employee.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude =  "id")] Employee emp)
        {
            if (ModelState.IsValid)
            {

                var name = (from data in db.Employee where data.EmpName == emp.EmpName select data);

                if (name.Count() > 0)
                {
                    ModelState.AddModelError("", "name already exists");
                }
                else
                {
                    db.Employee.Add(emp);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(emp);
        }
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = db.Employee.Find(id);
            
            if(emp==null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,city")] Employee emp)
        {
            if(ModelState.IsValid)
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = db.Employee.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee emp = db.Employee.Find(id);
            db.Employee.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}