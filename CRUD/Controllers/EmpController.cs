using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.DAL;

namespace CRUD.Controllers
{
    public class EmpController : Controller
    {
        Dal db = new Dal();
        // GET: Emp
        public ActionResult Index()
        {
            return View(db.Getemp().ToList());
        }

        // GET: Emp/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Getemp().Find(x=>x.Empid==id));
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(Emp_Model em)
        {
            try
            {
                // TODO: Add insert logic here
                db.Add(em);
                

                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Getemp().Find(x => x.Empid == id));
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(Emp_Model em)
        {
            try
            {
                // TODO: Add update logic here
                db.Emp_Update(em);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Getemp().Find(x => x.Empid == id));
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Emp_Model em)
        {
            try
            {
                // TODO: Add delete logic here
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
