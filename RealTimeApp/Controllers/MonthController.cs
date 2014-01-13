using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealTimeApp.Models;
using RealTimeApp.DAL;

namespace RealTimeApp.Controllers
{
    public class MonthController : Controller
    {
        private TimeContext db = new TimeContext();

        //
        // GET: /Month/

        public ActionResult Index()
        {
            return View(db.Months.ToList());
        }

        //
        // GET: /Month/Details/5

        public ActionResult Details(int id = 0)
        {
            Month month = db.Months.Find(id);
            if (month == null)
            {
                return HttpNotFound();
            }
            return View(month);
        }

        //
        // GET: /Month/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Month/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Month month)
        {
            if (ModelState.IsValid)
            {
                db.Months.Add(month);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(month);
        }

        //
        // GET: /Month/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Month month = db.Months.Find(id);
            if (month == null)
            {
                return HttpNotFound();
            }
            return View(month);
        }

        //
        // POST: /Month/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Month month)
        {
            if (ModelState.IsValid)
            {
                db.Entry(month).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(month);
        }

        //
        // GET: /Month/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Month month = db.Months.Find(id);
            if (month == null)
            {
                return HttpNotFound();
            }
            return View(month);
        }

        //
        // POST: /Month/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Month month = db.Months.Find(id);
            db.Months.Remove(month);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}