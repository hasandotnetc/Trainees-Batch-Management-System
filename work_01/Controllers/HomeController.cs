using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using work_01.Models;
using work_01.Models.ViewModels;

namespace work_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly TraineeDbContext db;
        public HomeController(TraineeDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int SelectedBatch = 0)
        {
            BatchViewModel vm = new BatchViewModel
            {
                Batches = db.Batches.ToList(),
                SelectedBatch = SelectedBatch,
                Trainees = SelectedBatch == 0 ? null : db.Batches.Include(x => x.Trainees).First(x => x.BatchId == SelectedBatch).Trainees.ToList()
            };
            return View(vm);
        }
    }
}
