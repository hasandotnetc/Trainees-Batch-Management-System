using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using work_01.Models;

namespace work_01.Controllers
{
    public class BatchesController : Controller
    {
        private readonly TraineeDbContext db;
        public BatchesController(TraineeDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Batches.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Batch b)
        {
            if(ModelState.IsValid)
            {
                db.Batches.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || db.Batches == null)
            {
                return NotFound();
            }
            var batch = await db.Batches.FindAsync(id);
            if(batch == null)
            {
                return NotFound();
            }
            return View(batch);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatchId", "BatchCode")] Batch b)
        {
            if (id != b.BatchId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    db.Update(b);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(b.BatchId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(b);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || db.Batches == null)
            {
                return NotFound();
            }
            var batches = await db.Batches.FirstOrDefaultAsync(x => x.BatchId ==  id);
            if(batches == null)
            {
                return NotFound();
            }
            return View(batches);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if(db.Batches == null)
            {
                return Problem("Database mey khuch nehi hey!");
            }
            var batch = await db.Batches.FindAsync(id);
            if(batch != null)
            {
                db.Batches.Remove(batch);
            }
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool BatchExists(int id)
        {
            return (db.Batches?.Any(b => b.BatchId == id)).GetValueOrDefault();
        }
    }
}
