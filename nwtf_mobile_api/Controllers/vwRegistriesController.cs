using nwtf_mobile_api.Data;
using nwtf_mobile_api.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace nwtf_mobile_api.Controllers
{
    public class vwRegistriesController : Controller
    {
        private nwtf_mobile_apidbContext db = new nwtf_mobile_apidbContext();

        // GET: vwRegistries
        public ActionResult Index()
        {
            return View(db.vwRegistries.ToList());
        }

        // GET: vwRegistries/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwRegistry vwRegistry = db.vwRegistries.Find(id);
            if (vwRegistry == null)
            {
                return HttpNotFound();
            }
            return View(vwRegistry);
        }

        // GET: vwRegistries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vwRegistries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,registry,entry")] vwRegistry vwRegistry)
        {
            if (ModelState.IsValid)
            {
                vwRegistry.id = Guid.NewGuid();
                db.vwRegistries.Add(vwRegistry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vwRegistry);
        }

        // GET: vwRegistries/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwRegistry vwRegistry = db.vwRegistries.Find(id);
            if (vwRegistry == null)
            {
                return HttpNotFound();
            }
            return View(vwRegistry);
        }

        // POST: vwRegistries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,registry,entry")] vwRegistry vwRegistry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vwRegistry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vwRegistry);
        }

        // GET: vwRegistries/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwRegistry vwRegistry = db.vwRegistries.Find(id);
            if (vwRegistry == null)
            {
                return HttpNotFound();
            }
            return View(vwRegistry);
        }

        // POST: vwRegistries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            vwRegistry vwRegistry = db.vwRegistries.Find(id);
            db.vwRegistries.Remove(vwRegistry);
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
