using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NavigatingMelbourne.Models;

namespace NavigatingMelbourne.Controllers
{
    public class ExploreMelbourneController : Controller
    {
        private PointsOfInterestEntities db = new PointsOfInterestEntities();

        public ActionResult Index()
        {
            return View (db.Categories.ToList());
        }

        public ActionResult Popular(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Category category = db.Categories.Find(id);
            List<POI> pois = db.POIs.Where(x => x.CategoryId.HasValue && x.CategoryId.Value == id && x.Popular.HasValue && x.Popular == true).ToList();

            dynamic result = new ExpandoObject();
            result.Category = category;
            result.POIs = pois;
            return View(result);
        }

        public ActionResult POIs(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            List<POI> pois = db.POIs.Where(x => x.CategoryId.HasValue && x.CategoryId.Value == id).ToList();

            dynamic result = new ExpandoObject();
            result.Category = category;
            result.POIs = pois;
            return View(result);
        }


        public ActionResult POIDetails(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POI POI = db.POIs.Find(id);
            if (POI == null)
            {
                return HttpNotFound();
            }
            return View(POI);
        }
    }
}