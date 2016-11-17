using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationLab.Models;

namespace WebApplicationLab.Controllers
{
    public class MobilesController : Controller
    {
        private HelpDeskContext db = new HelpDeskContext();

        // GET: Mobiles
        public ActionResult Index()
        {
            var mobiles = db.Mobiles.Include(m => m.battery).Include(m => m.color).Include(m => m.producer);
            return View(mobiles.ToList());
        }

        // GET: Mobiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobile mobile = db.Mobiles.Find(id);
            if (mobile == null)
            {
                return HttpNotFound();
            }
            return View(mobile);
        }

        // GET: Mobiles/Create
        public ActionResult Create()
        {
            ViewBag.BatteryId = new SelectList(db.Batterys, "Id", "Id");
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name");
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name");
            return View();
        }

        // POST: Mobiles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date,Camera,Price,Image,ProducerId,BatteryId,ColorId")] Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                db.Mobiles.Add(mobile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BatteryId = new SelectList(db.Batterys, "Id", "Id", mobile.BatteryId);
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", mobile.ColorId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", mobile.ProducerId);
            return View(mobile);
        }

        // GET: Mobiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobile mobile = db.Mobiles.Find(id);
            if (mobile == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatteryId = new SelectList(db.Batterys, "Id", "Id", mobile.BatteryId);
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", mobile.ColorId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", mobile.ProducerId);
            return View(mobile);
        }

        // POST: Mobiles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date,Camera,Price,Image,ProducerId,BatteryId,ColorId")] Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatteryId = new SelectList(db.Batterys, "Id", "Id", mobile.BatteryId);
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", mobile.ColorId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", mobile.ProducerId);
            return View(mobile);
        }

        // GET: Mobiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobile mobile = db.Mobiles.Find(id);
            if (mobile == null)
            {
                return HttpNotFound();
            }
            return View(mobile);
        }

        // POST: Mobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mobile mobile = db.Mobiles.Find(id);
            db.Mobiles.Remove(mobile);
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
