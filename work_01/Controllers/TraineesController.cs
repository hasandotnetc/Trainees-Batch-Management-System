using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using work_01.Models;

namespace work_01.Controllers
{
    public class TraineesController : Controller
    {
        private readonly TraineeDbContext db;
        public TraineesController(TraineeDbContext db)
        {
            this.db = db;  
        }
        public IActionResult Index()
        {
            return View(db.Trainees.Include(x => x.Batch).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.batch = db.Batches.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Trainee t)
        {
            if(ModelState.IsValid)
            {
                db.Trainees.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.batch = db.Batches.ToList();
            return View();
        }
        public IActionResult Edit(int? id)
        {
            var trainee = db.Trainees.FirstOrDefault(x => x.TraineeId == id);
            var batch = db.Batches.ToList();
            ViewBag.data = new SelectList(batch, "BatchId", "BatchCode", trainee.BatchId);
            return View(trainee);
        }
        [HttpPost]
        public IActionResult Edit(Trainee t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t);
        }
        public IActionResult Delete(int? id)
        {
            var trainee = db.Trainees.FirstOrDefault(x => x.TraineeId == id);
            var batch = db.Batches.ToList();
            ViewBag.data = new SelectList(batch, "BatchId", "BatchCode", trainee.BatchId);
            return View(trainee);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var trainee = new Trainee
            {
                TraineeId = id
            };
            db.Entry(trainee).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
