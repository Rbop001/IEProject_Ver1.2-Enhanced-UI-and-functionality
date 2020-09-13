using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NavigatingMelbourne.Models;

namespace NavigatingMelbourne.Controllers
{
    public class POIsController : Controller
    {
        private PointsOfInterestEntities db = new PointsOfInterestEntities();

        // GET: POIs
        public ActionResult Index()
        {
            return View(db.POIs.ToList());
        }

        // GET: POIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POI pOI = db.POIs.Find(id);
            if (pOI == null)
            {
                return HttpNotFound();
            }
            return View(pOI);
        }

        // GET: POIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: POIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Census_Year,Block_ID,Property_ID,Base_property_ID,Street_address,CLUE_small_area,Trading_name,Industry_ANZSIC4_code_,Industry_ANZSIC4_description,Seating_type,Number_of_seats__,x_coordinate,y_coordinate,Location")] POI pOI)
        {
            if (ModelState.IsValid)
            {
                db.POIs.Add(pOI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pOI);
        }

        // GET: POIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POI pOI = db.POIs.Find(id);
            if (pOI == null)
            {
                return HttpNotFound();
            }
            return View(pOI);
        }

        // POST: POIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Census_Year,Block_ID,Property_ID,Base_property_ID,Street_address,CLUE_small_area,Trading_name,Industry_ANZSIC4_code_,Industry_ANZSIC4_description,Seating_type,Number_of_seats__,x_coordinate,y_coordinate,Location")] POI pOI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pOI);
        }

        // GET: POIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POI pOI = db.POIs.Find(id);
            if (pOI == null)
            {
                return HttpNotFound();
            }
            return View(pOI);
        }

        // POST: POIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POI pOI = db.POIs.Find(id);
            db.POIs.Remove(pOI);
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
